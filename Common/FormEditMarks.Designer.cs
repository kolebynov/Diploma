partial class FormEditMarks
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
            m_dataSet.Dispose();
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
            this.m_dataGridMarks = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_comboBoxSemesters = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonAward = new System.Windows.Forms.Button();
            this.m_buttonExcel = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_groupSelector = new GroupSelector();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridMarks)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dataGridMarks
            // 
            this.m_dataGridMarks.AllowUserToAddRows = false;
            this.m_dataGridMarks.AllowUserToDeleteRows = false;
            this.m_dataGridMarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dataGridMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridMarks.ColumnHeadersVisible = false;
            this.m_dataGridMarks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.m_dataGridMarks.Location = new System.Drawing.Point(0, 50);
            this.m_dataGridMarks.Name = "m_dataGridMarks";
            this.m_dataGridMarks.RowHeadersVisible = false;
            this.m_dataGridMarks.Size = new System.Drawing.Size(535, 184);
            this.m_dataGridMarks.TabIndex = 1;
            this.m_dataGridMarks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridMarksCellClickHandler);
            this.m_dataGridMarks.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridMarksCellValidatingHandler);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(285, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите семестр:";
            // 
            // m_comboBoxSemesters
            // 
            this.m_comboBoxSemesters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxSemesters.FormattingEnabled = true;
            this.m_comboBoxSemesters.Location = new System.Drawing.Point(412, 15);
            this.m_comboBoxSemesters.Name = "m_comboBoxSemesters";
            this.m_comboBoxSemesters.Size = new System.Drawing.Size(53, 21);
            this.m_comboBoxSemesters.TabIndex = 3;
            this.m_comboBoxSemesters.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSemestersSelectedIndexChangedHandler);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_buttonApply);
            this.panel1.Controls.Add(this.m_buttonAward);
            this.panel1.Controls.Add(this.m_buttonExcel);
            this.panel1.Controls.Add(this.m_buttonCancel);
            this.panel1.Controls.Add(this.m_buttonOK);
            this.panel1.Location = new System.Drawing.Point(0, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 86);
            this.panel1.TabIndex = 4;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonApply.Location = new System.Drawing.Point(163, 45);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(85, 29);
            this.m_buttonApply.TabIndex = 4;
            this.m_buttonApply.Text = "Применить";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.ButtonApplyClickHandler);
            // 
            // m_buttonAward
            // 
            this.m_buttonAward.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonAward.Location = new System.Drawing.Point(12, 10);
            this.m_buttonAward.Name = "m_buttonAward";
            this.m_buttonAward.Size = new System.Drawing.Size(145, 29);
            this.m_buttonAward.TabIndex = 3;
            this.m_buttonAward.Text = "Ведомость стипендии";
            this.m_buttonAward.UseVisualStyleBackColor = true;
            this.m_buttonAward.Click += new System.EventHandler(this.ButtonAwardClickHandler);
            // 
            // m_buttonExcel
            // 
            this.m_buttonExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonExcel.Location = new System.Drawing.Point(163, 10);
            this.m_buttonExcel.Name = "m_buttonExcel";
            this.m_buttonExcel.Size = new System.Drawing.Size(75, 29);
            this.m_buttonExcel.TabIndex = 2;
            this.m_buttonExcel.Text = "В Excel";
            this.m_buttonExcel.UseVisualStyleBackColor = true;
            this.m_buttonExcel.Click += new System.EventHandler(this.ButtonExcelClickHandler);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonCancel.Location = new System.Drawing.Point(449, 45);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.m_buttonCancel.TabIndex = 1;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.ButtonCancelClickhandler);
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonOK.Location = new System.Drawing.Point(12, 45);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 29);
            this.m_buttonOK.TabIndex = 0;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickHandler);
            // 
            // m_groupSelector
            // 
            this.m_groupSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_groupSelector.College = null;
            this.m_groupSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_groupSelector.GroupInfo = null;
            this.m_groupSelector.GroupTypeId = ((short)(0));
            this.m_groupSelector.Location = new System.Drawing.Point(0, 0);
            this.m_groupSelector.Name = "m_groupSelector";
            this.m_groupSelector.Size = new System.Drawing.Size(280, 52);
            this.m_groupSelector.TabIndex = 0;
            this.m_groupSelector.GroupChanged += new System.EventHandler(this.GroupSelectorGroupChangedHandler);
            // 
            // FormEditMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 319);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_comboBoxSemesters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_dataGridMarks);
            this.Controls.Add(this.m_groupSelector);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FormEditMarks";
            this.Text = "Успеваемость";
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridMarks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private GroupSelector m_groupSelector;
    private System.Windows.Forms.DataGridView m_dataGridMarks;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox m_comboBoxSemesters;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button m_buttonOK;
    private System.Windows.Forms.Button m_buttonCancel;
    private System.Windows.Forms.Button m_buttonExcel;
    private System.Windows.Forms.Button m_buttonAward;
    private System.Windows.Forms.Button m_buttonApply;
}