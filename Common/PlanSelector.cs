using System;
using System.Windows.Forms;

public partial class PlanSelector : UserControl
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
                    m_textBoxGroup.Text = "План не выбран";
                else
                    m_textBoxGroup.Text = value.group_name;
            }
            else
                m_textBoxGroup.Text = "План не выбран";

            var old = m_groupInfo;
            m_groupInfo = value;
            if (old != value)
                GroupChanged?.Invoke(this, new EventArgs());
        }
    }
    public short GroupTypeId { get; set; }
    public College College { get; set; }

    public event EventHandler GroupChanged;

    public PlanSelector(short groupTypeId, CollegeDataSet.GroupsRow data,
        College college)
    {
        InitializeComponent();

        GroupInfo = data;
        College = college;
    }
    public PlanSelector() : this(0, null, null)
    { }

    private CollegeDataSet.GroupsRow m_groupInfo;

    private void ButtonChangeGroupClickHandler(object sender, EventArgs e)
    {
        if (College == null || GroupTypeId == -1)
            return;

        var form = new FormSelect(College.GetPlanNamesByGroupTypeId(GroupTypeId));
        form.DataGrid.MultiSelect = false;
        form.ItemSelected += (sender2, e2) =>
            GroupInfo = e2.SelectedRows[0] as CollegeDataSet.GroupsRow;
        form.DataGrid.Columns[0].Visible = false;
        form.DataGrid.Columns[2].Visible = false;
        form.DataGrid.Columns[1].HeaderText = "Наименование плана";

        form.ShowDialog();
    }
    private void ButtonResetClickHandler(object sender, EventArgs e) =>
        GroupInfo = null;
}
