using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class SemesterLengthContainer : UserControl
{
    public int LengthID { get; set; }
    public short Number
    {
        get { return (short)m_numericSemester.Value; }
        set { m_numericSemester.Value = value; }
    }
    public double Length
    {
        get { return double.Parse(m_textBoxLength.Text); }
        set { m_textBoxLength.Text = value.ToString(); }
    }
    public bool IsChanged { get; set; }

    public SemesterLengthContainer()
    {
        InitializeComponent();

        LengthID = -1;
    }

    private void ValueChangedHandler(object sender, EventArgs e) =>
        IsChanged = true;
}
