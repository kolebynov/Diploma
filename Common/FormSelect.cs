using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class FormSelect : Form
{
    public DataGridView DataGrid { get { return m_dataGridView; } }

    public event EventHandler<SelectEventArgs> ItemSelected;

    public FormSelect(DataTable data)
    {
        InitializeComponent();

        m_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        m_dataGridView.DataSource = data;
        m_dataTable = data.Copy();
        m_dataTable.Clear();
    }
    public FormSelect() : this(null)
    { }

    private DataTable m_dataTable;

    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        ApplySelect();
        Close();
    }
    private void ButtonCancelClickHandler(object sender, EventArgs e) =>
        Close();
    private void LoadHandler(object sender, EventArgs e) =>
        LoadColumnsForSearch();
    private void ButtonSearchClickHandler(object sender, EventArgs e) =>
        Search();
    private void ButtonResetClickHandler(object sender, EventArgs e) =>
        ResetSearch();
    private void ResizeHandler(object sender, EventArgs e) =>
        UpdateControlsSize();
    private void PanelButtonsResizeHandler(object sender, EventArgs e) =>
        UpdateButtonsLocation();

    private void ApplySelect()
    {
        if (m_dataGridView.SelectedRows.Count == 0 || ItemSelected == null)
            return;
        Type asd = m_dataTable.GetType();
        DataRow[] selectedRows = new DataRow[m_dataGridView.SelectedRows.Count];
        for (int i = 0; i < m_dataGridView.SelectedRows.Count; i++)
        {
            DataGridViewRow gridRow = m_dataGridView.SelectedRows[i];
            DataRow row = m_dataTable.NewRow();
            foreach (DataGridViewCell gridCell in gridRow.Cells)
            {
                row[m_dataGridView.Columns[gridCell.ColumnIndex].Name] =
                    gridCell.Value;
            }
            selectedRows[i] = row;
        }

        ItemSelected(this, new SelectEventArgs(selectedRows));
    }
    private void LoadColumnsForSearch()
    {
        foreach (DataGridViewColumn column in m_dataGridView.Columns)
        {
            if (column.Visible)
                m_comboBoxColumns.Items.Add(column.HeaderText);
        }

        if (m_comboBoxColumns.Items.Count > 0)
            m_comboBoxColumns.SelectedIndex = 0;
    }
    private void Search()
    {
        int index = 0;
        foreach (DataGridViewColumn column in m_dataGridView.Columns)
            if (column.HeaderText == m_comboBoxColumns.Text)
            {
                index = column.Index;
                break;
            }

        m_dataGridView.CurrentCell = null;
        for (int i = 0; i < m_dataGridView.RowCount; i++)
        {
            var row = m_dataGridView.Rows[i];
            string str1 = row.Cells[index].Value.ToString().ToLowerInvariant();
            string str2 = m_textBoxSearch.Text.ToLowerInvariant();
            row.Visible = str1.Contains(str2);
        }
    }
    private void ResetSearch()
    {
        foreach (DataGridViewRow row in m_dataGridView.Rows)
            row.Visible = true;
    }
    private void UpdateControlsSize()
    {
        m_groupBoxSearch.Left = ClientSize.Width - m_groupBoxSearch.Width - 1;
        m_dataGridView.Width = m_groupBoxSearch.Left - m_dataGridView.Left - 1;
        m_panelButtons.Top = ClientSize.Height - m_panelButtons.Height;
        m_groupBoxSearch.Height = m_dataGridView.Height = 
            m_panelButtons.Top - m_dataGridView.Top;
        m_panelButtons.Width = ClientSize.Width;
    }
    private void UpdateButtonsLocation()
    {
        m_buttonCancel.Left = m_panelButtons.Width - m_buttonCancel.Width - 
            m_buttonOK.Left;
    }
}
