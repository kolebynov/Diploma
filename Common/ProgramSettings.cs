using System.Drawing;

public class ProgramSettings
{
    public Color ListColorHover { get; }
    public Color ListColorSelect { get; }
    public Color ListBackColor { get; }
    public Color ListElementColor { get; }

    public static ProgramSettings Default { get; } = 
        new ProgramSettings();
    public static ProgramSettings Current { get; set; } = Default;

    public ProgramSettings()
    {
        ListColorHover = Color.Transparent;
        ListColorSelect = Color.FromArgb(230, 192, 192);
        ListBackColor = SystemColors.ControlLight;
        ListElementColor = Color.FromArgb(245, 245, 200);
    }
}
