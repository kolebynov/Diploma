partial class SemesterDataContainer
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
            this.m_numericSemesterNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.m_numericHours = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.m_checkBoxExam = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_numericHoursWeek = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.m_numericLPZ = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.m_numericKP = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericSemesterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericHoursWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLPZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericKP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер семестра:";
            // 
            // m_numericSemesterNumber
            // 
            this.m_numericSemesterNumber.Location = new System.Drawing.Point(110, 2);
            this.m_numericSemesterNumber.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericSemesterNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericSemesterNumber.Name = "m_numericSemesterNumber";
            this.m_numericSemesterNumber.Size = new System.Drawing.Size(38, 20);
            this.m_numericSemesterNumber.TabIndex = 1;
            this.m_numericSemesterNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericSemesterNumber.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество часов:";
            // 
            // m_numericHours
            // 
            this.m_numericHours.Location = new System.Drawing.Point(110, 24);
            this.m_numericHours.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.m_numericHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericHours.Name = "m_numericHours";
            this.m_numericHours.Size = new System.Drawing.Size(38, 20);
            this.m_numericHours.TabIndex = 3;
            this.m_numericHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericHours.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Экзамен:";
            // 
            // m_checkBoxExam
            // 
            this.m_checkBoxExam.AutoSize = true;
            this.m_checkBoxExam.Location = new System.Drawing.Point(329, 4);
            this.m_checkBoxExam.Name = "m_checkBoxExam";
            this.m_checkBoxExam.Size = new System.Drawing.Size(15, 14);
            this.m_checkBoxExam.TabIndex = 5;
            this.m_checkBoxExam.UseVisualStyleBackColor = true;
            this.m_checkBoxExam.CheckedChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Количество часов в неделю:";
            // 
            // m_numericHoursWeek
            // 
            this.m_numericHoursWeek.Location = new System.Drawing.Point(306, 24);
            this.m_numericHoursWeek.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m_numericHoursWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericHoursWeek.Name = "m_numericHoursWeek";
            this.m_numericHoursWeek.Size = new System.Drawing.Size(38, 20);
            this.m_numericHoursWeek.TabIndex = 7;
            this.m_numericHoursWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericHoursWeek.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Часов на ЛПЗ:";
            // 
            // m_numericLPZ
            // 
            this.m_numericLPZ.Location = new System.Drawing.Point(110, 46);
            this.m_numericLPZ.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.m_numericLPZ.Name = "m_numericLPZ";
            this.m_numericLPZ.Size = new System.Drawing.Size(38, 20);
            this.m_numericLPZ.TabIndex = 9;
            this.m_numericLPZ.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Часов на КП:";
            // 
            // m_numericKP
            // 
            this.m_numericKP.Location = new System.Drawing.Point(306, 46);
            this.m_numericKP.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.m_numericKP.Name = "m_numericKP";
            this.m_numericKP.Size = new System.Drawing.Size(38, 20);
            this.m_numericKP.TabIndex = 11;
            this.m_numericKP.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // SemesterDataContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_numericKP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_numericLPZ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_numericHoursWeek);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_checkBoxExam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_numericHours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_numericSemesterNumber);
            this.Controls.Add(this.label1);
            this.Name = "SemesterDataContainer";
            this.Size = new System.Drawing.Size(347, 68);
            ((System.ComponentModel.ISupportInitialize)(this.m_numericSemesterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericHoursWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLPZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericKP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown m_numericSemesterNumber;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown m_numericHours;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox m_checkBoxExam;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown m_numericHoursWeek;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown m_numericLPZ;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown m_numericKP;
}
