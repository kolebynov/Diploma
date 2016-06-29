using System.Windows.Forms;

public class TextBoxChanged : TextBox
{
    public bool IsChanged { get; set; } = false;

    public TextBoxChanged()
    {
        TextChanged += (sender, e) => IsChanged = true;
    }
}
