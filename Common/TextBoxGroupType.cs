using System.Windows.Forms;

public class TextBoxGroupType : TextBoxChanged
{
    public short GroupTypeID
    {
        get { return m_groupTypeID; }
        set
        {
            if (value != m_groupTypeID)
            {
                m_groupTypeID = value;
                IsChanged = true;
            }
        }
    }
    public string TypeName
    {
        get { return Text; }
        set { Text = value; }
    }

    private short m_groupTypeID;
}
