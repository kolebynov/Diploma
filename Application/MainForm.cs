using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Application;
using System.Diagnostics;

public partial class MainForm : Form
{
    public College college;

    public CollegeDataSet.GroupTypesDataTable groupTypesDataTable;
    public CollegeDataSet.GroupsDataTable groupDataTable;
    public CollegeDataSet.StudentsDataTable studentDataTable;
    public CollegeDataSet.MarksDataTable marksDataTable;
    public CollegeDataSet.PlansDataTable plansDataTable;
    public CollegeDataSet.SubjectsDataTable subjectsDataTable;
    public CollegeDataSet.MarkTypesDataTable marksTypeDataTable;
    public CollegeDataSet.SemestersDataTable semesterDataTable;

    public List<int> groupsIndices;
    public List<int> studentsIndices;
    public List<int> marksIndices;

    public MainForm()
    {
        InitializeComponent();
        Init();
    }

    private const string CONNECTION_SETTINGS_FILENAME = "Connection.xml";
    private const string COLUMNS_SCHEMA_FILENAME = "ColumnsSchema.xml";

    private void Init()
    {
        groupTypesDataTable = new CollegeDataSet.GroupTypesDataTable();
        groupDataTable = new CollegeDataSet.GroupsDataTable();
        studentDataTable = new CollegeDataSet.StudentsDataTable();
        marksDataTable = new CollegeDataSet.MarksDataTable();
        subjectsDataTable = new CollegeDataSet.SubjectsDataTable();
        plansDataTable = new CollegeDataSet.PlansDataTable();
        marksTypeDataTable = new CollegeDataSet.MarkTypesDataTable();
        semesterDataTable = new CollegeDataSet.SemestersDataTable();

        marksIndices = new List<int>();
        groupsIndices = new List<int>();
        studentsIndices = new List<int>();

        comboBoxSheet.SelectedIndex = 0;
        comboBoxSemestr.SelectedIndex = 0;

        BackColor = System.Drawing.Color.FromArgb(255, 255, 225);

        ConnectionSettings settings = LoadConnectionSettings();
        ApplyNewConnectionSettings(settings);
    }
    private ConnectionSettings LoadConnectionSettings()
    {
        FileStream fileSettings = null;
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConnectionSettings));
            fileSettings = File.OpenRead(CONNECTION_SETTINGS_FILENAME);      

            return (ConnectionSettings)serializer.Deserialize(fileSettings);
        }
        catch (Exception)
        {
            return new ConnectionSettings();
        }
        finally
        {
            fileSettings?.Dispose();
        }
    }
    private void SaveConnectionSettings(ConnectionSettings connectionSettings)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ConnectionSettings));
        FileStream fileSettings = File.Create(CONNECTION_SETTINGS_FILENAME);
        serializer.Serialize(fileSettings, connectionSettings);
    }
    private void LoadGroupTypes()
    {
        groupTypesDataTable.Clear();
        comboBoxParting.Items.Clear();
        college.AdapterManager.GroupTypesTableAdapter.Fill(groupTypesDataTable);
        for (int i = 0; i < groupTypesDataTable.Rows.Count; i++)
        {
            comboBoxParting.Items.Add(groupTypesDataTable[i].group_type_name);
        }
        if (comboBoxParting.Items.Count > 0)
            comboBoxParting.SelectedIndex = 0;
    }
    private void UpdateGroupsListHandler(object sender, EventArgs e)
    {
        listBoxGroups.Items.Clear();
        listBoxStudents.Items.Clear();
        listBoxMarks.Items.Clear();

        groupsIndices.Clear();

        groupDataTable?.Dispose();
        groupDataTable = college.GetGroupsByGroupTypeId(
            groupTypesDataTable[comboBoxParting.SelectedIndex].group_type_id);

        for (int i = 0; i < groupDataTable.Rows.Count; i++)
        {
            listBoxGroups.Items.Add(groupDataTable[i].group_name);
            groupsIndices.Add(groupDataTable[i].group_id);
        }
    }

    private void UpdateStudentsListHandler(object sender, EventArgs e)
    {
        if (listBoxGroups.SelectedIndex < 0) return;

        listBoxStudents.Items.Clear();
        listBoxMarks.Items.Clear();

        studentsIndices.Clear();

        college.AdapterManager.StudentsTableAdapter.Fill(studentDataTable);

        for (int i = 0; i < studentDataTable.Rows.Count; i++)
        {
            if (studentDataTable[i].group_id == groupsIndices[listBoxGroups.SelectedIndex])
            {
                listBoxStudents.Items.Add
                    (
                        studentDataTable[i].second_name + " " +
                        studentDataTable[i].first_name + " " +
                        studentDataTable[i].middle_name
                    );
                studentsIndices.Add(studentDataTable[i].student_id);
            }
        }
    }

    private void UpdateMarksListHandler(object sender, EventArgs e)
    {
        if (listBoxStudents.SelectedIndex < 0) return;

        listBoxMarks.Items.Clear();

        marksIndices.Clear();

        college.AdapterManager.MarksTableAdapter.Fill(marksDataTable);
        college.AdapterManager.SubjectsTableAdapter.Fill(subjectsDataTable);
        college.AdapterManager.PlansTableAdapter.Fill(plansDataTable);
        college.AdapterManager.MarkTypesTableAdapter.Fill(marksTypeDataTable);

        for (int i = 0; i < marksDataTable.Rows.Count; i++)
        {
            if (marksDataTable[i].student_id == studentsIndices[listBoxStudents.SelectedIndex])
            {
                listBoxMarks.Items.Add
                    (
                        (Mark)marksDataTable[i].mark + " - " + 
                        subjectsDataTable.FindBysubject_id(plansDataTable.FindByplan_record_id(marksDataTable[i].plan_record_id).subject_id).subject_name + 
                        "(" + marksTypeDataTable.FindBymark_type_id(marksDataTable[i].mark_type_id).mark_type_name + ")"
                    );

                marksIndices.Add(marksDataTable[i].plan_record_id);
            }
        }
    }

    private void SelectSheetHandler(object sender, EventArgs e)
    {
        if (comboBoxSheet.SelectedIndex == 0) comboBoxSemestr.Enabled = true;
        else comboBoxSemestr.Enabled = false;
    }

    private void AddGroupHandler(object sender, EventArgs e)
    {
        if (comboBoxParting.SelectedIndex == -1)
        {
            MessageBox.Show("Не выбрано отделение.");
            return;
        }
        FormAddGroup addform = new FormAddGroup(college);
        addform.GroupTypeComboBox.Text = comboBoxParting.Text;
        addform.GroupTypeComboBox.Enabled = false;
        addform.ShowDialog();

        UpdateGroupsListHandler(null, null);
    }

    private void RemoveGroupHandler(object sender, EventArgs e)
    {
        if (listBoxGroups.SelectedIndex < 0)
        {
            MessageBox.Show("Группа не выбрана", "Предупреждение", MessageBoxButtons.OK);
            return;
        }

        int index = groupsIndices[listBoxGroups.SelectedIndex];
        var group = groupDataTable.FindBygroup_id(index);

        DialogResult result = MessageBox.Show("Вы пытаетесь удалить группу " + group.group_name, "Предупреждение", MessageBoxButtons.YesNo);
        if (result == DialogResult.No) return;

        college.DeleteGroup(group.group_id);

        UpdateGroupsListHandler(null, null);
    }

    private void AddStudentHandler(object sender, EventArgs e)
    {
        if (listBoxGroups.SelectedIndex < 0)
        {
            MessageBox.Show("Группа не выбрана", "Предупреждение", MessageBoxButtons.OK);
            return;
        }

        int index = groupsIndices[listBoxGroups.SelectedIndex];
        var group = groupDataTable.FindBygroup_id(index);

        FormAddStudent addform = new FormAddStudent(college, (short)comboBoxParting.SelectedIndex);
        addform.GroupSelector.GroupInfo = group;
        addform.ShowDialog();

        UpdateStudentsListHandler(null, null);
    }

    private void RemoveStudentHandler(object sender, EventArgs e)
    {
        if (listBoxStudents.SelectedIndex < 0)
        {
            MessageBox.Show("Студент не выбран", "Предупреждение", MessageBoxButtons.OK);
            return;
        }

        int index = studentsIndices[listBoxStudents.SelectedIndex];
        var student = studentDataTable.FindBystudent_id(index);

        DialogResult result = MessageBox.Show("Вы пытаетесь удалить студента " + student.second_name, "Предупреждение", MessageBoxButtons.YesNo);
        if (result == DialogResult.No) return;      

        college.AdapterManager.StudentsTableAdapter.Delete
            (
                  student.student_id,
                  student.first_name,
                  student.second_name,
                  student.middle_name,
                  student.group_id
            );

        UpdateStudentsListHandler(null, null);
    }

    private void ViewSheetHandler(object sender, EventArgs e)
    {
        if (listBoxGroups.SelectedIndex < 0)
        {
            MessageBox.Show("Группа не выбрана", "Предупреждение", MessageBoxButtons.OK);
            return;
        }

        int index = groupsIndices[listBoxGroups.SelectedIndex];

        college.AdapterManager.SubjectsTableAdapter.Fill(subjectsDataTable);
        college.AdapterManager.PlansTableAdapter.Fill(plansDataTable);
        college.AdapterManager.GroupsTableAdapter.Fill(groupDataTable);
        college.AdapterManager.StudentsTableAdapter.Fill(studentDataTable);
        college.AdapterManager.MarksTableAdapter.Fill(marksDataTable);
        college.AdapterManager.SemestersTableAdapter.Fill(semesterDataTable);

        if (subjectsDataTable.Count == 0 || plansDataTable.Count == 0) return;

        ExcelExporter excelExportet = new ExcelExporter();

        if (comboBoxSheet.SelectedIndex == 0)
        excelExportet.CreateSemesterReport
            (
                college, 
                index, 
                short.Parse(comboBoxSemestr.Text),
                plansDataTable,
                subjectsDataTable,
                groupDataTable,
                studentDataTable,
                marksDataTable,
                semesterDataTable
            );
        else
            excelExportet.CreateFinalReport
            (
                college,
                index,
                plansDataTable,
                subjectsDataTable,
                groupDataTable,
                studentDataTable,
                marksDataTable,
                semesterDataTable
            );
    }

    private void button1_Click(object sender, EventArgs e)
    {
        short groupTypeId = groupTypesDataTable.Where(row => 
            row.group_type_name == (string)comboBoxParting.SelectedItem).
            First().group_type_id;
        if (listBoxGroups.SelectedIndex < 0)
        {
            FormEditPlan formPlan = new FormEditPlan(college, groupTypeId);
            formPlan.ShowDialog();
            return;
        }

        int index = groupsIndices[listBoxGroups.SelectedIndex];
        var group = groupDataTable.FindBygroup_id(index);

        FormEditPlan planEditor = new FormEditPlan(college, groupTypeId);
        planEditor.GroupSelector.GroupInfo = group;
        planEditor.ShowDialog();
    }

    private void buttonEditMark_Click(object sender, EventArgs e)
    {
        if (listBoxGroups.SelectedIndex < 0)
        {
            MessageBox.Show("Группа не выбрана", "Предупреждение", MessageBoxButtons.OK);
            return;
        }

        int index = groupsIndices[listBoxGroups.SelectedIndex];
        var group = groupDataTable.FindBygroup_id(index);

        FormEditMarks markEditor = new FormEditMarks(college);
        markEditor.GroupSelector.GroupTypeId = group.group_type_id;
        markEditor.GroupSelector.GroupInfo = group;
        markEditor.ShowDialog();
    }
    private void ApplyNewConnectionSettings(ConnectionSettings connectionSettings)
    {
        try
        {
            college?.Dispose();
            Connection connection = new Connection(connectionSettings.serverName,
                connectionSettings.dbName, connectionSettings.integratedSecurity,
                connectionSettings.login, connectionSettings.pass);
            connection.Open();
            DataTable originalColumnsSchema = GetSchemaFromFile(COLUMNS_SCHEMA_FILENAME);
            DataTable columnsSchema = connection.SqlConnection.GetSchema("columns");
            connection.Close();
            if (!EqualsColumnsSchema(originalColumnsSchema, columnsSchema))
            {
                MyMessageBox.ShowError(Resource1.WrongTable);
                return;
            }
            college = new College(connection);
            LoadGroupTypes();
            SaveConnectionSettings(connectionSettings);
        }
        catch (SqlException)
        {
            MyMessageBox.ShowError("Настройки подключения неправильны. Настройте их в следующем окне.");
            ShowConnectionSettingsForm(false);
        }
    }
    private bool EqualsColumnsSchema(DataTable table1, DataTable table2)
    {
        if (table1.Rows.Count != table2.Rows.Count || 
            table1.Columns.Count != table2.Columns.Count)
            return false;

        for (int i = 0; i < table1.Rows.Count; ++i)
            for (int j = 0; j < table1.Rows[i].ItemArray.Length; ++j)
            {
                if (!table1.Rows[i].ItemArray[j].Equals(table2.Rows[i].ItemArray[j]) &&
                    table1.Columns[j].ColumnName != "TABLE_CATALOG")
                    return false;
            }

        return true;
    }
    private void CreateColumnsSchema(SqlConnection connection)
    {
        FileStream file = null;
        try
        {
            connection.Open();
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            file = File.Create(COLUMNS_SCHEMA_FILENAME);
            serializer.Serialize(file, connection.GetSchema("columns"));
        }
        catch (Exception)
        { }
        finally
        {
            file?.Dispose();
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
    private DataTable GetSchemaFromFile(string fileName)
    {
        FileStream file = null;
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            file = File.OpenRead(fileName);
            return (DataTable)serializer.Deserialize(file);
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            file?.Dispose();
        }
    }
    private void ShowConnectionSettingsForm(bool isCheck)
    {
        Connection connection = college?.Connection;
        ConnectionSettings connSettings = new ConnectionSettings();
        if (connection != null)
        {
            connSettings.dbName = connection.Database;
            connSettings.integratedSecurity = connection.IntegratedSecurity;
            connSettings.login = connection.User;
            connSettings.pass = connection.Password;
            connSettings.serverName = connection.Server;
        }
        FormSettingConnection form = new FormSettingConnection(
            connSettings, isCheck);
        form.ConnectionSettingsAccept += (sender2, e2) =>
            ApplyNewConnectionSettings(e2.ConnectionSettings);
        form.ShowDialog();
    }

    private void ButtonEditGroupTypesClicHandler(object sender, EventArgs e)
    {
        new FormEditGroupTypes(college).ShowDialog();
        LoadGroupTypes();
    }

    private void SubitemSubjectsClickHandler(object sender, EventArgs e) =>
        new FormEditSubjects(college.AdapterManager.SubjectsTableAdapter).ShowDialog();

    private void SubitemSubjectTypesClickHandler(object sender, EventArgs e) =>
        new FormEditSubjectTypes(
            college.AdapterManager.SubjectTypesTableAdapter).ShowDialog();

    private void SubitemConnectionSettingsClickHandler(object sender, EventArgs e) =>
        ShowConnectionSettingsForm(true);

    private void SubitemAboutClickHandler(object sender, EventArgs e) =>
        new AboutBox().ShowDialog();

    private void SubitemHelpClickHandler(object sender, EventArgs e) =>
        Process.Start("справка.mht");

    private void SubitemExitClickHandler(object sender, EventArgs e)
    {
        System.Windows.Forms.Application.Exit();
    }
}