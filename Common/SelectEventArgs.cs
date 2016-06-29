using System;
using System.Windows.Forms;
using System.Data;

public class SelectEventArgs : EventArgs
{
    public DataRow[] SelectedRows { get; }

    public SelectEventArgs(DataRow[] selectedRows)
    {
        SelectedRows = selectedRows;
    }
}
