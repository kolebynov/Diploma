using System;
using System.Collections.Generic;
using System.Transactions;
using System.Data;
using System.Drawing;
using System.Linq;
using Common;
using System.Windows.Forms;

public partial class FormEditGroupTypes : Form
{
    public FormEditGroupTypes(College college)
    {
        m_college = college;
        m_groupTypesTable = new CollegeDataSet.GroupTypesDataTable();

        InitializeComponent();
        InitList();
        LoadGroupTypes();
    }

    private ListContainer<TextBoxGroupType> m_listGroupTypes;
    private College m_college;
    private CollegeDataSet.GroupTypesDataTable m_groupTypesTable;

    private void ButtonAddClickHandler(object sender, EventArgs e) =>
        AddGroupType();
    private void ButtonDeleteClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowDelete() == DialogResult.Yes)
            DeleteGroupType();
    }
    private void ButtonCancelClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowCloseForm() == DialogResult.Yes)
            Close();
    }
    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        if (Apply())
            Close();
    }

    private void InitList()
    {
        m_listGroupTypes = new ListContainer<TextBoxGroupType>();
        int height = new TextBoxGroupType().Height;
        Controls.Add(m_listGroupTypes);
        m_listGroupTypes.Init(height + 2, new Point(0, 25), "m_listOffices",
            new Size(ClientSize.Width, ClientSize.Height - m_panelButtons.Height - 25), 3, 5);
        m_listGroupTypes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | 
            AnchorStyles.Right | AnchorStyles.Top;     
    }
    private void LoadGroupTypes()
    {
        m_college.AdapterManager.GroupTypesTableAdapter.Fill(m_groupTypesTable);

        foreach (var row in m_groupTypesTable)
        {
            var groupType = AddGroupType();
            groupType.GroupTypeID = row.group_type_id;
            groupType.TypeName = row.group_type_name;
            groupType.IsChanged = false;
        }
    }
    private TextBoxGroupType AddGroupType()
    {
        var groupType = new TextBoxGroupType();
        m_listGroupTypes.Add(groupType);
        groupType.GroupTypeID = -1;
        groupType.IsChanged = false;

        return groupType;
    }
    private void DeleteGroupType()
    {
        var selectedGroupType = m_listGroupTypes.SelectedElement;
        if (selectedGroupType != null)
        {
            int id = selectedGroupType.GroupTypeID;
            m_listGroupTypes.DeleteSelected();
            if (id > -1)
            {
                var deleteRow = m_groupTypesTable.Where(row => row.RowState != 
                    DataRowState.Deleted && row.group_type_id == id).First();
                deleteRow.Delete();
            }
        }
    }
    private bool Apply()
    {
        try
        {
            CheckGroupTypes();
            foreach (var groupType in m_listGroupTypes)
            {
                if (groupType.GroupTypeID == -1)
                    m_groupTypesTable.AddGroupTypesRow(groupType.TypeName);
                else if (groupType.IsChanged)
                    UpdateGroupTypeInTable(groupType);
            }

            DeleteGroups();
            using (TransactionScope scope = 
                new TransactionScope(TransactionScopeOption.Required))
            {
                m_college.AdapterManager.GroupTypesTableAdapter.Update(m_groupTypesTable);
                scope.Complete();
            }

            return true;
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);

            return false;
        }
    }
    private void CheckGroupTypes()
    {
        for (int i = 0; i < m_listGroupTypes.Count; i++)
        {
            var groupType = m_listGroupTypes[i];
            if (groupType.TypeName == string.Empty)
            {
                throw new ApplicationException(string.Format(
                    Resource1.ListErrorFormat, i + 1, "Название отделения пусто."));
            }
        }
    }
    private void UpdateGroupTypeInTable(TextBoxGroupType groupType)
    {
        var updateRow = m_groupTypesTable.Where(row => row.RowState != 
            DataRowState.Deleted && row.group_type_id == groupType.GroupTypeID).First();
        updateRow.group_type_name = groupType.TypeName;
    }
    private void DeleteGroups()
    {
        foreach (var groupTypeRow in m_groupTypesTable)
        {
            if (groupTypeRow.RowState == DataRowState.Deleted)
            {
                groupTypeRow.RejectChanges();
                var groupTable = m_college.GetGroupsByGroupTypeId(
                    groupTypeRow.group_type_id);
                foreach (var groupRow in groupTable)
                    m_college.DeleteGroup(groupRow.group_id);
                groupTable.Dispose();
                groupTypeRow.Delete();
            }
        }
    }
}
