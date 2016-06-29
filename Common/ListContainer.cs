using System.Drawing;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Контейнер, который хранит компоненты в виде списка.
/// </summary>
public partial class ListContainer<T> : UserControl, IList<T> where T : Control
{
    public T this[int index]
    {
        get { return m_componentList[index]; }
        set { m_componentList[index] = value; }
    }
    public int Count { get { return m_componentList.Count; } }
    public bool IsReadOnly { get { return false; } }

    public int IndexOf(T item)
    {
        return m_componentList.IndexOf(item);
    }
    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }
    public void RemoveAt(int index)
    {
        m_componentList.RemoveAt(index);
        Controls.RemoveAt(index * 2);
        Controls.RemoveAt(index * 2);

        if (index >= 0)
        {
            UpdateList();
            if (Count > 0)
                ControlSelect(this[Count - 1]);
        }
    }
    public void Add(T item)
    {
        m_componentList.Add(item);
        Controls.Add(item);
    }
    public void Clear()
    {
        m_componentList.Clear();
        Controls.Clear();
    }
    public bool Contains(T item)
    {
        return m_componentList.Contains(item);
    }
    public void CopyTo(T[] array, int arrayIndex)
    {
        m_componentList.CopyTo(array, arrayIndex);
    }
    public bool Remove(T item)
    {
        int index = m_componentList.IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }
        else
            return false;

    }
    public IEnumerator<T> GetEnumerator()
    {
        return m_componentList.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Расстояние между 2-мя компонентами в списке по оси Y.
    /// </summary>
    public int ControlOffsetY { get; set; } 
    /// <summary>
    /// Цвет компонента при наведении.
    /// </summary>
    public Color ColorHover { get; set; }
    /// <summary>
    /// Цвет компонента, когда он выделен.
    /// </summary>
    public Color ColorSelect { get; set; }
    /// <summary>
    /// Начальное положение компонентов по оси X.
    /// </summary>
    public int StartX
    {
        get { return m_startX; }
        set
        {
            m_startX = value;
            UpdateList();
        }
    }
    /// <summary>
    /// Начальное положение компонентов по оси Y.
    /// </summary>
    public int StartY
    {
        get { return m_startY; }
        set
        {
            m_startY = value;
            UpdateList();
        }
    }
    /// <summary>
    /// Показывать ли порядковые числа возле компонентов.
    /// </summary>
    public bool ShowNumbers
    {
        get { return m_showNumbers; }
        set
        {
            m_showNumbers = value;
            UpdateList();
        }
    }
    public bool DoUpdateList
    {
        get { return m_doUpdateList; }
        set
        {          
            m_doUpdateList = value;

            if (value)
                UpdateList();
        }
    }
    public T SelectedElement
    {
        get { return m_selectedControl; }
        set { ControlSelect(value); }
    }

    public ListContainer()
    {
        InitializeComponent();

        m_componentList = new List<T>();

        ControlAdded += (sender, e) =>
        {
            if (e.Control.Tag != null && e.Control.Tag.Equals(LABEL_NUMBER_TAG))
                return;

            e.Control.BackColor = ProgramSettings.Current.ListElementColor;
            e.Control.Tag = e.Control.BackColor;
            e.Control.MouseEnter += (sender2, e2) =>
            {
                ControlHover(sender2 as T);
                OnMouseEnter(e2);
            };
            e.Control.MouseClick += (sender2, e2) =>
            {
                ControlSelect(sender2 as T);
                OnMouseClick(e2);
            };
            foreach (Control control in e.Control.Controls)
            {
                control.MouseEnter += (sender2, e2) =>
                    ControlHover(e.Control as T);
                control.MouseClick += (sender2, e2) =>
                    ControlSelect(e.Control as T);
            }

            AddLabel();
            UpdateList();          
        };
    }

    /// <summary>
    /// Удаление выделенного компонента из списка.
    /// </summary>
    public void DeleteSelected()
    {
        if (m_selectedControl != null)
            Remove(m_selectedControl);
    }
    public void Init(int controlOffsetY, Point location, string name, Size size,
        int startX, int startY)
    {
        AutoScroll = true;
        BackColor = ProgramSettings.Current.ListBackColor;
        BorderStyle = BorderStyle.FixedSingle;
        ColorHover = ProgramSettings.Current.ListColorHover;
        ColorSelect = ProgramSettings.Current.ListColorSelect;
        ControlOffsetY = controlOffsetY;
        ForeColor = SystemColors.ControlText;
        Location = location;
        Name = name;
        ShowNumbers = true;
        Size = size;
        StartX = startX;
        StartY = startY;
    }

    private T m_hoveredControl;
    private T m_selectedControl;
    private int m_startX = 3;
    private int m_startY = 5;
    private bool m_showNumbers = true;
    private bool m_doUpdateList = true;
    private List<T> m_componentList;

    private const int LABEL_NUMBER_WIDTH = 24;
    private const int LABEL_NUMBER_HEIGHT = 15;
    private const string LABEL_NUMBER_TAG = "number";

    private void ResizeHandler(object sender, EventArgs e) =>
        UpdateControlsWidth();

    private void AddLabel()
    {
        Controls.Add(new Label
        {
            Tag = LABEL_NUMBER_TAG,
            Width = LABEL_NUMBER_WIDTH,
            Height = LABEL_NUMBER_HEIGHT,
            Visible = m_showNumbers
        });
    }
    private void UpdateList()
    {
        if (!m_doUpdateList)
            return;

        int posX = m_startX;
        if (m_showNumbers)
            posX += LABEL_NUMBER_WIDTH;
        for (int i = 0; i < Controls.Count; i += 2)
        {
            Control control = Controls[i];
            Label label = (Label)Controls[i + 1];
            label.Visible = m_showNumbers;
            int posY = m_startY + i / 2 * ControlOffsetY - VerticalScroll.Value;

            if (m_showNumbers)
            {
                label.Location = new Point(m_startX, posY + control.Height / 2 - 
                    LABEL_NUMBER_HEIGHT / 2);
                label.Text = (i / 2 + 1).ToString() + ".";
            }

            control.Location = new Point(posX, posY);
        }

        UpdateControlsWidth();
    }
    private void ControlHover(T control)
    {
        int controlIndex = Controls.IndexOf(control);
        if (m_hoveredControl != null && m_hoveredControl != m_selectedControl)
            m_hoveredControl.BackColor = (Color)m_hoveredControl.Tag;
        if (m_selectedControl != control && ColorHover != Color.Transparent)
            control.BackColor = ColorHover;
        m_hoveredControl = control;
    }
    private void ControlSelect(T control)
    {
        if (m_selectedControl != null)
            m_selectedControl.BackColor = (Color)m_selectedControl.Tag;
        if (control != null && ColorSelect != Color.Transparent)
            control.BackColor = ColorSelect;
        m_selectedControl = control;
    }
    private void UpdateControlsWidth()
    {
        int diff = m_showNumbers ? m_startX + LABEL_NUMBER_WIDTH : m_startX;
        foreach (T control in m_componentList)
            control.Width = ClientSize.Width - diff - 1;
    }
}