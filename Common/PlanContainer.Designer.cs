partial class PlanContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanContainer));
            this.label1 = new System.Windows.Forms.Label();
            this.m_textBoxSubjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_comboBoxType1 = new System.Windows.Forms.ComboBox();
            this.m_comboBoxType2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_numericOKR = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.m_numericIKR = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.m_buttonSelectSubject = new System.Windows.Forms.Button();
            this.m_buttonAddSemester = new System.Windows.Forms.Button();
            this.m_buttonDeleteSemester = new System.Windows.Forms.Button();
            this.m_panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericOKR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericIKR)).BeginInit();
            this.m_panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Предмет:";
            // 
            // m_textBoxSubjectName
            // 
            this.m_textBoxSubjectName.Location = new System.Drawing.Point(89, 4);
            this.m_textBoxSubjectName.Name = "m_textBoxSubjectName";
            this.m_textBoxSubjectName.ReadOnly = true;
            this.m_textBoxSubjectName.Size = new System.Drawing.Size(252, 20);
            this.m_textBoxSubjectName.TabIndex = 1;
            this.m_textBoxSubjectName.TextChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип предмета:";
            // 
            // m_comboBoxType1
            // 
            this.m_comboBoxType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxType1.FormattingEnabled = true;
            this.m_comboBoxType1.Items.AddRange(new object[] {
            "Общеобразовательный компонент",
            "Профессиональный компонент"});
            this.m_comboBoxType1.Location = new System.Drawing.Point(89, 25);
            this.m_comboBoxType1.Name = "m_comboBoxType1";
            this.m_comboBoxType1.Size = new System.Drawing.Size(156, 21);
            this.m_comboBoxType1.TabIndex = 3;
            this.m_comboBoxType1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxType1SelectedIndexChangedHandler);
            // 
            // m_comboBoxType2
            // 
            this.m_comboBoxType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxType2.FormattingEnabled = true;
            this.m_comboBoxType2.Location = new System.Drawing.Point(250, 25);
            this.m_comboBoxType2.Name = "m_comboBoxType2";
            this.m_comboBoxType2.Size = new System.Drawing.Size(157, 21);
            this.m_comboBoxType2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество ОКР:";
            // 
            // m_numericOKR
            // 
            this.m_numericOKR.Location = new System.Drawing.Point(102, 47);
            this.m_numericOKR.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericOKR.Name = "m_numericOKR";
            this.m_numericOKR.Size = new System.Drawing.Size(50, 20);
            this.m_numericOKR.TabIndex = 6;
            this.m_numericOKR.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество ИКР:";
            // 
            // m_numericIKR
            // 
            this.m_numericIKR.Location = new System.Drawing.Point(258, 47);
            this.m_numericIKR.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericIKR.Name = "m_numericIKR";
            this.m_numericIKR.Size = new System.Drawing.Size(50, 20);
            this.m_numericIKR.TabIndex = 8;
            this.m_numericIKR.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Семестры:";
            // 
            // m_buttonSelectSubject
            // 
            this.m_buttonSelectSubject.Location = new System.Drawing.Point(347, 3);
            this.m_buttonSelectSubject.Name = "m_buttonSelectSubject";
            this.m_buttonSelectSubject.Size = new System.Drawing.Size(61, 23);
            this.m_buttonSelectSubject.TabIndex = 10;
            this.m_buttonSelectSubject.Text = "Выбрать";
            this.m_buttonSelectSubject.UseVisualStyleBackColor = true;
            this.m_buttonSelectSubject.Click += new System.EventHandler(this.ButtonSelectSubjectClickHandler);
            // 
            // m_buttonAddSemester
            // 
            this.m_buttonAddSemester.Image = global::Common.Properties.Resources.plus;
            this.m_buttonAddSemester.Location = new System.Drawing.Point(8, 2);
            this.m_buttonAddSemester.Name = "m_buttonAddSemester";
            this.m_buttonAddSemester.Size = new System.Drawing.Size(24, 20);
            this.m_buttonAddSemester.TabIndex = 11;
            this.m_buttonAddSemester.UseVisualStyleBackColor = true;
            this.m_buttonAddSemester.Click += new System.EventHandler(this.ButtonAddSemesterClickHandler);
            // 
            // m_buttonDeleteSemester
            // 
            this.m_buttonDeleteSemester.Image = ((System.Drawing.Image)(resources.GetObject("m_buttonDeleteSemester.Image")));
            this.m_buttonDeleteSemester.Location = new System.Drawing.Point(33, 2);
            this.m_buttonDeleteSemester.Name = "m_buttonDeleteSemester";
            this.m_buttonDeleteSemester.Size = new System.Drawing.Size(24, 20);
            this.m_buttonDeleteSemester.TabIndex = 12;
            this.m_buttonDeleteSemester.UseVisualStyleBackColor = true;
            this.m_buttonDeleteSemester.Click += new System.EventHandler(this.ButtonDeleteSemesterClickHandler);
            // 
            // m_panelButtons
            // 
            this.m_panelButtons.Controls.Add(this.m_buttonAddSemester);
            this.m_panelButtons.Controls.Add(this.m_buttonDeleteSemester);
            this.m_panelButtons.Location = new System.Drawing.Point(352, 60);
            this.m_panelButtons.Name = "m_panelButtons";
            this.m_panelButtons.Size = new System.Drawing.Size(57, 24);
            this.m_panelButtons.TabIndex = 13;
            // 
            // PlanContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(170)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_panelButtons);
            this.Controls.Add(this.m_buttonSelectSubject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_numericIKR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_numericOKR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_comboBoxType2);
            this.Controls.Add(this.m_comboBoxType1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_textBoxSubjectName);
            this.Controls.Add(this.label1);
            this.Name = "PlanContainer";
            this.Size = new System.Drawing.Size(410, 248);
            this.Leave += new System.EventHandler(this.LeaveHandler);
            this.Resize += new System.EventHandler(this.ResizeHandler);
            ((System.ComponentModel.ISupportInitialize)(this.m_numericOKR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericIKR)).EndInit();
            this.m_panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_textBoxSubjectName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox m_comboBoxType1;
    private System.Windows.Forms.ComboBox m_comboBoxType2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown m_numericOKR;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown m_numericIKR;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button m_buttonSelectSubject;
    private System.Windows.Forms.Button m_buttonAddSemester;
    private System.Windows.Forms.Button m_buttonDeleteSemester;
    private System.Windows.Forms.Panel m_panelButtons;
}
