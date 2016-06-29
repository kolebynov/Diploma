partial class FormHoursDeduction
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.m_comboBoxSemesters = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dateStartSemester = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dateDeduction = new System.Windows.Forms.DateTimePicker();
            this.m_dataGridDeduction = new System.Windows.Forms.DataGridView();
            this.Subjects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActuallyHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MustBeHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_buttonCalculate = new System.Windows.Forms.Button();
            this.m_panelButtons = new System.Windows.Forms.Panel();
            this.m_buttonExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridDeduction)).BeginInit();
            this.m_panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Укажите семестр:";
            // 
            // m_comboBoxSemesters
            // 
            this.m_comboBoxSemesters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxSemesters.FormattingEnabled = true;
            this.m_comboBoxSemesters.Location = new System.Drawing.Point(211, 7);
            this.m_comboBoxSemesters.Name = "m_comboBoxSemesters";
            this.m_comboBoxSemesters.Size = new System.Drawing.Size(44, 23);
            this.m_comboBoxSemesters.TabIndex = 1;
            this.m_comboBoxSemesters.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSemestersSelectedIndexChangedHandler);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Укажите дату начала семестра:";
            // 
            // m_dateStartSemester
            // 
            this.m_dateStartSemester.Location = new System.Drawing.Point(211, 35);
            this.m_dateStartSemester.Name = "m_dateStartSemester";
            this.m_dateStartSemester.Size = new System.Drawing.Size(148, 21);
            this.m_dateStartSemester.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Укажите дату вычета:";
            // 
            // m_dateDeduction
            // 
            this.m_dateDeduction.Location = new System.Drawing.Point(211, 60);
            this.m_dateDeduction.Name = "m_dateDeduction";
            this.m_dateDeduction.Size = new System.Drawing.Size(148, 21);
            this.m_dateDeduction.TabIndex = 5;
            // 
            // m_dataGridDeduction
            // 
            this.m_dataGridDeduction.AllowUserToAddRows = false;
            this.m_dataGridDeduction.AllowUserToDeleteRows = false;
            this.m_dataGridDeduction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dataGridDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridDeduction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Subjects,
            this.ActuallyHours,
            this.MustBeHours,
            this.Difference});
            this.m_dataGridDeduction.Location = new System.Drawing.Point(0, 87);
            this.m_dataGridDeduction.Name = "m_dataGridDeduction";
            this.m_dataGridDeduction.RowHeadersVisible = false;
            this.m_dataGridDeduction.Size = new System.Drawing.Size(485, 228);
            this.m_dataGridDeduction.TabIndex = 6;
            this.m_dataGridDeduction.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridDeductionCellClickHandler);
            this.m_dataGridDeduction.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridDeductionCellValueChangedHandler);
            // 
            // Subjects
            // 
            this.Subjects.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Subjects.HeaderText = "Дисциплины";
            this.Subjects.Name = "Subjects";
            // 
            // ActuallyHours
            // 
            this.ActuallyHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActuallyHours.HeaderText = "Фактически часов";
            this.ActuallyHours.Name = "ActuallyHours";
            // 
            // MustBeHours
            // 
            this.MustBeHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MustBeHours.HeaderText = "Должно быть часов";
            this.MustBeHours.Name = "MustBeHours";
            // 
            // Difference
            // 
            this.Difference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Difference.HeaderText = "Разница";
            this.Difference.Name = "Difference";
            // 
            // m_buttonCalculate
            // 
            this.m_buttonCalculate.Location = new System.Drawing.Point(12, 8);
            this.m_buttonCalculate.Name = "m_buttonCalculate";
            this.m_buttonCalculate.Size = new System.Drawing.Size(86, 29);
            this.m_buttonCalculate.TabIndex = 7;
            this.m_buttonCalculate.Text = "Рассчитать";
            this.m_buttonCalculate.UseVisualStyleBackColor = true;
            this.m_buttonCalculate.Click += new System.EventHandler(this.ButtonCalculateClickHandler);
            // 
            // m_panelButtons
            // 
            this.m_panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelButtons.Controls.Add(this.m_buttonExcel);
            this.m_panelButtons.Controls.Add(this.m_buttonCalculate);
            this.m_panelButtons.Location = new System.Drawing.Point(0, 313);
            this.m_panelButtons.Name = "m_panelButtons";
            this.m_panelButtons.Size = new System.Drawing.Size(485, 40);
            this.m_panelButtons.TabIndex = 8;
            // 
            // m_buttonExcel
            // 
            this.m_buttonExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonExcel.Location = new System.Drawing.Point(388, 8);
            this.m_buttonExcel.Name = "m_buttonExcel";
            this.m_buttonExcel.Size = new System.Drawing.Size(86, 29);
            this.m_buttonExcel.TabIndex = 8;
            this.m_buttonExcel.Text = "В Excel";
            this.m_buttonExcel.UseVisualStyleBackColor = true;
            this.m_buttonExcel.Click += new System.EventHandler(this.ButtonExcelClickHandler);
            // 
            // FormHoursDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 353);
            this.Controls.Add(this.m_panelButtons);
            this.Controls.Add(this.m_dataGridDeduction);
            this.Controls.Add(this.m_dateDeduction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_dateStartSemester);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_comboBoxSemesters);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FormHoursDeduction";
            this.Text = "Вычет часов";
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridDeduction)).EndInit();
            this.m_panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox m_comboBoxSemesters;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker m_dateStartSemester;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DateTimePicker m_dateDeduction;
    private System.Windows.Forms.DataGridView m_dataGridDeduction;
    private System.Windows.Forms.Button m_buttonCalculate;
    private System.Windows.Forms.Panel m_panelButtons;
    private System.Windows.Forms.Button m_buttonExcel;
    private System.Windows.Forms.DataGridViewTextBoxColumn Subjects;
    private System.Windows.Forms.DataGridViewTextBoxColumn ActuallyHours;
    private System.Windows.Forms.DataGridViewTextBoxColumn MustBeHours;
    private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
}