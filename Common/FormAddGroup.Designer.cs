partial class FormAddGroup
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
            m_groupTypesTable.Dispose();
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
            this.m_textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_comboBoxType = new System.Windows.Forms.ComboBox();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование группы:";
            // 
            // m_textBoxName
            // 
            this.m_textBoxName.Location = new System.Drawing.Point(159, 18);
            this.m_textBoxName.Name = "m_textBoxName";
            this.m_textBoxName.Size = new System.Drawing.Size(160, 20);
            this.m_textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип группы:";
            // 
            // m_comboBoxType
            // 
            this.m_comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxType.FormattingEnabled = true;
            this.m_comboBoxType.Location = new System.Drawing.Point(159, 48);
            this.m_comboBoxType.Name = "m_comboBoxType";
            this.m_comboBoxType.Size = new System.Drawing.Size(160, 21);
            this.m_comboBoxType.TabIndex = 3;
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonOK.Location = new System.Drawing.Point(15, 115);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 28);
            this.m_buttonOK.TabIndex = 4;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickHandler);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonCancel.Location = new System.Drawing.Point(244, 115);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 28);
            this.m_buttonCancel.TabIndex = 5;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.ButtonCancelClickHandler);
            // 
            // FormAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 155);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOK);
            this.Controls.Add(this.m_comboBoxType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_textBoxName);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(347, 194);
            this.MinimumSize = new System.Drawing.Size(347, 194);
            this.Name = "FormAddGroup";
            this.Text = "Добавление группы";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_textBoxName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox m_comboBoxType;
    private System.Windows.Forms.Button m_buttonOK;
    private System.Windows.Forms.Button m_buttonCancel;
}