using System.Windows.Forms;
using System.Text.RegularExpressions;

public partial class StudentDataContainer : UserControl
{
    public TextBox TextSecondName { get { return m_textSecondName; } }
    public TextBox TextFirstName { get { return m_textFirstName; } }
    public TextBox TextMiddleName { get { return m_textMiddleName; } }
    public Label LabelSecondName { get { return m_labelSecondName; } }
    public Label LabelFirstName { get { return m_labelFirstName; } }
    public Label LabelMiddleName { get { return m_labelMiddleName; } }

    public StudentDataContainer()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Проверяет на корректность введенные данные.
    /// </summary>
    /// <returns>Возвращает результат проверки.</returns>
    public CheckDataResult CheckData()
    {
        Result temp = CheckString(m_textFirstName.Text);
        if (temp != Result.OK)
            return new CheckDataResult(m_labelFirstName.Text.Substring(0, 
                m_labelFirstName.Text.Length - 1), temp);

        temp = CheckString(m_textSecondName.Text);
        if (temp != Result.OK)
            return new CheckDataResult(m_labelSecondName.Text.Substring(0,
                m_labelSecondName.Text.Length - 1), temp);

        temp = CheckString(m_textMiddleName.Text);
        if (temp != Result.OK)
            return new CheckDataResult(m_labelMiddleName.Text.Substring(0,
                m_labelMiddleName.Text.Length - 1), temp);

        return new CheckDataResult(null, Result.OK);
    }

    private const string EMPTY_FIELD = "Поле {0} пусто.";
    private const string WRONG_SYMBOLS = "В поле {0} есть недопустимые символы.";
    private const string WRONG_SYMBOLS_PATTERN = @"[^А-Я^а-я]";

    private void ElementClickHandler(object sender, MouseEventArgs e) =>
        OnMouseClick(e);

    private Result CheckString(string str)
    {
        if (str == null || str == string.Empty)
            return Result.EmptyField;

        Regex regex = new Regex(WRONG_SYMBOLS_PATTERN);
        if (regex.IsMatch(str))
            return Result.WrongSymbols;

        return Result.OK;
    }

    public class CheckDataResult
    {
        public string FieldName { get; set; }
        public Result Result { get; set; }

        public CheckDataResult(string fieldName, Result result)
        {
            FieldName = fieldName;
            Result = result;
        }
    }

    public enum Result
    {
        EmptyField,
        WrongSymbols,
        OK
    }
}
