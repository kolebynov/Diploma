partial class PlanSelector
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
            this.m_textBoxGroup = new System.Windows.Forms.TextBox();
            this.m_buttonPlanSelector = new System.Windows.Forms.Button();
            this.m_buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "План:";
            // 
            // m_textBoxGroup
            // 
            this.m_textBoxGroup.Location = new System.Drawing.Point(49, 7);
            this.m_textBoxGroup.Name = "m_textBoxGroup";
            this.m_textBoxGroup.ReadOnly = true;
            this.m_textBoxGroup.Size = new System.Drawing.Size(140, 21);
            this.m_textBoxGroup.TabIndex = 1;
            // 
            // m_buttonPlanSelector
            // 
            this.m_buttonPlanSelector.Location = new System.Drawing.Point(195, 0);
            this.m_buttonPlanSelector.Name = "m_buttonPlanSelector";
            this.m_buttonPlanSelector.Size = new System.Drawing.Size(87, 23);
            this.m_buttonPlanSelector.TabIndex = 2;
            this.m_buttonPlanSelector.Text = "Изменить";
            this.m_buttonPlanSelector.UseVisualStyleBackColor = true;
            this.m_buttonPlanSelector.Click += new System.EventHandler(this.ButtonChangeGroupClickHandler);
            // 
            // m_buttonReset
            // 
            this.m_buttonReset.Location = new System.Drawing.Point(195, 23);
            this.m_buttonReset.Name = "m_buttonReset";
            this.m_buttonReset.Size = new System.Drawing.Size(87, 23);
            this.m_buttonReset.TabIndex = 3;
            this.m_buttonReset.Text = "Сбросить";
            this.m_buttonReset.UseVisualStyleBackColor = true;
            this.m_buttonReset.Click += new System.EventHandler(this.ButtonResetClickHandler);
            // 
            // PlanSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_buttonReset);
            this.Controls.Add(this.m_buttonPlanSelector);
            this.Controls.Add(this.m_textBoxGroup);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "PlanSelector";
            this.Size = new System.Drawing.Size(287, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_textBoxGroup;
    private System.Windows.Forms.Button m_buttonPlanSelector;
    private System.Windows.Forms.Button m_buttonReset;
}
