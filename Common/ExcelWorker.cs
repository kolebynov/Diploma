using System;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Office.Interop.Excel;

using Application = Microsoft.Office.Interop.Excel.Application;

public class ExcelWorker : IDisposable
{
    public bool Visible
    {
        get { return m_app.Visible; }
        set { m_app.Visible = value; }
    }

    public ExcelWorker()
    {
        m_app = new Application();
        m_app.Workbooks.Add();

        m_sheet = m_app.ActiveSheet;
    }

    public void WriteDataGrid(DataGridView dataGrid, int startColumn = 1)
    {
        m_rowPosition++;
        if (dataGrid.ColumnHeadersVisible)
        {
            for (int i = 0; i < dataGrid.ColumnCount; ++i)
            {
                DataGridViewColumn column = dataGrid.Columns[i];
                m_sheet.Cells[m_rowPosition, startColumn + i] = column.HeaderText;
            }

            m_rowPosition++;
        }

        for (int i = 0; i < dataGrid.RowCount; i++, m_rowPosition++)
        {
            var row = dataGrid.Rows[i];
            for (int j = 0; j < row.Cells.Count; j++)
            {
                Type type = row.Cells[j].Value?.GetType();
                m_sheet.Cells[m_rowPosition, startColumn + j] = row.Cells[j].Value;
            }
        }
    }
    public void WrapText(int rowStart, int columnStart, int countRow, int countColumn, bool value)
    {
        ((Range)m_sheet.Range[m_sheet.Cells[rowStart, columnStart], 
            m_sheet.Cells[rowStart + countRow - 1, columnStart + countColumn - 
            1]]).WrapText = value;
    }
    public void WrapText(int columnStart, int countRow, int countColumn, bool value)
    {
        WrapText(m_rowPosition, columnStart, countRow, countColumn, value);
    }
    public void SetColumnWidth(int columnStart, int count, int width)
    {
        ((Range)m_sheet.Range[m_sheet.Cells[m_rowPosition, columnStart],
            m_sheet.Cells[m_rowPosition, columnStart + count - 1]]).ColumnWidth = width;
    }
    public void Orientation90(int rowStart, int columnStart, int countRow, int countColumn)
    {
        Range range = ((Range)m_sheet.Range[m_sheet.Cells[rowStart, columnStart],
            m_sheet.Cells[rowStart + countRow - 1, columnStart + countColumn - 1]]);
        range.Orientation = 90;
        range.VerticalAlignment = XlVAlign.xlVAlignBottom;
        range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        range.ColumnWidth = 5;
    }
    public void SetText(int columnStart, int count, string text)
    {
        m_sheet.Range[m_sheet.Cells[m_rowPosition, columnStart],
            m_sheet.Cells[m_rowPosition, columnStart + count - 1]].Merge();
        m_sheet.Range[m_sheet.Cells[m_rowPosition, columnStart], 
            m_sheet.Cells[m_rowPosition, columnStart + count - 1]] = text;
    }
    public void SkipRow(int rowCount = 1)
    {
        m_rowPosition += rowCount;
    }
    public void Dispose()
    {
        m_app = null;
        m_sheet = null;
        GC.Collect();
    }

    private Application m_app;
    private Worksheet m_sheet;
    private int m_rowPosition = 1;
}
