using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class SemesterDataContainer : UserControl
{
    public short SemesterNumber
    {
        get { return (short)m_numericSemesterNumber.Value; }
        set { m_numericSemesterNumber.Value = value; }
    }
    public bool Exam
    {
        get { return m_checkBoxExam.Checked; }
        set { m_checkBoxExam.Checked = value; }
    }
    public short HoursCount
    {
        get { return (short)m_numericHours.Value; }
        set { m_numericHours.Value = value; }
    }
    public short HoursPerWeek
    {
        get { return (short)m_numericHoursWeek.Value; }
        set { m_numericHoursWeek.Value = value; }
    }
    public short HoursCountLPZ
    {
        get { return (short)m_numericLPZ.Value; }
        set { m_numericLPZ.Value = value; }
    }
    public short HoursCountKP
    {
        get { return (short)m_numericKP.Value; }
        set { m_numericKP.Value = value; }
    }
    public bool IsChanged
    {
        get
        {
            bool current = m_isChanged;
            //m_isChanged = false;
            return current;
        }
        set { m_isChanged = value; }
    }

    public SemesterDataContainer()
    {
        InitializeComponent();      
    }

    private bool m_isChanged = false;

    private void ValueChangedHandler(object sender, EventArgs e) =>
        m_isChanged = true;
}
