using System;
using System.Collections.Generic;
using Common;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class FormEditSemesters : Form
{
    public FormEditSemesters(CollegeDataSet.SemestersLengthDataTable table)
    {
        m_table = table;

        InitializeComponent();
        InitList();
        LoadSemesters();
    }

    private CollegeDataSet.SemestersLengthDataTable m_table;
    private ListContainer<SemesterLengthContainer> m_semestersList;
    private bool m_isCancel = true;

    private void ButtonAddClickHandler(object sender, EventArgs e)
    {
        if (m_semestersList.Count < 8)
            AddSemester();
    }
    private void ButtonDeleteClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowDelete() == DialogResult.Yes)
            DeleteSemester();
    }
    private void ButtonCancelClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowCloseForm() == DialogResult.Yes)
        {
            m_isCancel = true;
            Close();
        }
    }
    private void ButtonOKClicHandler(object sender, EventArgs e)
    {
        if (Apply())
        {
            m_isCancel = false;
            Close();
        }
    }
    private void FormClosingHandler(object sender, FormClosingEventArgs e)
    {
        if (m_isCancel)
            m_table.RejectChanges();
    }

    private void InitList()
    {
        m_semestersList = new ListContainer<SemesterLengthContainer>();
        int height = new SemesterLengthContainer().Height;
        Controls.Add(m_semestersList);
        m_semestersList.Init(height + 2, new Point(0, 0), "m_semestersList", 
            new Size(ClientSize.Width, ClientSize.Height - m_panelButtons.Height), 3, 5);
        m_semestersList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left |
            AnchorStyles.Right | AnchorStyles.Top;
    }
    private void LoadSemesters()
    {
        foreach (var semesterRow in m_table)
        {
            if (semesterRow.RowState == DataRowState.Deleted)
                continue;

            var semesterContainer = AddSemester();
            semesterContainer.LengthID = semesterRow.semester_length_id;
            semesterContainer.Length = semesterRow.length;
            semesterContainer.Number = semesterRow.semester_number;
            semesterContainer.IsChanged = false;
        }
    }
    private SemesterLengthContainer AddSemester()
    {
        SemesterLengthContainer container = new SemesterLengthContainer();
        container.Number = (short)(m_semestersList.Count + 1);
        container.IsChanged = false;
        m_semestersList.Add(container);

        return container;
    }
    private void DeleteSemester()
    {
        var semesterContainer = m_semestersList.SelectedElement;
        if (semesterContainer != null)
        {
            if (m_table.Count > 0)
            {
                var semesterRow = m_table.Where(row => row.RowState !=
                    DataRowState.Deleted && row.semester_length_id ==
                    semesterContainer.LengthID).FirstOrDefault();
                semesterRow?.Delete();
            }

            m_semestersList.DeleteSelected();
        }
    }
    private bool Apply()
    {
        try
        {
            CheckSemesters();
            UpdateContainersInTable();

            return true;
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);
            m_table.RejectChanges();

            return false;
        }
    }
    private void CheckSemesters()
    {
        int i = 0;
        try
        {
            List<short> numbers = new List<short>();
            for (i = 0; i < m_semestersList.Count; i++)
            {
                var container = m_semestersList[i];
                if (numbers.Contains(container.Number))
                {
                    string message = string.Format(Resource1.ListErrorFormat,
                        i + 1, Resource1.SemesterRepeatError);
                    throw new ApplicationException(message);
                }
                else
                    numbers.Add(container.Number);

                double test = container.Length;
            }
        }
        catch (FormatException exc)
        {
            string message = string.Format(Resource1.ListErrorFormat, i + 1, 
                Resource1.BadFormatSemesterLengthError);
            throw new ApplicationException(message, exc);
        }
    }
    private void UpdateContainersInTable()
    {
        foreach (var container in m_semestersList)
        {
            if (container.LengthID > -1)
            {
                if (container.IsChanged)
                    UpdateContainerInTable(container);
            }
            else
                AddContainerToTable(container);
        }
    }
    private void UpdateContainerInTable(SemesterLengthContainer container)
    {
        var semesterRow = m_table.Where(row => row.RowState != 
            DataRowState.Deleted && row.semester_length_id ==
            container.LengthID).First();
        semesterRow.semester_number = container.Number;
        semesterRow.length = container.Length;
    }
    private void AddContainerToTable(SemesterLengthContainer container)
    {
        if (m_table.Where(row => row.RowState != DataRowState.Deleted && 
            row.semester_number == container.Number).FirstOrDefault() != null)
            return;

        var semesterRow = m_table.NewSemestersLengthRow();
        semesterRow.semester_number = container.Number;
        semesterRow.length = container.Length;
        semesterRow.group_id = -1;
        m_table.AddSemestersLengthRow(semesterRow);
    }
}
