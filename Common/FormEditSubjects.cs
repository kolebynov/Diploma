using System;
using System.Collections.Generic;
using Common;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

public partial class FormEditSubjects : Form
{
    public FormEditSubjects(SubjectsTableAdapter adapter)
    {
        m_adapter = adapter;
        m_table = new CollegeDataSet.SubjectsDataTable();

        InitializeComponent();
        InitList();
        LoadSubjects();
    }

    private ListContainer<TextBoxSubject> m_listSubjects;
    private SubjectsTableAdapter m_adapter;
    private CollegeDataSet.SubjectsDataTable m_table;

    private void ButtonAddClickHandler(object sender, EventArgs e) =>
        AddSubject();
    private void ButtonDeleteClickHandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowDelete() == DialogResult.Yes)
            DeleteSubject();
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
        m_listSubjects = new ListContainer<TextBoxSubject>();
        int height = new TextBoxSubject().Height;
        Controls.Add(m_listSubjects);
        m_listSubjects.Init(height + 2, new Point(0, 0), "m_listSubjects",
            new Size(ClientSize.Width, ClientSize.Height - m_panelButtons.Height), 3, 5);
        m_listSubjects.Anchor = AnchorStyles.Bottom | AnchorStyles.Left |
            AnchorStyles.Right | AnchorStyles.Top;
    }
    private void LoadSubjects()
    {
        m_table.Clear();
        m_adapter.Fill(m_table);
        
        foreach (var subjectRow in m_table)
        {
            var subjectBox = AddSubject();
            subjectBox.SubjectID = subjectRow.subject_id;
            subjectBox.SubjectName = subjectRow.subject_name;
            subjectBox.IsChanged = false;
        }
    }
    private TextBoxSubject AddSubject()
    {
        TextBoxSubject temp = new TextBoxSubject();
        temp.SubjectID = -1;
        temp.IsChanged = false;
        m_listSubjects.Add(temp);

        return temp;
    }
    private void DeleteSubject()
    {
        var selectedSubject = m_listSubjects.SelectedElement;
        if (selectedSubject != null)
        {
            m_table.Where(row => row.RowState != DataRowState.Deleted && 
                row.subject_id == 
                selectedSubject.SubjectID).FirstOrDefault()?.Delete();

            m_listSubjects.DeleteSelected();
        }
    }
    private bool Apply()
    {
        try
        {
            CheckSubjects();
            foreach (var subjectBox in m_listSubjects)
            {
                if (subjectBox.SubjectID == -1)
                    m_table.AddSubjectsRow(subjectBox.SubjectName);
                else if (subjectBox.IsChanged)
                    UpdateSubjectInTable(subjectBox);
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
    private void CheckSubjects()
    {
        for (int i = 0; i < m_listSubjects.Count; i++)
        {
            var subjectBox = m_listSubjects[i];
            if (subjectBox.SubjectName == string.Empty)
            {
                throw new ApplicationException(string.Format(
                    Resource1.ListErrorFormat, i + 1,
                    "Наименование дисциплины пусто."));
            }
        }
    }
    private void UpdateSubjectInTable(TextBoxSubject subjectBox)
    {
        var updateRow = m_table.Where(row => row.RowState != 
            DataRowState.Deleted && row.subject_id == subjectBox.SubjectID).First();
        updateRow.subject_name = subjectBox.SubjectName;
    }
}
