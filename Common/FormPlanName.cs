using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class FormPlanName : Form
{
    public string PlanName { get { return m_textBoxName.Text; } }

    public FormPlanName()
    {
        InitializeComponent();
    }

    private void ButtonOKClickhandler(object sender, EventArgs e)
    {
        if (m_textBoxName.Text == string.Empty || m_textBoxName == null)
            MyMessageBox.ShowError("Вы не ввели имя для плана.");
        else
            Close();
    }
}
