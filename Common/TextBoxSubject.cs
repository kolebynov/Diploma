public class TextBoxSubject : TextBoxChanged
{
    public int SubjectID
    {
        get { return m_subjectID; }
        set
        {
            if (m_subjectID != value)
            {
                m_subjectID = value;
                IsChanged = true;
            }
        }
    }
    public string SubjectName
    {
        get { return Text; }
        set { Text = value; }
    }

    private int m_subjectID;
}
