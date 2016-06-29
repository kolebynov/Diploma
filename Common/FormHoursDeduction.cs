using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class FormHoursDeduction : Form
{
    public FormHoursDeduction(
        CollegeDataSet.SemestersLengthDataTable semesterLengthTable, 
        CollegeDataSet.PlansDataTable plansTable, 
        CollegeDataSet.SemestersDataTable semesterTable, 
        College college, CollegeDataSet.GroupsRow groupInfo)
    {
        CreateHoursWeekTable(plansTable, semesterTable);
        m_groupInfo = groupInfo;
        m_semesterLengthTable = semesterLengthTable;
        m_college = college;
        m_subjectsTable = new CollegeDataSet.SubjectsDataTable();

        InitializeComponent();
        LoadSemesters();
    }

    private CollegeDataSet.SemestersLengthDataTable m_semesterLengthTable;
    private CollegeDataSet.SubjectsDataTable m_subjectsTable;
    private DataTable m_hoursWeekTable;
    private College m_college;
    private CollegeDataSet.GroupsRow m_groupInfo;
    private bool m_needCalculate = true;

    private void ComboBoxSemestersSelectedIndexChangedHandler(object sender,
        EventArgs e) =>
        LoadSubjects();
    private void ButtonCalculateClickHandler(object sender, EventArgs e) =>
        Calculate();
    private void DataGridDeductionCellValueChangedHandler(object sender,
        DataGridViewCellEventArgs e) =>
        m_needCalculate = true;
    private void ButtonExcelClickHandler(object sender, EventArgs e)
    {
        if (m_needCalculate)
        {
            MyMessageBox.ShowError("Перед экспортом нужно нажать кнопку \"Рассчитать\".");
            return;
        }
        
        ToExcel();
    }   
    private void DataGridDeductionCellClickHandler(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 1)
            m_dataGridDeduction.EditMode = DataGridViewEditMode.EditProgrammatically;
        else
            m_dataGridDeduction.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
    }

    private void CreateHoursWeekTable(CollegeDataSet.PlansDataTable plansTable,
        CollegeDataSet.SemestersDataTable semesterTable)
    {
        m_hoursWeekTable = new DataTable();
        m_hoursWeekTable.Columns.Add("plan_record_id", typeof(int));
        m_hoursWeekTable.Columns.Add("subject_id", typeof(int));
        m_hoursWeekTable.Columns.Add("hours_per_week", typeof(short));
        m_hoursWeekTable.Columns.Add("semester_number", typeof(short));
        var rows = plansTable.Join(semesterTable, planRow => planRow.plan_record_id,
            semesterRow => semesterRow.plan_record_id, (planRow, semesterRow) =>
            {
                DataRow newRow = m_hoursWeekTable.NewRow();
                newRow.SetField("plan_record_id", planRow.plan_record_id);
                newRow.SetField("subject_id", planRow.subject_id);
                newRow.SetField("hours_per_week", semesterRow.hours_per_week);
                newRow.SetField("semester_number", semesterRow.semester_number);
                return newRow;
            });

        foreach (var row in rows)
            m_hoursWeekTable.Rows.Add(row);
    }
    private void LoadSemesters()
    {
        m_comboBoxSemesters.Items.Clear();
        m_comboBoxSemesters.Items.AddRange(m_semesterLengthTable.Select(row =>
            (object)row.semester_number).ToArray());
        if (m_comboBoxSemesters.Items.Count > 0)
            m_comboBoxSemesters.SelectedIndex = 0;
    }
    private void LoadSubjects()
    {
        m_dataGridDeduction.Rows.Clear();
        m_subjectsTable.Clear();
        short semesterNumber = (short)m_comboBoxSemesters.SelectedItem;
        m_subjectsTable = m_college.GetSubjectsInSemester(m_groupInfo.group_id, 
            semesterNumber);

        foreach (var subjectRow in m_subjectsTable)
            m_dataGridDeduction.Rows.Add(subjectRow.subject_name);
    }
    private void Calculate()
    {
        try
        {
            CheckDate();
            CheckActuallyHours();
            CalculateHoursAndDifference();
            m_needCalculate = false;
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);
        }
    }
    private void CheckDate()
    {
        if (m_dateStartSemester.Value > m_dateDeduction.Value)
            throw new ApplicationException("Дата начала семестра больше даты вычета.");
        double selectLength = ((m_dateDeduction.Value.Date - 
            m_dateStartSemester.Value.Date).Days) / 7.0;
        double semesterLength = m_semesterLengthTable.Where(row => 
            row.semester_number == (short)m_comboBoxSemesters.SelectedItem).
            First().length;
        if (selectLength > semesterLength)
        {
            throw new ApplicationException("Разница между датами больше чем " +
                "длина семестра.");
        }
    }
    private void CheckActuallyHours()
    {
        int temp;
        for (int i = 0; i < m_dataGridDeduction.RowCount; i++)
        {
            DataGridViewRow gridRow = m_dataGridDeduction.Rows[i];
            string value = (string)gridRow.Cells[1].Value;
            if (value != null && !int.TryParse(value, out temp))
            {
                throw new ApplicationException(string.Format("В строке {0} " +
                    "введено не число.", i + 1));
            }
        }
    }
    private void CalculateHoursAndDifference()
    {
        DataRow[] hoursWeekSemester = m_hoursWeekTable.Select("semester_number=" + 
            m_comboBoxSemesters.SelectedItem);
        for (int i = 0; i < m_dataGridDeduction.RowCount; i++)
        {
            DataGridViewRow gridRow = m_dataGridDeduction.Rows[i];
            string value = (string)gridRow.Cells[1].Value;
            if (value == null)
                continue;
            int actuallyHours = int.Parse(value);
            int mustBeHours = GetMustBeHours(hoursWeekSemester.Where(hourRow =>
                hourRow.Field<int>("subject_id") ==
                m_subjectsTable[i].subject_id).First().Field<short>("hours_per_week"));
            gridRow.Cells[2].Value = mustBeHours;
            gridRow.Cells[3].Value = (actuallyHours - mustBeHours).ToString("+#;-#;0");
        }
    }
    private int GetMustBeHours(short hoursPerWeek)
    {
        int weeks = (int)(((m_dateDeduction.Value.Date -
            m_dateStartSemester.Value.Date).Days + 1) / 7.0 + 0.5);
        return weeks * hoursPerWeek;
    }
    private void ToExcel()
    {
        ExcelWorker exc = new ExcelWorker();
        exc.SetText(1, 4, string.Format("Вычет часов за {0} семестр группы {1}.", 
            m_comboBoxSemesters.SelectedItem, m_groupInfo.group_name));
        var dataGridForExcel = GetDataGridForExcel();
        exc.WriteDataGrid(dataGridForExcel);
        exc.SetColumnWidth(1, 1, 40);
        exc.WrapText(1, 1, dataGridForExcel.RowCount, 1, true);      
        exc.Visible = true;
        exc.Dispose();
    }
    private DataGridView GetDataGridForExcel()
    {
        DataGridView temp = new DataGridView();
        foreach (DataGridViewColumn column in m_dataGridDeduction.Columns)
            temp.Columns.Add((DataGridViewColumn)column.Clone());
        foreach (DataGridViewRow row in m_dataGridDeduction.Rows)
        {
            if (row.Cells[1].Value != null)
            {
                temp.Rows.Add(row.Cells[0].Value, row.Cells[1].Value,
                    row.Cells[2].Value, row.Cells[3].Value);
            }
        }

        return temp;
    }
}
