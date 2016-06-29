partial class FormPlanName
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
            this.m_textBoxName = new System.Windows.Forms.TextBox();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите имя для плана:";
            // 
            // m_textBoxName
            // 
            this.m_textBoxName.Location = new System.Drawing.Point(166, 6);
            this.m_textBoxName.Name = "m_textBoxName";
            this.m_textBoxName.Size = new System.Drawing.Size(182, 21);
            this.m_textBoxName.TabIndex = 1;
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Location = new System.Drawing.Point(141, 45);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 29);
            this.m_buttonOK.TabIndex = 2;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickhandler);
            // 
            // FormPlanName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 83);
            this.Controls.Add(this.m_buttonOK);
            this.Controls.Add(this.m_textBoxName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(383, 122);
            this.MinimumSize = new System.Drawing.Size(383, 122);
            this.Name = "FormPlanName";
            this.Text = "Имя плана";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_textBoxName;
    private System.Windows.Forms.Button m_buttonOK;
}