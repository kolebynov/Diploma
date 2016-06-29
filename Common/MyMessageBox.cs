using System.Windows.Forms;
using Common;

public static class MyMessageBox
{
    public static void ShowError(string message)
    {
        MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
    public static DialogResult ShowCloseForm()
    {
        return MessageBox.Show(Resource1.CancelMessage, "Вопрос", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
    public static DialogResult ShowDelete()
    {
        return MessageBox.Show(Resource1.DeleteMsg, "Вопрос",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
