using System;
using System.Data.SqlClient;
using Common;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

public partial class FormEditPlan : Form
{
    public GroupSelector GroupSelector { get { return m_groupSelector; } }

    public FormEditPlan(College college, short groupTypeId)
    {
        InitializeComponent();

        m_collegeDataSet = new CollegeDataSet();
        m_college = college;
        m_groupSelector.GroupTypeId = groupTypeId;
        m_planSelector.GroupTypeId = groupTypeId;
        m_groupSelector.College = m_college;
        m_planSelector.College = m_college;
        m_groupSelector.GroupChanged += (sender, e) =>
        {
            if (m_groupSelector.GroupInfo != null && m_type != 2)
            {
                m_type = 0;
                m_planSelector.GroupInfo = null;
                FillPlanContainer();
            }
            else if (m_groupSelector.GroupInfo == null)
                ClearTablesContainer();
        };
        m_planSelector.GroupChanged += (sender, e) =>
        {
            if (m_planSelector.GroupInfo != null && m_type != 2)
            {
                m_type = 1;
                m_groupSelector.GroupInfo = null;
                FillPlanContainer();
            }
            else if (m_planSelector.GroupInfo == null)
                ClearTablesContainer();
        };
        FormClosed += (sender, e) => Release();

        InitList();
        LoadTables();
    }
    public FormEditPlan() : this(null, 0)
    { }

    private ListContainer<PlanContainer> m_planList;
    private College m_college;
    private CollegeDataSet m_collegeDataSet;
    private int m_type;

