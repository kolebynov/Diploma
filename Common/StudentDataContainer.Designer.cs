partial class StudentDataContainer
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
            this.m_labelSecondName = new System.Windows.Forms.Label();
            this.m_labelFirstName = new System.Windows.Forms.Label();
            this.m_labelMiddleName = new System.Windows.Forms.Label();
            this.m_textSecondName = new System.Windows.Forms.TextBox();
            this.m_textFirstName = new System.Windows.Forms.TextBox();
            this.m_textMiddleName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_labelSecondName
            // 
            this.m_labelSecondName.AutoSize = true;
            this.m_labelSecondName.Location = new System.Drawing.Point(3, 11);
            this.m_labelSecondName.Name = "m_labelSecondName";
            this.m_labelSecondName.Size = new System.Drawing.Size(59, 13);
            this.m_labelSecondName.TabIndex = 0;
            this.m_labelSecondName.Text = "Фамилия:";
            // 
            // m_labelFirstName
            // 
            this.m_labelFirstName.AutoSize = true;
            this.m_labelFirstName.Location = new System.Drawing.Point(152, 11);
            this.m_labelFirstName.Name = "m_labelFirstName";
            this.m_labelFirstName.Size = new System.Drawing.Size(32, 13);
            this.m_labelFirstName.TabIndex = 1;
            this.m_labelFirstName.Text = "Имя:";
            // 
            // m_labelMiddleName
            // 
            this.m_labelMiddleName.AutoSize = true;
            this.m_labelMiddleName.Location = new System.Drawing.Point(274, 11);
            this.m_labelMiddleName.Name = "m_labelMiddleName";
            this.m_labelMiddleName.Size = new System.Drawing.Size(57, 13);
            this.m_labelMiddleName.TabIndex = 2;
            this.m_labelMiddleName.Text = "Отчество:";
            // 
            // m_textSecondName
            // 
            this.m_textSecondName.Location = new System.Drawing.Point(68, 8);
            this.m_textSecondName.Name = "m_textSecondName";
            this.m_textSecondName.Size = new System.Drawing.Size(78, 20);
            this.m_textSecondName.TabIndex = 3;
            // 
            // m_textFirstName
            // 
            this.m_textFirstName.Location = new System.Drawing.Point(190, 8);
            this.m_textFirstName.Name = "m_textFirstName";
            this.m_textFirstName.Size = new System.Drawing.Size(78, 20);
            this.m_textFirstName.TabIndex = 4;
            // 
            // m_textMiddleName
            // 
            this.m_textMiddleName.Location = new System.Drawing.Point(337, 8);
            this.m_textMiddleName.Name = "m_textMiddleName";
            this.m_textMiddleName.Size = new System.Drawing.Size(78, 20);
            this.m_textMiddleName.TabIndex = 5;
            // 
            // StudentDataContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_textMiddleName);
            this.Controls.Add(this.m_textFirstName);
            this.Controls.Add(this.m_textSecondName);
            this.Controls.Add(this.m_labelMiddleName);
            this.Controls.Add(this.m_labelFirstName);
            this.Controls.Add(this.m_labelSecondName);
            this.Name = "StudentDataContainer";
            this.Size = new System.Drawing.Size(426, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label m_labelSecondName;
    private System.Windows.Forms.Label m_labelFirstName;
    private System.Windows.Forms.Label m_labelMiddleName;
    private System.Windows.Forms.TextBox m_textSecondName;
    private System.Windows.Forms.TextBox m_textFirstName;
    private System.Windows.Forms.TextBox m_textMiddleName;
}
