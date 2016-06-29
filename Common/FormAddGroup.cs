using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class FormAddGroup : Form
{
    public ComboBox GroupTypeComboBox { get { return m_comboBoxType; } }

    public FormAddGroup(College college)
    {
        if (college == null)
            throw new ArgumentNullException("college");
        m_college = college;

        InitializeComponent();
        LoadGroupTypes();
        CollegeDataSet.GroupsDataTable temp = new CollegeDataSet.GroupsDataTable();
        m_textBoxName.MaxLength = temp.group_nameColumn.MaxLength;
    }

    private College m_college;
    private CollegeDataSet.GroupTypesDataTable m_groupTypesTable;

    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        try
        {
            Apply();
            Close();
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);
        }
        catch (SqlException exc)
        {
            if (exc.Number == 2627)
                MyMessageBox.ShowError("Группа с таким именем уже существует.");
            else
                throw exc;
        }
    }
    private void ButtonCancelClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowCloseForm() == DialogResult.Yes)
            Close();
    }

    private void LoadGroupTypes()
    {
        m_groupTypesTable = new CollegeDataSet.GroupTypesDataTable();
        m_college.AdapterManager.GroupTypesTableAdapter.Fill(m_groupTypesTable);
        foreach (var row in m_groupTypesTable)
            m_comboBoxType.Items.Add(row.group_type_name);
        if (m_comboBoxType.Items.Count > 0)
            m_comboBoxType.SelectedIndex = 0;
    }
    private void Apply()
    {
        if (m_textBoxName.Text == string.Empty)
            throw new ApplicationException("Поле \"Наименование группы\" пусто.");

        CollegeDataSet.GroupTypesRow row = m_groupTypesTable[m_comboBoxType.SelectedIndex];
        m_college.AdapterManager.GroupsTableAdapter.Insert(m_textBoxName.Text, row.group_type_id);
    }
}
