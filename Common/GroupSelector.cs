using System;
using System.Windows.Forms;

public partial class GroupSelector : UserControl
{
    /// <summary>
    /// Информация о группе.
    /// </summary>
    public CollegeDataSet.GroupsRow GroupInfo
    {
        get { return m_groupInfo; }
        set
        {
            if (value != null)
            {
                if (value.group_type_id != GroupTypeId)
                    throw new ArgumentException("Код типа группы не совпадает.");

                if (value.group_name == string.Empty || value.group_name == null)
                    m_textBoxGroup.Text = "Группа не выбрана";
                else
                    m_textBoxGroup.Text = value.group_name;
            }
            else
                m_textBoxGroup.Text = "Группа не выбрана";

            var old = m_groupInfo;
            m_groupInfo = value;
            if (old != value)
                GroupChanged?.Invoke(this, new EventArgs());       
        }
    }
    public short GroupTypeId { get; set; }
    public College College { get; set; }

    public event EventHandler GroupChanged;

    public GroupSelector(short groupTypeId, CollegeDataSet.GroupsRow data, 
        College college)
    {
        InitializeComponent();

        GroupInfo = data;
        College = college;
    }
    public GroupSelector() : this(0, null, null)
    { }

    private CollegeDataSet.GroupsRow m_groupInfo;

    private void ButtonChangeGroupClickHandler(object sender, EventArgs e)
    {
        if (College == null || GroupTypeId == -1)
            return;

        var form = new FormSelect(College.GetGroupsByGroupTypeId(GroupTypeId));
        form.DataGrid.MultiSelect = false;
        form.ItemSelected += (sender2, e2) =>
            GroupInfo = e2.SelectedRows[0] as CollegeDataSet.GroupsRow;
        form.DataGrid.Columns[0].Visible = false;
        form.DataGrid.Columns[2].Visible = false;
        form.DataGrid.Columns[1].HeaderText = "Наименование группы";

        form.ShowDialog();
    }
    private void ButtonResetClickHandler(object sender, EventArgs e) =>
        GroupInfo = null;
}
