partial class SubjectTypeContainer
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
            this.m_textBoxTypeName = new TextBoxChanged();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_comboBoxGlobalType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_textBoxTypeName
            // 
            this.m_textBoxTypeName.IsChanged = true;
            this.m_textBoxTypeName.Location = new System.Drawing.Point(75, 1);
            this.m_textBoxTypeName.Name = "m_textBoxTypeName";
            this.m_textBoxTypeName.Size = new System.Drawing.Size(116, 21);
            this.m_textBoxTypeName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя типа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Глобальный тип:";
            // 
            // m_comboBoxGlobalType
            // 
            this.m_comboBoxGlobalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxGlobalType.FormattingEnabled = true;
            this.m_comboBoxGlobalType.Items.AddRange(new object[] {
            "Общеобразовательный компонент",
            "Профессиональный компонент"});
            this.m_comboBoxGlobalType.Location = new System.Drawing.Point(309, 1);
            this.m_comboBoxGlobalType.Name = "m_comboBoxGlobalType";
            this.m_comboBoxGlobalType.Size = new System.Drawing.Size(156, 23);
            this.m_comboBoxGlobalType.TabIndex = 3;
            this.m_comboBoxGlobalType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGlobalTypeSelectedIndexChangedHandler);
            // 
            // SubjectTypeContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_comboBoxGlobalType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_textBoxTypeName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "SubjectTypeContainer";
            this.Size = new System.Drawing.Size(468, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TextBoxChanged m_textBoxTypeName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox m_comboBoxGlobalType;
}
