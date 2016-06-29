using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Drawing;
using Common;

public partial class FormAddStudent : Form
{
    public GroupSelector GroupSelector { get { return m_groupSelector; } }

    public FormAddStudent() : this(null, 0)
    { }
    public FormAddStudent(College college, short groupTypeId)
    {
        InitializeComponent();
        InitList();
        LoadMaxLengths();

        OnResize(new EventArgs());
        
        m_college = college;
        m_groupSelector.GroupTypeId = groupTypeId;
        m_groupSelector.College = m_college;
    }

    private College m_college;
    private ListContainer<StudentDataContainer> m_studentList;
    private int m_firstNameLength;
    private int m_secondNameLength;
    private int m_middleNameLength;

    private const int BUTTON_OFFSET = 5;

    private void ResizeHandler(object sender, EventArgs e) =>
        UpdateControlsSize();
    private void ButtonAddStudentClickHandler(object sender, EventArgs e) =>
        AddStudentContainer();
    private void ButtonDeleteStudentClickHandler(object sender, EventArgs e) =>
        m_studentList.DeleteSelected();
    private void ButtonsPanelResizeHandler(object sender, EventArgs e) =>
        UpdateButtonsPosition();
    private void ButtonCancelClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowCloseForm() == DialogResult.Yes)
            Close();
    }
    private void ButtonApplyClickHandler(object sender, EventArgs e)
    {
        if (Apply())
            m_studentList.Clear();
    }
    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        if (Apply())
            Close();
    }

    private void LoadMaxLengths()
    {
        CollegeDataSet.StudentsDataTable table = 
            new CollegeDataSet.StudentsDataTable();
        m_firstNameLength = table.first_nameColumn.MaxLength;
        m_secondNameLength = table.second_nameColumn.MaxLength;
        m_middleNameLength = table.middle_nameColumn.MaxLength;
    }
    private void AddStudentContainer()
    {
        StudentDataContainer container = new StudentDataContainer();

        container.TextFirstName.MaxLength = m_firstNameLength;
        container.TextSecondName.MaxLength = m_secondNameLength;
        container.TextMiddleName.MaxLength = m_middleNameLength;

        m_studentList.Add(container);
    }
    private void UpdateControlsSize()
    {
        int width = ClientSize.Width;
        m_groupSelector.Width = width;
        m_buttonsPanel.Location = new Point(0, ClientSize.Height -
            m_buttonsPanel.Height);
        m_buttonsPanel.Width = width;
        m_studentList.Size = new Size(width, m_buttonsPanel.Location.Y -
            m_studentList.Location.Y);
    }
    private void UpdateButtonsPosition()
    {
        int width = m_buttonsPanel.ClientSize.Width;
        m_buttonApply.Location = new Point(((width - BUTTON_OFFSET * 2) / 2) - 
            m_buttonApply.Width / 2, m_buttonApply.Location.Y);
        m_buttonCancel.Location = new Point((width - BUTTON_OFFSET) -
            m_buttonCancel.Width, m_buttonCancel.Location.Y);
    }
    private bool Apply()
    {
        try
        {
            if (m_studentList.Count == 0)
                throw new ApplicationException(Resource1.ListStudentsEmpty);
            if (m_groupSelector.GroupInfo == null)
                throw new ApplicationException(Resource1.GroupNotSelected);
            CheckStudentsData();
            AddStudentToDB();

            return true;
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);

            return false;
        }
    }
    private void CheckStudentsData()
    {
        for (int i = 0; i < m_studentList.Count; i++)
        {
            StudentDataContainer container = (StudentDataContainer)m_studentList[i];
            StudentDataContainer.CheckDataResult result = container.CheckData();
            if (result.Result != StudentDataContainer.Result.OK)
            {
                throw new StudentAddException(result, string.Format(
                    Resource1.ListErrorFormat, i + 1, ErrorStringFromResult(result)));
            }
        }
    }
    private void AddStudentToDB()
    {
        foreach (StudentDataContainer container in m_studentList)
        {
            m_college.AdapterManager.StudentsTableAdapter.Insert(container.TextFirstName.Text,
                container.TextSecondName.Text, container.TextMiddleName.Text,
                m_groupSelector.GroupInfo.group_id);
        }
    }

    private static string ErrorStringFromResult(
        StudentDataContainer.CheckDataResult result)
    {
        string errorText = null;
        if (result.Result == StudentDataContainer.Result.EmptyField)
            errorText = string.Format(Resource1.EmptyFieldFormat, result.FieldName);
        else
            errorText = string.Format(Resource1.ForbiddenCharFormat, result.FieldName);

        return errorText;
    }
    private void InitList()
    {
        m_studentList = new ListContainer<StudentDataContainer>();
        m_studentList.Init(35, new Point(0, m_groupSelector.Height), 
            "m_studentList", new Size(529, 220), 3, 5);
        Controls.Add(m_studentList);
    }
}
