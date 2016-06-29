partial class FormAddStudent
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
            m_studentList.Clear();
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
            this.m_buttonAddStudent = new System.Windows.Forms.Button();
            this.m_buttonDeleteStudent = new System.Windows.Forms.Button();
            this.m_buttonsPanel = new System.Windows.Forms.Panel();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_groupSelector = new GroupSelector();
            this.m_buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_buttonAddStudent
            // 
            this.m_buttonAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonAddStudent.Location = new System.Drawing.Point(5, 3);
            this.m_buttonAddStudent.Name = "m_buttonAddStudent";
            this.m_buttonAddStudent.Size = new System.Drawing.Size(75, 29);
            this.m_buttonAddStudent.TabIndex = 2;
            this.m_buttonAddStudent.Text = "Добавить";
            this.m_buttonAddStudent.UseVisualStyleBackColor = true;
            this.m_buttonAddStudent.Click += new System.EventHandler(this.ButtonAddStudentClickHandler);
            // 
            // m_buttonDeleteStudent
            // 
            this.m_buttonDeleteStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonDeleteStudent.Location = new System.Drawing.Point(86, 3);
            this.m_buttonDeleteStudent.Name = "m_buttonDeleteStudent";
            this.m_buttonDeleteStudent.Size = new System.Drawing.Size(75, 29);
            this.m_buttonDeleteStudent.TabIndex = 3;
            this.m_buttonDeleteStudent.Text = "Удалить";
            this.m_buttonDeleteStudent.UseVisualStyleBackColor = true;
            this.m_buttonDeleteStudent.Click += new System.EventHandler(this.ButtonDeleteStudentClickHandler);
            // 
            // m_buttonsPanel
            // 
            this.m_buttonsPanel.Controls.Add(this.m_buttonCancel);
            this.m_buttonsPanel.Controls.Add(this.m_buttonApply);
            this.m_buttonsPanel.Controls.Add(this.m_buttonOK);
            this.m_buttonsPanel.Controls.Add(this.m_buttonAddStudent);
            this.m_buttonsPanel.Controls.Add(this.m_buttonDeleteStudent);
            this.m_buttonsPanel.Location = new System.Drawing.Point(0, 263);
            this.m_buttonsPanel.Name = "m_buttonsPanel";
            this.m_buttonsPanel.Size = new System.Drawing.Size(529, 89);
            this.m_buttonsPanel.TabIndex = 4;
            this.m_buttonsPanel.Resize += new System.EventHandler(this.ButtonsPanelResizeHandler);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonCancel.Location = new System.Drawing.Point(439, 48);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.m_buttonCancel.TabIndex = 6;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.ButtonCancelClickHandler);
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonApply.Location = new System.Drawing.Point(224, 48);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(83, 29);
            this.m_buttonApply.TabIndex = 5;
            this.m_buttonApply.Text = "Применить";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.ButtonApplyClickHandler);
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonOK.Location = new System.Drawing.Point(5, 48);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 29);
            this.m_buttonOK.TabIndex = 4;
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
            this.m_groupSelector.Size = new System.Drawing.Size(529, 50);
            this.m_groupSelector.TabIndex = 1;
            // 
            // FormAddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 352);
            this.Controls.Add(this.m_buttonsPanel);
            this.Controls.Add(this.m_groupSelector);
            this.MinimumSize = new System.Drawing.Size(300, 39);
            this.Name = "FormAddStudent";
            this.Text = "Добавление студентов";
            this.Resize += new System.EventHandler(this.ResizeHandler);
            this.m_buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private GroupSelector m_groupSelector;
    private System.Windows.Forms.Button m_buttonAddStudent;
    private System.Windows.Forms.Button m_buttonDeleteStudent;
    private System.Windows.Forms.Panel m_buttonsPanel;
    private System.Windows.Forms.Button m_buttonCancel;
    private System.Windows.Forms.Button m_buttonApply;
    private System.Windows.Forms.Button m_buttonOK;
}