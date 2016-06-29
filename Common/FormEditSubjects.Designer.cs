partial class FormEditSubjects
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
            this.m_panelButtons = new System.Windows.Forms.Panel();
            this.m_buttonDelete = new System.Windows.Forms.Button();
            this.m_buttonAdd = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelButtons
            // 
            this.m_panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelButtons.Controls.Add(this.m_buttonDelete);
            this.m_panelButtons.Controls.Add(this.m_buttonAdd);
            this.m_panelButtons.Controls.Add(this.m_buttonCancel);
            this.m_panelButtons.Controls.Add(this.m_buttonOK);
            this.m_panelButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_panelButtons.Location = new System.Drawing.Point(0, 228);
            this.m_panelButtons.Name = "m_panelButtons";
            this.m_panelButtons.Size = new System.Drawing.Size(529, 74);
            this.m_panelButtons.TabIndex = 2;
            // 
            // m_buttonDelete
            // 
            this.m_buttonDelete.Location = new System.Drawing.Point(93, 3);
            this.m_buttonDelete.Name = "m_buttonDelete";
            this.m_buttonDelete.Size = new System.Drawing.Size(75, 29);
            this.m_buttonDelete.TabIndex = 3;
            this.m_buttonDelete.Text = "Удалить";
            this.m_buttonDelete.UseVisualStyleBackColor = true;
            this.m_buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClickHandler);
            // 
            // m_buttonAdd
            // 
            this.m_buttonAdd.Location = new System.Drawing.Point(12, 3);
            this.m_buttonAdd.Name = "m_buttonAdd";
            this.m_buttonAdd.Size = new System.Drawing.Size(75, 29);
            this.m_buttonAdd.TabIndex = 2;
            this.m_buttonAdd.Text = "Добавить";
            this.m_buttonAdd.UseVisualStyleBackColor = true;
            this.m_buttonAdd.Click += new System.EventHandler(this.ButtonAddClickHandler);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.Location = new System.Drawing.Point(441, 38);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.m_buttonCancel.TabIndex = 1;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.ButtonCancelClickHandler);
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Location = new System.Drawing.Point(12, 38);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 29);
            this.m_buttonOK.TabIndex = 0;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickHandler);
            // 
            // FormEditSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 301);
            this.Controls.Add(this.m_panelButtons);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FormEditSubjects";
            this.Text = "Редактирование дисциплин";
            this.m_panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel m_panelButtons;
    private System.Windows.Forms.Button m_buttonDelete;
    private System.Windows.Forms.Button m_buttonAdd;
    private System.Windows.Forms.Button m_buttonCancel;
    private System.Windows.Forms.Button m_buttonOK;
}