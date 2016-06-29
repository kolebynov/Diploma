using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class PlanContainer : UserControl
{
    public event EventHandler<SubjectChangedEventArgs> SubjectChanged;

    public CollegeDataSet.SubjectsDataTable SubjectsTable { get; set; }
    public CollegeDataSet.SubjectTypesDataTable SubjectTypesTable { get; set; }
    public CollegeDataSet.SubjectsRow Subject
    {
        get { return m_subject; }
        set
        {
            if (value != null)
                m_textBoxSubjectName.Text = value.subject_name;

            SubjectChangedEventArgs args = new SubjectChangedEventArgs(m_subject);
            m_subject = value;
            SubjectChanged?.Invoke(this, args);
        }
    }
    public CollegeDataSet.SubjectTypesRow SubjectType
    {
        get
        {
            return SubjectTypesTable.Where(row => row.subject_type_name ==
                m_comboBoxType2.Text).First();
        }
        set
        {
            m_comboBoxType1.SelectedIndex = Convert.ToInt32(
                value.subject_global_type);
            m_comboBoxType2.Text = value.subject_type_name;
        }
    }
    public short OKRCount
    {
        get { return (short)m_numericOKR.Value; }
        set { m_numericOKR.Value = value; }
    }
    public short IKRCount
    {
        get { return (short)m_numericIKR.Value; }
        set { m_numericIKR.Value = value; }
    }
    public ListContainer<SemesterDataContainer> ListSemesters { get { return m_listSemesters; } }
    public int PlanRecordId { get; set; }
    public bool IsChanged
    {
        get
        {
            foreach (SemesterDataContainer container in m_listSemesters)
                if (container.IsChanged)
                    return true;

            return m_isChanged;
        }
        set
        {
            foreach (SemesterDataContainer container in m_listSemesters)
                container.IsChanged = value;
            m_isChanged = value;
        }
    }

    public PlanContainer(CollegeDataSet.SubjectsDataTable subjectsTable,
        CollegeDataSet.SubjectTypesDataTable subjectTypesTable, int planRecordId)
    {
        SubjectsTable = subjectsTable;
        SubjectTypesTable = subjectTypesTable;
        PlanRecordId = planRecordId;

        InitializeComponent();
        InitList();

        m_comboBoxType1.SelectedIndex = 0;
        SubjectsTypesLoadToComboBox();

        m_comboBoxType1.SelectedIndexChanged += ValueChangedHandler;
        m_comboBoxType2.SelectedIndexChanged += ValueChangedHandler;
        m_buttonAddSemester.Click += ValueChangedHandler;
        m_buttonDeleteSemester.Click += ValueChangedHandler;
    }
    public PlanContainer(CollegeDataSet.SubjectsDataTable subjectsTable,
        CollegeDataSet.SubjectTypesDataTable subjectTypesTable) :
        this(subjectsTable, subjectTypesTable, -1)
    { }
    public PlanContainer() : this(null, null, -1)
    { }

    public void ValidateContainer()
    {
        if (m_textBoxSubjectName.Text == string.Empty)
            throw new ApplicationException("Поле \"Предмет\" пусто.");
        if (m_listSemesters.Count == 0)
            throw new ApplicationException("Не добавлено ни одного семестра.");
    }

    private ListContainer<SemesterDataContainer> m_listSemesters;
    private bool m_isChanged = false;
    private CollegeDataSet.SubjectsRow m_subject;

    private const int XOFFSET_RIGHT = 4;
    private const int YOFFSET_DOWN = 4;

    private void ButtonAddSemesterClickHandler(object sender, EventArgs e) =>
        AddSemesterContainer();
    private void ButtonDeleteSemesterClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowDelete() == DialogResult.Yes)
            m_listSemesters.DeleteSelected();
    }
    private void ResizeHandler(object sender, EventArgs e) =>
        UpdateControlsSize();
    private void ButtonSelectSubjectClickHandler(object sender, EventArgs e) =>
        SelectSubject();
    private void ComboBoxType1SelectedIndexChangedHandler(object sender, EventArgs e) =>
        SubjectsTypesLoadToComboBox();
    private void LeaveHandler(object sender, EventArgs e) =>
        m_listSemesters.SelectedElement = null;

    private void AddSemesterContainer()
    {
        if (m_listSemesters.Count > 7)
            return;
        SemesterDataContainer container = new SemesterDataContainer();
        container.SemesterNumber = (short)(m_listSemesters.Count + 1);
        m_listSemesters.Add(container);
    }
    private void InitList()
    {
        m_listSemesters = new ListContainer<SemesterDataContainer>();
        SemesterDataContainer cont = new SemesterDataContainer();
        m_listSemesters.Init(cont.Height, new Point(3, 86), "m_listSemesters", 
            new Size(407, 150), 3, 5);
        m_listSemesters.HorizontalScroll.Enabled = false;
        m_listSemesters.HorizontalScroll.Visible = false;
        Controls.Add(m_listSemesters);
    }
    private void UpdateControlsSize()
    {
        UpdateListSize();
        UpdateButtonsPosition();
        UpdateTextEditSize();
        UpdateComboBoxesSize();
    }
    private void UpdateListSize()
    {
        m_listSemesters.Width = Width - m_listSemesters.Location.X - 
            XOFFSET_RIGHT;
        m_listSemesters.Height = Height - m_listSemesters.Location.Y - 
            YOFFSET_DOWN;
    }
    private void UpdateButtonsPosition()
    {
        m_buttonSelectSubject.Location = new Point(Width -
            m_buttonSelectSubject.Width - XOFFSET_RIGHT, 
            m_buttonSelectSubject.Location.Y);

        m_panelButtons.Location = new Point(Width - m_panelButtons.Width -
            XOFFSET_RIGHT, m_panelButtons.Location.Y);
    }
    private void UpdateTextEditSize()
    {
        m_textBoxSubjectName.Width = m_buttonSelectSubject.Location.X - 
            m_textBoxSubjectName.Location.X - 6;

    }
    private void UpdateComboBoxesSize()
    {
        int dist = m_comboBoxType2.Left - (m_comboBoxType1.Left + m_comboBoxType1.Width);
        int width = Width - m_comboBoxType1.Left - XOFFSET_RIGHT;
        m_comboBoxType1.Width = (width - dist) / 2;
        m_comboBoxType2.Left = m_comboBoxType1.Left + (width + dist) / 2;
        m_comboBoxType2.Width = Width - m_comboBoxType2.Left - XOFFSET_RIGHT - 1;
    }
    private void SelectSubject()
    {
        FormSelect formSelect = new FormSelect(SubjectsTable);

        formSelect.ItemSelected += (sender, e) => Subject = 
            e.SelectedRows[0] as CollegeDataSet.SubjectsRow;
        formSelect.DataGrid.Columns[0].Visible = false;
        formSelect.DataGrid.Columns[1].HeaderText = "Наименование дисциплины";

        formSelect.ShowDialog();
    }
    private void SubjectsTypesLoadToComboBox()
    {
        if (SubjectTypesTable == null)
            return;

        m_comboBoxType2.Items.Clear();
        m_comboBoxType2.Items.AddRange(SubjectTypesTable.Where
            (
                row => row.subject_global_type == Convert.ToBoolean(
                    m_comboBoxType1.SelectedIndex) ? true : false).Select(
                    row => row.subject_type_name).ToArray()
            );
        m_comboBoxType2.SelectedIndex = 0;
    }

    private void ValueChangedHandler(object sender, EventArgs e) =>
        m_isChanged = true;
}

public class SubjectChangedEventArgs : EventArgs
{
    public CollegeDataSet.SubjectsRow OldSubject { get; }

    public SubjectChangedEventArgs(CollegeDataSet.SubjectsRow oldSubject)
    {
        OldSubject = oldSubject;
    }
}
