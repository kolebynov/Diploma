using System;
using System.Collections.Generic;

using Excel = Microsoft.Office.Interop.Excel;

public class ExcelExporter
{
    public void CreateSemesterReport(College college, int group_id, short semester, 
        CollegeDataSet.PlansDataTable plansDataTable,
        CollegeDataSet.SubjectsDataTable subjectsDataTable,
        CollegeDataSet.GroupsDataTable groupDataTable,
        CollegeDataSet.StudentsDataTable studentDataTable,
        CollegeDataSet.MarksDataTable marksDataTable,
        CollegeDataSet.SemestersDataTable semesterDataTable)
    {
        var App = new Excel.Application();
        App.Workbooks.Add();

        Excel.Worksheet sheet = (Excel.Worksheet)App.ActiveSheet;

        int startY = 6;
        int startX = 1;
        int subjextStartIndex = 2;
        int subjectEndIndex = subjextStartIndex;
        int subjectsCount = 0;
        int studentCount = 0;

        List<int> plansIndices = new List<int>();

        for (int i = 0; i < plansDataTable.Count; i++)
        {
            short currentSemester = 0;

            for (int j = 0; j < semesterDataTable.Count; j++)
            {
                if (plansDataTable[i].plan_record_id == semesterDataTable[j].plan_record_id)
                {
                    currentSemester = semesterDataTable[j].semester_number;

                    if (plansDataTable[i].group_id == group_id && semester == currentSemester)
                    {
                        plansIndices.Add(plansDataTable[i].plan_record_id);
                        sheet.Cells[1 + startY, subjectEndIndex + startX] = subjectsDataTable.FindBysubject_id(plansDataTable[i].subject_id).subject_name;
                        subjectsCount++;
                        subjectEndIndex++;

                        break;
                    }
                }
            }    
        }

        subjectEndIndex = 2;

        for (int i = 0; i < studentDataTable.Count; i++)
        {
            if (studentDataTable[i].group_id == group_id)
            {
                sheet.Cells[subjectEndIndex + startY, 1 + startX] = 
                    studentDataTable[i].second_name + " " +
                    studentDataTable[i].first_name + " " +
                    studentDataTable[i].middle_name;

                studentCount++;

                sheet.Cells[startY + subjectEndIndex, 1] = subjectEndIndex - 1;

                subjectEndIndex++;

                for (int j = 0; j < subjectsCount; j++)
                {
                    for (int k = 0; k < marksDataTable.Count; k++)
                    {
                        if (marksDataTable[k].plan_record_id == plansIndices[j] && 
                            marksDataTable[k].student_id == studentDataTable[i].student_id &&
                            marksDataTable[k].semester_number == semester)
                        {
                            sheet.Cells[subjectEndIndex - 1 + startY, 2 + j + startX] = ((Mark)marksDataTable[k].mark).ToString();
                            break;
                        }
                    }
                }
            }
        }

        for (int i = 1; i <= 6; i++)
        {
            sheet.Range[sheet.Cells[i, 1], sheet.Cells[i, subjectsCount + subjextStartIndex + 1]].Merge();
            sheet.Range[sheet.Cells[i, 1], sheet.Cells[i, subjectsCount + subjextStartIndex + 1]].WrapText = true;
        }

        sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, subjectsCount + subjextStartIndex]] = "МИНИСТЕРСТВО ОБРАЗОВАНИЯ РЕСПУБЛИКИ БЕЛАРУСЬ";
        sheet.Range[sheet.Cells[2, 1], sheet.Cells[2, subjectsCount + subjextStartIndex]] = "(наименование органа государственного управления учреждением образования)";
        sheet.Range[sheet.Cells[3, 1], sheet.Cells[3, subjectsCount + subjextStartIndex]] = "УО \"ВИТЕБСКИЙ ГОСУДАРСТВЕННЫЙ ПОЛИТЕХНИЧЕСКИЙ КОЛЛЕДЖ\"";
        sheet.Range[sheet.Cells[4, 1], sheet.Cells[4, subjectsCount + subjextStartIndex]] = "(наименование учреждения образования)";
        sheet.Range[sheet.Cells[5, 1], sheet.Cells[5, subjectsCount + subjextStartIndex]] = "СВОДНАЯ ВЕДОМОСТЬ ИТОГОВОЙ УСПЕВАЕМОСТИ ";
        sheet.Range[sheet.Cells[6, 1], sheet.Cells[6, subjectsCount + subjextStartIndex]] = "УЧАЩИХСЯ ГРУППЫ " + groupDataTable.FindBygroup_id(group_id).group_name;

        sheet.Cells[1 + startY, startX + subjectsCount + subjextStartIndex] = "Средний балл";

        ((Excel.Range)sheet.Columns[1 + startX]).WrapText = true;
        ((Excel.Range)sheet.Rows[1 + startY]).WrapText = true;

        ((Excel.Range)sheet.Rows).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        ((Excel.Range)sheet.Rows).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        ((Excel.Range)sheet.Columns[1 + startX]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        ((Excel.Range)sheet.Rows[2 + startY]).EntireColumn.RowHeight = 30;
        ((Excel.Range)sheet.Rows[1 + startY]).RowHeight = 150;

        ((Excel.Range)sheet.Rows[1 + startY]).Orientation = 90;
        ((Excel.Range)sheet.Rows[1 + startY]).VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;
        ((Excel.Range)sheet.Rows[1 + startY]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        ((Excel.Range)sheet.Rows[1 + startY]).EntireRow.ColumnWidth = 4;

        ((Excel.Range)sheet.Columns[1 + startX]).ColumnWidth = 20;

        sheet.Cells[startY + 1, 1] = "№";
        sheet.Cells[startY + 1, 1].Orientation = 0;
        sheet.Cells[startY + 1, 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        sheet.Cells[startY + 1, 2] = "Фамилия, имя, отчество";
        sheet.Cells[startY + 1, 2].Orientation = 0;
        sheet.Cells[startY + 1, 2].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        sheet.Cells[startY + 2 + studentCount, 1 + startX] = "Средний балл";

        for (int i = 0; i < studentCount; i++)
        {
            int marksSum = 0;
            int marksCount = 0;

            for (int j = 0; j < subjectsCount; j++)
            {
                if (sheet.Cells[startY + 2 + i, subjextStartIndex + j + 1].Value != null)
                {
                    int mark = 0;

                    if (int.TryParse(sheet.Cells[startY + 2 + i, subjextStartIndex + j + 1].Value.ToString(), out mark))
                    {
                        marksSum += mark;
                        marksCount++;
                    }
                }
            }

            if (marksCount != 0)
            {
                sheet.Cells[startY + 2 + i, subjectsCount + subjextStartIndex + 1] = marksSum / (float)marksCount;
            }
        }

        for (int i = 0; i < subjectsCount; i++)
        {
            int marksSum = 0;
            int marksCount = 0;

            for (int j = 0; j < studentCount; j++)
            {
                if (sheet.Cells[startY + 2 + j, subjextStartIndex + i + 1].Value != null)
                {
                    int mark = 0;

                    if (int.TryParse(sheet.Cells[startY + 2 + j, subjextStartIndex + i + 1].Value.ToString(), out mark))
                    {
                        marksSum += mark;
                        marksCount++;
                    }
                }
            }

            if (marksCount != 0)
            {
                sheet.Cells[startY + 2 + studentCount, subjextStartIndex + i + 1] = marksSum / (float)marksCount;
            }
        }
        App.Visible = true;
        plansIndices.Clear();

        sheet = null;
        App = null;
        GC.Collect();
    }

    public void CreateFinalReport(College college, int group_id,
        CollegeDataSet.PlansDataTable plansDataTable,
        CollegeDataSet.SubjectsDataTable subjectsDataTable,
        CollegeDataSet.GroupsDataTable groupDataTable,
        CollegeDataSet.StudentsDataTable studentDataTable,
        CollegeDataSet.MarksDataTable marksDataTable,
        CollegeDataSet.SemestersDataTable semesterDataTable)
    {
        var App = new Excel.Application();
        App.Workbooks.Add();

        Excel.Worksheet sheet = (Excel.Worksheet)App.ActiveSheet;

        int startY = 6;
        int startX = 1;
        int subjextStartIndex = 2;
        int subjectEndIndex = subjextStartIndex;
        int subjectsCount = 0;
        int studentCount = 0;

        List<int> plansIndices = new List<int>();

        for (int i = 0; i < plansDataTable.Count; i++)
        {
            short currentSemester = 0;

            for (int j = 0; j < semesterDataTable.Count; j++)
            {
                if (plansDataTable[i].plan_record_id == semesterDataTable[j].plan_record_id)
                {
                    currentSemester = semesterDataTable[j].semester_number;

                    if (plansDataTable[i].group_id == group_id)
                    {
                        plansIndices.Add(plansDataTable[i].plan_record_id);
                        sheet.Cells[1 + startY, subjectEndIndex + startX] = subjectsDataTable.FindBysubject_id(plansDataTable[i].subject_id).subject_name;
                        subjectsCount++;
                        subjectEndIndex++;

                        break;
                    }
                }
            }
        }

        subjectEndIndex = 2;

        for (int i = 0; i < studentDataTable.Count; i++)
        {
            if (studentDataTable[i].group_id == group_id)
            {
                sheet.Cells[subjectEndIndex + startY, 1 + startX] =
                    studentDataTable[i].second_name + " " +
                    studentDataTable[i].first_name + " " +
                    studentDataTable[i].middle_name;

                studentCount++;

                sheet.Cells[startY + subjectEndIndex, 1] = subjectEndIndex - 1;

                subjectEndIndex++;             

                for (int j = 0; j < subjectsCount; j++)
                {
                    int mark = 0;
                    int markCount = 0;

                    bool markType = true;
                    string typedMark = "";

                    for (int k = 0; k < marksDataTable.Count; k++)
                    {
                        if (marksDataTable[k].plan_record_id == plansIndices[j] &&
                            marksDataTable[k].student_id == studentDataTable[i].student_id)
                        {
                            if (marksDataTable[k].mark_type_id == 0)
                            {
                                if (marksDataTable[k].mark >= 0)
                                {
                                    markType = false;
                                    mark += marksDataTable[k].mark;
                                    markCount++;
                                }
                                else
                                {
                                    typedMark = ((Mark)marksDataTable[k].mark).ToString();
                                }
                            }
                            else
                            {
                                mark = marksDataTable[k].mark;
                                markCount = 1;
                                break;
                            }
                        }
                    }

                    if (markType)
                    {
                        sheet.Cells[subjectEndIndex - 1 + startY, 2 + j + startX] = typedMark;
                    }
                    else if (mark != 0)
                        sheet.Cells[subjectEndIndex - 1 + startY, 2 + j + startX] = mark / markCount;
                }
            }
        }

        for (int i = 1; i <= 6; i++)
        {
            sheet.Range[sheet.Cells[i, 1], sheet.Cells[i, subjectsCount + subjextStartIndex + 1]].Merge();
            sheet.Range[sheet.Cells[i, 1], sheet.Cells[i, subjectsCount + subjextStartIndex + 1]].WrapText = true;
        }

        sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, subjectsCount + subjextStartIndex]] = "МИНИСТЕРСТВО ОБРАЗОВАНИЯ РЕСПУБЛИКИ БЕЛАРУСЬ";
        sheet.Range[sheet.Cells[2, 1], sheet.Cells[2, subjectsCount + subjextStartIndex]] = "(наименование органа государственного управления учреждением образования)";
        sheet.Range[sheet.Cells[3, 1], sheet.Cells[3, subjectsCount + subjextStartIndex]] = "УО \"ВИТЕБСКИЙ ГОСУДАРСТВЕННЫЙ ПОЛИТЕХНИЧЕСКИЙ КОЛЛЕДЖ\"";
        sheet.Range[sheet.Cells[4, 1], sheet.Cells[4, subjectsCount + subjextStartIndex]] = "(наименование учреждения образования)";
        sheet.Range[sheet.Cells[5, 1], sheet.Cells[5, subjectsCount + subjextStartIndex]] = "СВОДНАЯ ВЕДОМОСТЬ ИТОГОВОЙ УСПЕВАЕМОСТИ ЗА ВЕСЬ СРОК ОБУЧЕНИЯ";
        sheet.Range[sheet.Cells[6, 1], sheet.Cells[6, subjectsCount + subjextStartIndex]] = "УЧАЩИХСЯ ГРУППЫ " + groupDataTable.FindBygroup_id(group_id).group_name;

        sheet.Cells[1 + startY, startX + subjectsCount + subjextStartIndex] = "Средний балл";

        ((Excel.Range)sheet.Columns[1 + startX]).WrapText = true;
        ((Excel.Range)sheet.Rows[1 + startY]).WrapText = true;

        ((Excel.Range)sheet.Rows).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        ((Excel.Range)sheet.Rows).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        ((Excel.Range)sheet.Columns[1 + startX]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        ((Excel.Range)sheet.Rows[2 + startY]).EntireColumn.RowHeight = 30;
        ((Excel.Range)sheet.Rows[1 + startY]).RowHeight = 150;

        ((Excel.Range)sheet.Rows[1 + startY]).Orientation = 90;
        ((Excel.Range)sheet.Rows[1 + startY]).VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;
        ((Excel.Range)sheet.Rows[1 + startY]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        ((Excel.Range)sheet.Rows[1 + startY]).EntireRow.ColumnWidth = 4;

        ((Excel.Range)sheet.Columns[1 + startX]).ColumnWidth = 20;

        sheet.Cells[startY + 1, 1] = "№";
        sheet.Cells[startY + 1, 1].Orientation = 0;
        sheet.Cells[startY + 1, 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        sheet.Cells[startY + 1, 2] = "Фамилия, имя, отчество";
        sheet.Cells[startY + 1, 2].Orientation = 0;
        sheet.Cells[startY + 1, 2].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        for (int i = 0; i < studentCount; i++)
        {
            int marksSum = 0;
            int marksCount = 0;

            for (int j = 0; j < subjectsCount; j++)
            {
                if (sheet.Cells[startY + 2 + i, subjextStartIndex + j + 1].Value != null)
                {
                    int mark = 0;

                    if (int.TryParse((new Mark(sheet.Cells[startY + 2 + i, subjextStartIndex + j + 1].Value.ToString())).ToString(), out mark))
                    {
                        marksSum += mark;
                        marksCount++;
                    }
                }
            }

            if (marksCount != 0)
                sheet.Cells[startY + 2 + i, subjectsCount + subjextStartIndex + 1] = (marksSum / (float)marksCount);
        }

        App.Visible = true;
        plansIndices.Clear();
        sheet = null;
        App = null;
        GC.Collect();
    }
}