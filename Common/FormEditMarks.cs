using System;
using System.Collections.Generic;
using System.Transactions;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class FormEditMarks : Form
{
    public GroupSelector GroupSelector { get { return m_groupSelector; } }

    public FormEditMarks(College college)
    {
        m_college = college;

        InitializeComponent();

        m_groupSelector.College = college;
        m_dataSet = new CollegeDataSet();
    }
    public FormEditMarks() : this(null)
    { }

    private College m_college;
    private CollegeDataSet m_dataSet;

    private void GroupSelectorGroupChangedHandler(object sender, EventArgs e)
    {
        if (m_groupSelector.GroupInfo == null)
        {
            Reset();
            return;
        }
        LoadStudents();
        LoadSemesters();
    }
    private void DataGridMarksCellClickHandler(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0 || e.RowIndex == 0)
            m_dataGridMarks.EditMode = DataGridViewEditMode.EditProgrammatically;
        else
            m_dataGridMarks.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
    }
    private void DataGridMarksCellValidatingHandler(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex > m_dataGridMarks.ColumnCount - 3)
        {
            e.Cancel = !AddSkipToDataSet((string)e.FormattedValue, e.ColumnIndex,
                e.RowIndex);
        }
        else
        {
            e.Cancel = !AddMarkToDataSet((string)e.FormattedValue, e.ColumnIndex,
                e.RowIndex);
        }
    }
    private void ComboBoxSemestersSelectedIndexChangedHandler(object sender,
        EventArgs e)
    {
        LoadMarksAndSkips();
    }
    private void ButtonApplyClickHandler(object sender, EventArgs e) =>
        Apply();
    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        Apply();
        Close();
    }
    private void Apply()
    {
        using (TransactionScope scope =
            new TransactionScope(TransactionScopeOption.Required))
        {
            m_college.AdapterManager.MarksTableAdapter.Update(m_dataSet);
            m_college.AdapterManager.SkipsTableAdapter.Update(m_dataSet);
            scope.Complete();
        }
    }
    private void ButtonExcelClickHandler(object sender, EventArgs e)
    {
        if (m_comboBoxSemesters.SelectedItem != null)
            ToExcel();
    }
    private void ButtonCancelClickhandler(object sender, EventArgs e)
    {
        if (MyMessageBox.ShowCloseForm() == DialogResult.Yes)
            Close();
    }
    private void ButtonAwardClickHandler(object sender, EventArgs e)
    {
        if (m_comboBoxSemesters.SelectedItem != null)
            ToExcelAward();
    }

    private void LoadStudents()
    {
        Reset();
        var studentsTable = m_college.GetStudentsByGroup(
            m_groupSelector.GroupInfo.group_id);
        m_dataSet.Students.Load(studentsTable.CreateDataReader());
        studentsTable.Dispose();
        var plansTable = m_college.GetPlansByGroup(m_groupSelector.GroupInfo.group_id);
        m_dataSet.Plans.Load(plansTable.CreateDataReader());
        plansTable.Dispose();

        foreach (var row in m_dataSet.Students)
        {
            m_dataGridMarks.Rows.Add(string.Format("{0} {1}.{2}.",
                row.second_name, row.first_name.Substring(0, 1),
                row.middle_name.Substring(0, 1)));
        }
    }
    private void Reset()
    {
        m_dataSet.Students.Clear();
        m_dataSet.Plans.Clear();
        m_dataGridMarks.Rows.Clear();
        m_dataGridMarks.ColumnCount = 1;
        m_dataGridMarks.Rows.Add();
    }
    private void LoadSemesters()
    {
        var table = m_college.GetSemestersLengthByGroup(
            m_groupSelector.GroupInfo.group_id);

        m_comboBoxSemesters.Items.Clear();
        m_comboBoxSemesters.Items.AddRange(table.Select(row =>
            (object)row.semester_number).ToArray());
        if (m_comboBoxSemesters.Items.Count > 0)
            m_comboBoxSemesters.SelectedIndex = 0;

        table.Dispose();
    }
    private void LoadMarksAndSkips()
    {
        m_dataGridMarks.ColumnCount = 1;
        m_dataSet.Marks.Clear();
        m_dataSet.Subjects.Clear();
        m_dataSet.Skips.Clear();
        int groupId = m_groupSelector.GroupInfo.group_id;
        short semester = (short)m_comboBoxSemesters.SelectedItem;
        var marksTable = m_college.GetMarksInSemester(groupId, semester);
        m_dataSet.Marks.Load(marksTable.CreateDataReader());
        marksTable.Dispose();
        var skipsTable = m_college.GetSkipsInSemester(groupId, semester);
        m_dataSet.Skips.Load(skipsTable.CreateDataReader());
        skipsTable.Dispose();
        var subjectsTable = m_college.GetSubjectsInSemester(
            m_groupSelector.GroupInfo.group_id,
            (short)m_comboBoxSemesters.SelectedItem);
        m_dataSet.Subjects.Load(subjectsTable.CreateDataReader());
        subjectsTable.Dispose();

        int i;
        for (i = 0; i < m_dataSet.Subjects.Count; i++)
        {
            var row = m_dataSet.Subjects[i];
            m_dataGridMarks.Columns.Add(row.subject_name, row.subject_name);
            m_dataGridMarks[i + 1, 0].Value = row.subject_name;
        }
        m_dataGridMarks.Columns.Add("Всего пропусков", "Всего пропусков");
        m_dataGridMarks[i + 1, 0].Value = "Всего пропусков";
        m_dataGridMarks.Columns.Add("Пропусков по Н/У причине", "Пропусков по Н/У причине");
        m_dataGridMarks[i + 2, 0].Value = "Пропусков по Н/У причине";

        foreach (var row in m_dataSet.Marks)
        {
            int rowIndex = GetRowIndex(row.student_id);
            int columnIndex = GetColumnIndex(row.plan_record_id);
            m_dataGridMarks[columnIndex, rowIndex].Value = ((Mark)row.mark).ToString();
        }
        int column = m_dataGridMarks.ColumnCount - 2;
        foreach (var row in m_dataSet.Skips)
        {
            int rowIndex = GetRowIndex(row.student_id);
            if (!row.Isskip_countNull())
                m_dataGridMarks[column, rowIndex].Value = row.skip_count;
            if (!row.Isdisrespectfully_skip_countNull())
                m_dataGridMarks[column + 1, rowIndex].Value =
                    row.disrespectfully_skip_count;
        }
    }
    private int GetRowIndex(int studentId)
    {
        for (int i = 0; i < m_dataSet.Students.Count; i++)
        {
            if (m_dataSet.Students[i].student_id == studentId)
                return i + 1;
        }

        return -1;
    }
    private int GetColumnIndex(int planId)
    {
        int subjectId = m_dataSet.Plans.FindByplan_record_id(planId).subject_id;
        for (int i = 0; i < m_dataSet.Subjects.Count; i++)
        {
            if (subjectId == m_dataSet.Subjects[i].subject_id)
                return i + 1;
        }

        return -1;
    }
    private bool AddMarkToDataSet(string markStr, int columnIndex, int rowIndex)
    {
        try
        {
            if (columnIndex == 0 || rowIndex == 0)
                return true;

            int studentId = m_dataSet.Students[rowIndex - 1].student_id;
            int subjectId = m_dataSet.Subjects[columnIndex - 1].subject_id;
            int planId = m_dataSet.Plans.Where(row => row.subject_id ==
                subjectId).First().plan_record_id;
            var markRow = m_dataSet.Marks.Where(row => row.RowState !=
                DataRowState.Deleted && row.student_id == studentId &&
                row.plan_record_id == planId).FirstOrDefault();
            if (markRow == null)
            {
                if (markStr == string.Empty)
                    return true;
                else
                {
                    Mark mark = new Mark(markStr);
                    var newMarkRow = m_dataSet.Marks.NewMarksRow();
                    newMarkRow.mark = mark;
                    newMarkRow.mark_type_id = 0;
                    newMarkRow.plan_record_id = planId;
                    newMarkRow.semester_number =
                        (short)m_comboBoxSemesters.SelectedItem;
                    newMarkRow.student_id = studentId;
                    m_dataSet.Marks.AddMarksRow(newMarkRow);
                }
            }
            else
            {
                if (markStr == string.Empty)
                    markRow.Delete();
                else
                {
                    Mark mark = new Mark(markStr);
                    markRow.mark = mark;
                }
            }

            return true;
        }
        catch (ArgumentException exc)
        {
            MyMessageBox.ShowError(exc.Message);

            return false;
        }
    }
    private bool AddSkipToDataSet(string skipStr, int columnIndex, int rowIndex)
    {
        if (columnIndex == 0 || rowIndex == 0)
            return true;

        try
        {
            int studentId = m_dataSet.Students[rowIndex - 1].student_id;
            var skipRow = m_dataSet.Skips.Where(row => row.RowState !=
                DataRowState.Deleted && row.student_id == studentId).FirstOrDefault();

            short skips = 0;
            if (skipStr != string.Empty)
            {
                if (!short.TryParse(skipStr, out skips))
                    throw new ApplicationException("Введенная строка не является числом");
                if (skips < 0)
                    throw new ApplicationException("Введенное число меньше 0.");
            }
            bool disrespect = columnIndex == m_dataGridMarks.ColumnCount - 1 ?
                true : false;
            if (skipRow == null)
            {
                if (skipStr == string.Empty)
                    return true;
                var newSkipRow = m_dataSet.Skips.NewSkipsRow();
                if (!disrespect)
                    newSkipRow.skip_count = skips;
                else
                    newSkipRow.disrespectfully_skip_count = skips;
                newSkipRow.semester_number = (short)m_comboBoxSemesters.SelectedItem;
                newSkipRow.student_id = studentId;
                m_dataSet.Skips.AddSkipsRow(newSkipRow);
            }
            else
            {
                if (skipStr == string.Empty)
                {
                    if (!disrespect)
                        skipRow.Setskip_countNull();
                    else
                        skipRow.Setdisrespectfully_skip_countNull();
                    if (skipRow.Isdisrespectfully_skip_countNull() &&
                        skipRow.Isskip_countNull())
                        skipRow.Delete();
                }
                else
                {
                    if (!disrespect)
                        skipRow.skip_count = skips;
                    else
                        skipRow.disrespectfully_skip_count = skips;
                    if (!skipRow.Isdisrespectfully_skip_countNull() &&
                        !skipRow.Isskip_countNull() &&
                        skipRow.disrespectfully_skip_count > skipRow.skip_count)
                    {
                        throw new ApplicationException("Количество пропусков не " +
                            "может быть меньше, чем пропусков по Н/У причине.");
                    }
                }
            }

            return true;
        }
        catch (ApplicationException exc)
        {
            MyMessageBox.ShowError(exc.Message);
            return false;
        }
    }
    private void ToExcel()
    {
        int columnCount = m_dataGridMarks.ColumnCount;
        using (ExcelWorker excel = new ExcelWorker())
        {
            excel.SetText(1, columnCount, GetExcelText());
            excel.WrapText(1, 1, m_dataGridMarks.RowCount,
                columnCount, true);
            excel.SetColumnWidth(1, 1, 20);
            excel.WriteDataGrid(m_dataGridMarks);
            excel.Orientation90(2, 2, 1, columnCount - 1);
            excel.SkipRow();
            excel.SetText(columnCount - 2, 1, "Всего");
            excel.SetText(columnCount - 1, 1, GetSumSkips().ToString());
            excel.SetText(columnCount, 1, GetSumDisrespectSkips().ToString());
            excel.WriteDataGrid(GetMarksCountDataDrid());
            excel.Visible = true;
        }
    }
    private string GetExcelText()
    {
        short semester = (short)m_comboBoxSemesters.SelectedItem;
        short kurs = (short)(semester / 2.0 + 0.5);

        return string.Format("Сводная ведомость успеваемости учащихся " +
            "{0} курса группы {1} за {2} семестр", kurs,
            m_groupSelector.GroupInfo.group_name, semester);
    }
    private int GetSumSkips()
    {
        return m_dataSet.Skips.Sum(row => row.skip_count);
    }
    private int GetSumDisrespectSkips()
    {
        return m_dataSet.Skips.Sum(row => row.disrespectfully_skip_count);
    }
    private DataGridView GetMarksCountDataDrid()
    {
        DataGridView gridCountMarks = new DataGridView();
        gridCountMarks.ColumnCount = m_dataGridMarks.ColumnCount - 2;
        gridCountMarks.Rows.Add("\"10-9\"");
        gridCountMarks.Rows.Add("\"8-7\"");
        gridCountMarks.Rows.Add("\"6-4\"");
        gridCountMarks.Rows.Add("\"3-0\"");
        gridCountMarks.Rows.Add("Не аттестовано");
        gridCountMarks.Rows.Add("Всего");

        int[][] marks = GetCountMarksInSubject();
        for (int i = 0; i < marks.GetLength(0); i++)
        {
            int sum910 = marks[i].Where((val, index) => index > 8 && 
                index < 11).Sum();
            int sum87 = marks[i].Where((val, index) =>
                index > 6 && index < 9).Sum();
            int sum64 = marks[i].Where((val, index) =>
               index > 3 && index < 7).Sum();
            int sum30 = marks[i].Where((val, index) => index < 4).Sum();
            if (sum910 > 0)
                gridCountMarks[i + 1, 0].Value = sum910;
            if (sum87 > 0)
                gridCountMarks[i + 1, 1].Value = sum87;
            if (sum64 > 0)
                gridCountMarks[i + 1, 2].Value = sum64;
            if (sum30 > 0)
                gridCountMarks[i + 1, 3].Value = sum30;
            if (marks[i][11] > 0)
                gridCountMarks[i + 1, 4].Value = marks[i][11];
            gridCountMarks[i + 1, 5].Value = marks[i].Sum();
        }

        return gridCountMarks;
    }
    private int[][] GetCountMarksInSubject()
    {
        int[][] temp = new int[m_dataSet.Subjects.Count][];

        for (int i = 0; i < m_dataSet.Subjects.Count; i++)
        {
            temp[i] = new int[12];
            for (int j = 1; j < m_dataGridMarks.RowCount; ++j)
            {
                DataGridViewRow row = m_dataGridMarks.Rows[j];
                short mark;
                if (row.Cells[i + 1].Value == null)
                    temp[i][11]++;
                else if (short.TryParse(row.Cells[i + 1].Value.ToString(), out mark) &&
                    mark >= 0)
                    temp[i][mark]++;
            }
        }

        return temp;
    }
    private void ToExcelAward()
    {
        using (ExcelWorker excel = new ExcelWorker())
        {
            excel.SetText(1, 13, GetExcelTextAward());
            excel.WrapText(1, 1, m_dataSet.Students.Count + 1, 13, true);
            excel.SetColumnWidth(2, 13, 15);
            excel.SetColumnWidth(1, 1, 4);
            excel.WriteDataGrid(GetAwardDataGrid());
            excel.Visible = true;
        }
    }
    private string GetExcelTextAward()
    {
        short semester = (short)m_comboBoxSemesters.SelectedItem;
        short kurs = (short)(semester / 2.0 + 0.5);

        return string.Format("Ведомость для назначения стипендии. {0} курс, " +
            "группа {1}, {2} семестр", kurs, m_groupSelector.GroupInfo.group_name, 
            semester);
    }
    private DataGridView GetAwardDataGrid()
    {
        DataGridView awardDataGrid = CreateAwardDataGrid();
        for (int i = 0; i < m_dataSet.Students.Count; ++i)
        {
            awardDataGrid.Rows.Add();
            var studentRow = m_dataSet.Students[i];
            awardDataGrid[0, i].Value = i + 1;
            awardDataGrid[1, i].Value = string.Format("{0} {1}.{2}", 
                studentRow.second_name, studentRow.first_name.Substring(0, 1), 
                studentRow.middle_name.Substring(0, 1));
            Tuple<int, int[]> countMarks = GetCountMarks(studentRow.student_id);
            awardDataGrid[2, i].Value = countMarks.Item1;
            for (int j = 4; j < 11; ++j)
            {
                if (countMarks.Item2[j] > 0)
                    awardDataGrid[j - 1, i].Value = countMarks.Item2[j];
                else
                    awardDataGrid[j - 1, i].Value = "-";
            }
            int badMarks = countMarks.Item2.Where((count, index) => index < 4).Sum();
            badMarks += countMarks.Item2[11];
            if (badMarks == 0 && countMarks.Item2[12] == 0)
            {
                int sum = countMarks.Item2.Select((count, index) => count * index).Sum();
                double average = ((double)sum) / countMarks.Item1;
                double ratio = 1.0;
                awardDataGrid[10, i].Value = sum;
                awardDataGrid[11, i].Value = !double.IsNaN(average) ? average : 0.0;
                if (average > 8.0)
                    ratio = 1.4;
                else if (average > 6.0)
                    ratio = 1.2;
                awardDataGrid[12, i].Value = ratio;
            }
            else if (badMarks > 2)
                awardDataGrid[12, i].Value = "На отчисление";
            else if (badMarks > 0)
                awardDataGrid[12, i].Value = "Задолженик";
        }

        return awardDataGrid;
    }
    private DataGridView CreateAwardDataGrid()
    {
        DataGridView awardDataGrid = new DataGridView();
        awardDataGrid.ColumnHeadersVisible = true;
        awardDataGrid.Columns.Add("№", "№");
        awardDataGrid.Columns.Add("Ф.,и.,о.", "Ф.,и.,о.");
        awardDataGrid.Columns.Add("Количество предметов", "Количество предметов");
        awardDataGrid.Columns.Add("Количество \"4\"", "Количество \"4\"");
        awardDataGrid.Columns.Add("Количество \"5\"", "Количество \"5\"");
        awardDataGrid.Columns.Add("Количество \"6\"", "Количество \"6\"");
        awardDataGrid.Columns.Add("Количество \"7\"", "Количество \"7\"");
        awardDataGrid.Columns.Add("Количество \"8\"", "Количество \"8\"");
        awardDataGrid.Columns.Add("Количество \"9\"", "Количество \"9\"");
        awardDataGrid.Columns.Add("Количество \"10\"", "Количество \"10\"");
        awardDataGrid.Columns.Add("Сумма баллов", "Сумма баллов");
        awardDataGrid.Columns.Add("Средний балл", "Средний балл");
        awardDataGrid.Columns.Add("Вид стипендии и повыш. коэффициент",
            "Вид стипендии и повыш. коэффициент");

        return awardDataGrid;
    }
    private Tuple<int, int[]> GetCountMarks(int studentId)
    {
        int countSubjects = 0;
        int[] countMarks = new int[13];
        countMarks.Initialize();
        int count = 0;
        foreach (var markRow in m_dataSet.Marks)
        {
            if (markRow.student_id == studentId)
            {
                if (markRow.mark > -1)
                {
                    countSubjects++;
                    countMarks[markRow.mark]++;
                }
                else if (markRow.mark < -2)
                    countMarks[11]++;
                count++;
            }
        }
        countMarks[12] = m_dataSet.Subjects.Count - count;

        return new Tuple<int, int[]>(countSubjects, countMarks);
    }
}