    private void ResizeHandler(object sender, EventArgs e) =>
        UpdateControlsSize();
    private void ButtonAddPlanClickHandler(object sender, EventArgs e) =>
        AddPlanContainer();
    private void ButtonDeletePlanClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowDelete() == DialogResult.Yes)
            DeletePlanContainer();
    }
    private void ButtonCancelClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowCloseForm() == DialogResult.Yes)
            Close();
    }
    private void ButtonSemestersClickHandler(object sender, EventArgs e) =>
        new FormEditSemesters(m_collegeDataSet.SemestersLength).ShowDialog();
    private void PanelButtonsResizeHandler(object sender, EventArgs e) =>
        UpdateButtonsLocation();
    private void ButtonCopyClickHandler(object sender, EventArgs e) =>
        CopyPlan();
    private void ButtonDeductionClickHandler(object sender, EventArgs e)
    {
        try
        {
            CheckGroup();
            new FormHoursDeduction(m_collegeDataSet.SemestersLength,
                m_collegeDataSet.Plans, m_collegeDataSet.Semesters, m_college,
                 m_groupSelector.GroupInfo).ShowDialog();
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);
        }
    }
    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        if (Apply())
            Close();
    }

    private void Release()
    {
        m_planList.Clear();
        m_planList.Dispose();
        m_collegeDataSet.Dispose();
    }
    private void InitList()
    {
        m_planList = new ListContainer<PlanContainer>();
        int height = new PlanContainer().Height;
        m_planList.Init(height + 5, new Point(0, m_groupSelector.Height),
            "m_planList", new Size(), 3, 5);
        m_planList.BackColor = SystemColors.ControlLight;
        m_planList.HorizontalScroll.Enabled = false;
        m_planList.HorizontalScroll.Visible = false;
        UpdateListSize();
        Controls.Add(m_planList);
    }
    private void LoadTables()
    {
        m_college.AdapterManager.SubjectsTableAdapter.Fill(m_collegeDataSet.Subjects);
        m_college.AdapterManager.SubjectTypesTableAdapter.Fill(m_collegeDataSet.SubjectTypes);
    }
    private void UpdateControlsSize()
    {
        UpdateGroupSelectorSize();
        UpdatePanelButtonsSize();
        UpdateListSize();
    }
    private void UpdateGroupSelectorSize()
    {
        m_groupSelector.Width = ClientSize.Width;
    }
    private void UpdatePanelButtonsSize()
    {
        m_panelButtons.Width = ClientSize.Width;
        m_panelButtons.Location = new Point(m_panelButtons.Location.X,
            ClientSize.Height - m_panelButtons.Height);
    }
    private void UpdateListSize()
    {
        m_planList.Width = ClientSize.Width;
        m_planList.Height = ClientSize.Height - m_panelButtons.Height -
            m_planList.Location.Y;
    }
    private void UpdateButtonsLocation()
    {
        m_buttonSemesters.Left = m_buttonCancel.Left = m_panelButtons.Width -
            m_buttonCancel.Width - m_buttonOK.Left;
    }
    private PlanContainer AddPlanContainer()
    {
        try
        {
            PlanContainer container = new PlanContainer(m_collegeDataSet.Subjects,
            m_collegeDataSet.SubjectTypes);
            container.SubjectChanged += (sender, e) =>
            {
                if (e.OldSubject != null)
                    foreach (var row in m_collegeDataSet.Subjects)
                    {
                        if (row.RowState == DataRowState.Deleted)
                        {
                            row.RejectChanges();
                            if (row.subject_id == e.OldSubject.subject_id)
                                break;
                            row.Delete();
                        }
                    }

                var deleteRow = m_collegeDataSet.Subjects.Where(row =>
                    row.RowState != DataRowState.Deleted && row.subject_id ==
                    container.Subject.subject_id).First();
                deleteRow.Delete();
            };
            m_planList.Add(container);
            return container;
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);
        }

        return null;
    }
    private void AddSubjectInTable(CollegeDataSet.SubjectsRow row)
    {
        if (row != null)
            m_collegeDataSet.Subjects.AddSubjectsRow(CopySubjectRow(row));
    }
    private CollegeDataSet.SubjectsRow CopySubjectRow(CollegeDataSet.SubjectsRow row)
    {
        var newRow = m_collegeDataSet.Subjects.NewSubjectsRow();
        newRow.subject_id = row.subject_id;
        newRow.subject_name = row.subject_name;

        return newRow;
    }
    private void DeletePlanContainer()
    {
        if (m_planList.SelectedElement != null)
        {
            AddSubjectInTable(m_planList.SelectedElement.Subject);
            if (m_collegeDataSet.Plans.Count > 0)
            {
                var planRow = m_collegeDataSet.Plans.Where(row => row.RowState !=
                    DataRowState.Deleted && row.plan_record_id ==
                    m_planList.SelectedElement.PlanRecordId).FirstOrDefault();
                planRow?.Delete();
            }

            m_planList.DeleteSelected();
        }
    }
    private bool Apply()
    {
        try
        {
            CheckPlanList();
            CheckSemesters();
            if (!CheckGroupAndPlan() && m_planList.Count != 0)
            {
                int res = CreatePlanWithoutGroup();
                if (res == 0)
                    return true;
                else if (res == 1)
                    return false;
            }
            else if (!CheckGroupAndPlan())
                return true;

            SavePlanToDB();

            return true;
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);

            return false;
        }
    }
    private void CheckGroup()
    {
        if (m_groupSelector.GroupInfo == null)
            throw new ApplicationException(Resource1.GroupNotSelected);
    }
    private bool CheckGroupAndPlan()
    {
        if (m_groupSelector.GroupInfo == null && m_planSelector.GroupInfo == null)
            return false;

        return true;
    }
    private int CreatePlanWithoutGroup()
    {
        DialogResult dlgResult = MessageBox.Show("Вы не указали группу. " +
            "Сохранить этот план под каким-либо именем?", "Сообщение",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

        if (dlgResult == DialogResult.No)
            return 0;
        else if (dlgResult == DialogResult.Cancel)
            return 1;
        else
        {
            m_type = 2;
            string planName = GetPlanNameFromForm();
            if (planName == null)
                return 0;
            planName = "$" + planName;
            m_college.AdapterManager.GroupsTableAdapter.Insert(planName,
                m_groupSelector.GroupTypeId);
            m_college.AdapterManager.GroupsTableAdapter.Fill(m_collegeDataSet.Groups);
            int groupId = Convert.ToInt32(m_college.IdentCurrent("groups"));
            m_planSelector.GroupInfo = m_collegeDataSet.Groups.FindBygroup_id(groupId);
            m_type = 1;

            return 2;
        }
    }
    private void CheckPlanList()
    {
        int i = 0;
        try
        {
            for (i = 0; i < m_planList.Count; i++)
                m_planList[i].ValidateContainer();
        }
        catch (ApplicationException exc)
        {
            string message = string.Format(Resource1.ListErrorFormat,
                i + 1, exc.Message);
            throw new ApplicationException(message, exc);
        }
    }
    private void CheckSemesters()
    {
        short[] semesters = m_collegeDataSet.SemestersLength.Where(row =>
            row.RowState != DataRowState.Deleted).Select(row =>
            row.semester_number).ToArray();

        for (int i = 0; i < m_planList.Count; i++)
        {
            var planContainer = m_planList[i];
            foreach (var semesterContainer in planContainer.ListSemesters)
            {
                if (!semesters.Contains(semesterContainer.SemesterNumber))
                {
                    string message = string.Format(Resource1.ForbiddenSemesterFormat,
                        i + 1, semesterContainer.SemesterNumber);
                    throw new ApplicationException(message);
                }
            }
        }
    }
    private void SavePlanToDB()
    {
        int groupId = m_type == 0 ? m_groupSelector.GroupInfo.group_id :
            m_planSelector.GroupInfo.group_id;
        foreach (var row in m_collegeDataSet.SemestersLength)
        {
            if (row.RowState == DataRowState.Deleted)
                continue;
            row.group_id = groupId;
        }

        m_college.AdapterManager.PlansTableAdapter.Update(m_collegeDataSet);
        foreach (PlanContainer planContainer in m_planList)
        {
            if (planContainer.PlanRecordId >= 0)
            {
                if (planContainer.IsChanged)
                    UpdatePlanInDataSet(planContainer);
            }
            else
                AddPlanToDB(planContainer);

            planContainer.IsChanged = false;
        }

        UpdateDataSetInDB();
    }
    private void UpdateDataSetInDB()
    {
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
        {
            m_college.AdapterManager.PlansTableAdapter.Update(m_collegeDataSet);
            m_college.AdapterManager.SemestersTableAdapter.Update(m_collegeDataSet);
            m_college.AdapterManager.SemestersLengthTableAdapter.Update(m_collegeDataSet);
            scope.Complete();
        }
    }
    private void AddPlanToDB(PlanContainer container)
    {
        int groupId = m_type == 0 ? m_groupSelector.GroupInfo.group_id :
            m_planSelector.GroupInfo.group_id;
        m_college.AdapterManager.PlansTableAdapter.Insert(
            groupId, container.Subject.subject_id,
            container.SubjectType.subject_type_id, container.OKRCount,
            container.IKRCount);
        GetPlanAdapter(groupId).Fill(m_collegeDataSet.Plans);
        container.PlanRecordId = Convert.ToInt32(m_college.IdentCurrent("Plans"));
        UpdateSemestersInDataSet(container);
    }
    private void UpdatePlanInDataSet(PlanContainer container)
    {
        var planRow = m_collegeDataSet.Plans.Where(row =>
        {
            if (row.RowState != DataRowState.Deleted)
                return row.plan_record_id == container.PlanRecordId;
            else
                return false;
        }).First();
        planRow.ikr_count = container.IKRCount;
        planRow.okr_count = container.OKRCount;
        planRow.subject_id = container.Subject.subject_id;
        planRow.subject_type_id = container.SubjectType.subject_type_id;

        UpdateSemestersInDataSet(container);
    }
    private void UpdateSemestersInDataSet(PlanContainer container)
    {
        var planRow = m_collegeDataSet.Plans.Where(row =>
        {
            if (row.RowState != DataRowState.Deleted)
                return row.plan_record_id == container.PlanRecordId;
            else
                return false;
        }).First();
        foreach (var row in m_collegeDataSet.Semesters.Where(row =>
            row.RowState != DataRowState.Deleted &&
            row.plan_record_id == planRow.plan_record_id))
        {
            row.Delete();
        }
        foreach (var semesterCont in container.ListSemesters)
        {
            m_collegeDataSet.Semesters.AddSemestersRow(planRow,
                semesterCont.SemesterNumber, semesterCont.HoursCount,
                semesterCont.HoursPerWeek, semesterCont.HoursCountLPZ,
                semesterCont.HoursCountKP, semesterCont.Exam);
        }
    }
    private void FillPlanContainer()
    {
        m_planList.DoUpdateList = false;
        ClearTablesContainer();
        int groupId = m_type == 0 ? m_groupSelector.GroupInfo.group_id :
            m_planSelector.GroupInfo.group_id;
        GetPlanAdapter(groupId).Fill(m_collegeDataSet.Plans);
        GetSemesterLengthAdapter(groupId).Fill(
            m_collegeDataSet.SemestersLength);

        foreach (var row in m_collegeDataSet.Plans)
        {
            AddPlanContainerWithData(row);
            GetSemesterAdapter(row.plan_record_id).Fill(m_collegeDataSet.Semesters);
        }

        m_planList.DoUpdateList = true;
        m_planList.VerticalScroll.Value = 0;
    }
    private PlanContainer AddPlanContainerWithData(CollegeDataSet.PlansRow row)
    {
        var subjectRow = m_collegeDataSet.Subjects.
            FindBysubject_id(row.subject_id);
        if (subjectRow == null)
        {
            throw new ApplicationException("Невозможно добавить запись, " +
                "т.к. запись с такой дисциплиной уже есть.");
        }

        PlanContainer container = AddPlanContainer();
        container.Subject = CopySubjectRow(subjectRow);
        container.SubjectType = m_collegeDataSet.SubjectTypes.
            FindBysubject_type_id(row.subject_type_id);
        container.OKRCount = row.okr_count;
        container.IKRCount = row.ikr_count;
        container.PlanRecordId = row.plan_record_id;
        var semesterTable = m_college.GetSemestersByPlan(row.plan_record_id);
        foreach (var semesterRow in semesterTable)
        {
            SemesterDataContainer semesterCont = new SemesterDataContainer();
            semesterCont.SemesterNumber = semesterRow.semester_number;
            semesterCont.Exam = semesterRow.exam;
            semesterCont.HoursCount = semesterRow.hours_count;
            semesterCont.HoursPerWeek = semesterRow.hours_per_week;
            semesterCont.HoursCountKP = semesterRow.kp_hours_count;
            semesterCont.HoursCountLPZ = semesterRow.lpz_hours_count;
            container.ListSemesters.Add(semesterCont);
        }
        container.IsChanged = false;
        semesterTable.Dispose();

        return container;
    }
    private void ClearTablesContainer()
    {
        m_planList.Clear();
        m_collegeDataSet.Plans.Clear();
        m_collegeDataSet.Semesters.Clear();
        m_collegeDataSet.SemestersLength.Clear();
        m_collegeDataSet.Subjects.RejectChanges();
    }
    private SqlDataAdapter GetPlanAdapter(int groupId)
    {
        return new SqlDataAdapter(
            m_college.GetCommandForStoredProc("GetPlansByGroup", new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId)
            }));
    }
    private SqlDataAdapter GetSemesterAdapter(int planId)
    {
        return new SqlDataAdapter(
            m_college.GetCommandForStoredProc("GetSemestersByPlan", new ParameterDescr[]
            {
                new ParameterDescr("@planId", planId)
            }));
    }
    private SqlDataAdapter GetSemesterLengthAdapter(int groupId)
    {
        return new SqlDataAdapter(
            m_college.GetCommandForStoredProc("GetSemestersLengthByGroup",
            new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId)
            }));
    }
    private string GetPlanNameFromForm()
    {
        FormPlanName form = new FormPlanName();
        string temp = null;
        form.FormClosing += (sender, e) => temp = form.PlanName;
        form.ShowDialog();

        return temp;
    }
    private void CopyPlan()
    {
        int groupIdForCopy = GetGroupIdForCopy();
        if (groupIdForCopy == -1)
            return;

        var planTableForCopy = m_college.GetPlansByGroup(groupIdForCopy);
        var semestersTableForCopy = m_college.GetSemestersLengthByGroup(groupIdForCopy);
        if (planTableForCopy.Count == 0 && semestersTableForCopy.Count == 0)
        {
            MyMessageBox.ShowError("Данный план пуст");
            return;
        }

        bool overwrite = true;
        if (m_planList.Count > 0 || m_collegeDataSet.SemestersLength.Count > 0)
        {
            DialogResult result = MessageBox.Show("В текущем плане есть записи. " +
                "Стереть их перед копированием?", "Сообщение", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.No)
                overwrite = false;
        }

        if (overwrite)
        {
            while (m_planList.Count > 0)
            {
                m_planList.SelectedElement = m_planList[0];
                DeletePlanContainer();
            }
            foreach (var planRow in m_collegeDataSet.Plans)
            {
                if (planRow.RowState != DataRowState.Deleted)
                    planRow.Delete();
            }
            foreach (var semesterRow in m_collegeDataSet.SemestersLength)
            {
                if (semesterRow.RowState != DataRowState.Deleted)
                    semesterRow.Delete();
            }
        }

        int? groupId = m_type == 0 ? m_groupSelector.GroupInfo?.group_id :
            m_planSelector.GroupInfo?.group_id;
        groupId = groupId ?? -1;

        bool existSubject = false;
        bool existSemester = false;
        foreach (var planRow in planTableForCopy)
        {
            try
            {
                var planContainer = AddPlanContainerWithData(planRow);
                planContainer.PlanRecordId = -1;
                planContainer.IsChanged = false;
            }
            catch (ApplicationException exc)
            {
                existSubject = true;
            }
        }
        foreach (var semesterRow in semestersTableForCopy)
        {
            if (m_collegeDataSet.SemestersLength.Where(row =>
                row.RowState != DataRowState.Deleted && row.semester_number ==
                semesterRow.semester_number).FirstOrDefault() != null)
            {
                existSemester = true;
                continue;
            }

            var newSemesterRow = m_collegeDataSet.SemestersLength.
                NewSemestersLengthRow();
            newSemesterRow.group_id = groupId.Value;
            newSemesterRow.length = semesterRow.length;
            newSemesterRow.semester_number = semesterRow.semester_number;
            m_collegeDataSet.SemestersLength.AddSemestersLengthRow(newSemesterRow);
        }

        if (existSubject)
            MyMessageBox.ShowError("Некоторые записи не были скопированы, т.к. записи с такими дисциплинами уже есть в плане.");
        if (existSemester)
            MyMessageBox.ShowError("Некоторые семестры не были скопированы, т.к. номера семестров совпадали.");
    }
    private int GetGroupIdForCopy()
    {
        var form = new FormCopyPlan(m_college, m_groupSelector.GroupTypeId);
        int temp = 0;
        form.FormClosing += (sender, e) => temp = form.GroupIdForCopy;
        form.ShowDialog();

        return temp;
    }
}
