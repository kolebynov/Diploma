using System;
using System.Text;

public enum MarkType : short
{
    Done = -1,
    Excuse = -2,
    NotDone = -3,
    Absence = -4,
    ND = -5,
    Mark0 = 0,
    Mark1 = 1,
    Mark2 = 2,
    Mark3 = 3,
    Mark4 = 4,
    Mark5 = 5,
    Mark6 = 6,
    Mark7 = 7,
    Mark8 = 8,
    Mark9 = 9,
    Mark10 = 10,
}

public struct Mark
{
    public static string[] Marks { get { return _marks; } }

    public Mark(MarkType type)
    {
        m_value = -5;
        m_Value = (short)type;  
    }
    public Mark(string mark)
    {
        short temp;
        m_value = -5;
        if (short.TryParse(mark, out temp))
        {
            if (temp > 10 || temp < 0)
            {
                throw new ArgumentException("Оценка находится в неправильном " +
                    "диапазоне. Диапазон должен быть от 0 до 10.");
            }
            m_Value = temp;
            return;
        }

        for (int i = 0; i < _marks.Length; i++)
            if (_marks[i].Equals(mark, StringComparison.OrdinalIgnoreCase))
            {
                m_Value = (short)(-(i + 1));
                return;
            }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < _marks.Length; i++)
        {
            sb.Append(_marks[i]);
            if (i + 1 < _marks.Length)
                sb.Append(", ");
        }
                
        throw new ArgumentException("Строка не является оценкой или " +
            "зарезервированным словом. Список зарезервированных слов: " + 
            sb.ToString() + ".");
    }

    public override string ToString()
    {
        if (m_value > -1)
            return m_value.ToString();
        else
            return _marks[Math.Abs(m_value + 1)];
    }

    public static implicit operator short(Mark value)
    {
        return value.m_value;
    }
    public static implicit operator Mark(MarkType type)
    {
        return new Mark(type);
    }
    public static implicit operator Mark(short value)
    {
        return new Mark((MarkType)value);
    }

    private short m_Value
    {
        get { return m_value; }
        set
        {
            if (value > 10 || value < -5)
            {
                throw new ArgumentException("Оценка находится в неправильном " +
                    "диапазоне (диапазон: от -5 до 10).");
            }

            m_value = value;
        }
    }
    private short m_value;

    private static string[] _marks = new string[]
    {
        "зач",
        "осв",
        "не зач",
        "н/я",
        "н/д"
    };
}