using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class FormCopyPlan : Form
    {
        public int GroupIdForCopy { get; private set; } = -1;

        public FormCopyPlan(College college, short groupTypeId)
        {
            m_college = college;
            m_groupTypeId = groupTypeId;

            InitializeComponent();
        }

        private College m_college;
        private short m_groupTypeId;

        private void ButtonOKClickHandler(object sender, EventArgs e)
        {
            var groupsTable = m_radioGroupPlan.Checked ? 
                m_college.GetGroupsByGroupTypeId(m_groupTypeId) : 
                m_college.GetPlanNamesByGroupTypeId(m_groupTypeId);
            var form = new FormSelect(groupsTable);
            form.DataGrid.MultiSelect = false;
            form.ItemSelected += (sender2, e2) =>
            {
                GroupIdForCopy = ((CollegeDataSet.GroupsRow)e2.SelectedRows[0]).group_id;
                Close();
            };
            form.DataGrid.Columns[0].Visible = false;
            form.DataGrid.Columns[2].Visible = false;
            form.DataGrid.Columns[1].HeaderText = m_radioGroupPlan.Checked ? 
                "Наименование группы" : "Наименование плана";
            form.ShowDialog();
        }
    }
}
