partial class SemesterLengthContainer
{
    /// <summary> 
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.m_numericSemester = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.m_textBoxLength = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericSemester)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер семестра:";
            // 
            // m_numericSemester
            // 
            this.m_numericSemester.Location = new System.Drawing.Point(105, 3);
            this.m_numericSemester.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericSemester.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericSemester.Name = "m_numericSemester";
            this.m_numericSemester.Size = new System.Drawing.Size(40, 20);
            this.m_numericSemester.TabIndex = 1;
            this.m_numericSemester.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericSemester.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Длина семестра:";
            // 
            // m_textBoxLength
            // 
            this.m_textBoxLength.Location = new System.Drawing.Point(252, 3);
            this.m_textBoxLength.Name = "m_textBoxLength";
            this.m_textBoxLength.Size = new System.Drawing.Size(52, 20);
            this.m_textBoxLength.TabIndex = 3;
            this.m_textBoxLength.TextChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // SemesterLengthContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_textBoxLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_numericSemester);
            this.Controls.Add(this.label1);
            this.Name = "SemesterLengthContainer";
            this.Size = new System.Drawing.Size(306, 27);
            ((System.ComponentModel.ISupportInitialize)(this.m_numericSemester)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown m_numericSemester;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox m_textBoxLength;
}
