partial class GroupSelector
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
            this.m_labelGroup = new System.Windows.Forms.Label();
            this.m_textBoxGroup = new System.Windows.Forms.TextBox();
            this.m_buttonChangeGroup = new System.Windows.Forms.Button();
            this.m_buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_labelGroup
            // 
            this.m_labelGroup.AutoSize = true;
            this.m_labelGroup.Location = new System.Drawing.Point(3, 10);
            this.m_labelGroup.Name = "m_labelGroup";
            this.m_labelGroup.Size = new System.Drawing.Size(50, 15);
            this.m_labelGroup.TabIndex = 0;
            this.m_labelGroup.Text = "Группа:";
            // 
            // m_textBoxGroup
            // 
            this.m_textBoxGroup.Location = new System.Drawing.Point(63, 7);
            this.m_textBoxGroup.Name = "m_textBoxGroup";
            this.m_textBoxGroup.ReadOnly = true;
            this.m_textBoxGroup.Size = new System.Drawing.Size(116, 21);
            this.m_textBoxGroup.TabIndex = 1;
            // 
            // m_buttonChangeGroup
            // 
            this.m_buttonChangeGroup.Location = new System.Drawing.Point(187, 0);
            this.m_buttonChangeGroup.Name = "m_buttonChangeGroup";
            this.m_buttonChangeGroup.Size = new System.Drawing.Size(87, 23);
            this.m_buttonChangeGroup.TabIndex = 2;
            this.m_buttonChangeGroup.Text = "Изменить";
            this.m_buttonChangeGroup.UseVisualStyleBackColor = true;
            this.m_buttonChangeGroup.Click += new System.EventHandler(this.ButtonChangeGroupClickHandler);
            // 
            // m_buttonReset
            // 
            this.m_buttonReset.Location = new System.Drawing.Point(187, 23);
            this.m_buttonReset.Name = "m_buttonReset";
            this.m_buttonReset.Size = new System.Drawing.Size(87, 23);
            this.m_buttonReset.TabIndex = 3;
            this.m_buttonReset.Text = "Сбросить";
            this.m_buttonReset.UseVisualStyleBackColor = true;
            this.m_buttonReset.Click += new System.EventHandler(this.ButtonResetClickHandler);
            // 
            // GroupSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_buttonReset);
            this.Controls.Add(this.m_buttonChangeGroup);
            this.Controls.Add(this.m_textBoxGroup);
            this.Controls.Add(this.m_labelGroup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GroupSelector";
            this.Size = new System.Drawing.Size(287, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label m_labelGroup;
    private System.Windows.Forms.TextBox m_textBoxGroup;
    private System.Windows.Forms.Button m_buttonChangeGroup;
    private System.Windows.Forms.Button m_buttonReset;
}