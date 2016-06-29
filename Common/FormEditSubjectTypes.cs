using System;
using System.Collections.Generic;
using Common;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

public partial class FormEditSubjectTypes : Form
{
    public FormEditSubjectTypes(SubjectTypesTableAdapter adapter)
    {
        m_adapter = adapter;
        m_table = new CollegeDataSet.SubjectTypesDataTable();

        InitializeComponent();
        InitList();
        LoadSubjectTypes();
    }

    private ListContainer<SubjectTypeContainer> m_listSubjectTypes;
    private SubjectTypesTableAdapter m_adapter;
    private CollegeDataSet.SubjectTypesDataTable m_table;

    private void ButtonCancelClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowCloseForm() == DialogResult.Yes)
            Close();
    }
    private void ButtonAddClickHandler(object sender, EventArgs e) =>
        AddSubjectType();
    private void ButtonDeleteClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowDelete() == DialogResult.Yes)
            DeleteSubjectType();
    }
    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        if (Apply())
            Close();
    }

    private void InitList()
    {
        m_listSubjectTypes = new ListContainer<SubjectTypeContainer>();
        int height = new SubjectTypeContainer().Height;
        Controls.Add(m_listSubjectTypes);
        m_listSubjectTypes.Init(height + 2, new Point(0, 0), "m_listSubjects",
            new Size(ClientSize.Width, ClientSize.Height - m_panelButtons.Height), 3, 5);
        m_listSubjectTypes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left |
            AnchorStyles.Right | AnchorStyles.Top;
    }
    private void LoadSubjectTypes()
    {
        m_table.Clear();
        m_adapter.Fill(m_table);

        foreach (var subjectTypeRow in m_table)
        {
            var subjectTypeBox = AddSubjectType();
            subjectTypeBox.SubjectTypeID = subjectTypeRow.subject_type_id;
            subjectTypeBox.SubjectTypeName = subjectTypeRow.subject_type_name;
            subjectTypeBox.GlobalSubjectType = subjectTypeRow.subject_global_type;
            subjectTypeBox.IsChanged = false;
        }
    }
    private SubjectTypeContainer AddSubjectType()
    {
        SubjectTypeContainer temp = new SubjectTypeContainer();
        temp.SubjectTypeID = -1;
        temp.IsChanged = false;
        m_listSubjectTypes.Add(temp);

        return temp;
    }
    private void DeleteSubjectType()
    {
        var selectedSubject = m_listSubjectTypes.SelectedElement;
        if (selectedSubject != null)
        {
            m_table.Where(row => row.RowState != DataRowState.Deleted &&
                row.subject_type_id ==
                selectedSubject.SubjectTypeID).FirstOrDefault()?.Delete();

            m_listSubjectTypes.DeleteSelected();
        }
    }
    private bool Apply()
    {
        try
        {
            CheckSubjectTypes();
            foreach (var subjectTypeBox in m_listSubjectTypes)
            {
                if (subjectTypeBox.SubjectTypeID == -1)
                    m_table.AddSubjectTypesRow(subjectTypeBox.SubjectTypeName, 
                        subjectTypeBox.GlobalSubjectType);
                else if (subjectTypeBox.IsChanged)
                    UpdateSubjectTypeInTable(subjectTypeBox);
            }

            using (TransactionScope scope =
                new TransactionScope(TransactionScopeOption.Required))
            {
                m_adapter.Update(m_table);
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
    private void CheckSubjectTypes()
    {
        for (int i = 0; i < m_listSubjectTypes.Count; i++)
        {
            var subjectTypeBox = m_listSubjectTypes[i];
            if (subjectTypeBox.SubjectTypeName == string.Empty)
            {
                throw new ApplicationException(string.Format(
                    Resource1.ListErrorFormat, i + 1, "Имя типа пусто."));
            }
        }
    }
    private void UpdateSubjectTypeInTable(SubjectTypeContainer subjectBox)
    {
        var updateRow = m_table.Where(row => row.RowState !=
            DataRowState.Deleted && row.subject_type_id == 
            subjectBox.SubjectTypeID).First();
        updateRow.subject_type_name = subjectBox.SubjectTypeName;
        updateRow.subject_global_type = subjectBox.GlobalSubjectType;
    }
}

