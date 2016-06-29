using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class SubjectTypeContainer : UserControl
{
    public bool IsChanged
    {
        get { return m_isChanged || m_textBoxTypeName.IsChanged; }
        set { m_isChanged = value; m_textBoxTypeName.IsChanged = value; }
    }
    public short SubjectTypeID
    {
        get { return m_subjectTypeID; }
        set
        {
            if (m_subjectTypeID != value)
            {
                m_subjectTypeID = value;
                IsChanged = true;
            }
        }
    }
    public string SubjectTypeName
    {
        get { return m_textBoxTypeName.Text; }
        set { m_textBoxTypeName.Text = value; }
    }
    public bool GlobalSubjectType
    {
        get { return Convert.ToBoolean(m_comboBoxGlobalType.SelectedIndex); }
        set { m_comboBoxGlobalType.SelectedIndex = Convert.ToInt32(value); }
    }

    public SubjectTypeContainer()
    {
        InitializeComponent();

        m_comboBoxGlobalType.SelectedIndex = 0;
    }

    private short m_subjectTypeID;
    private bool m_isChanged = false;

    private void ComboBoxGlobalTypeSelectedIndexChangedHandler(object sender, 
        EventArgs e) =>
        IsChanged = true;
}
