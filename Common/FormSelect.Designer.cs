partial class FormSelect
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
            this.m_dataGridView = new System.Windows.Forms.DataGridView();
            this.m_panelButtons = new System.Windows.Forms.Panel();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.m_buttonReset = new System.Windows.Forms.Button();
            this.m_buttonSearch = new System.Windows.Forms.Button();
            this.m_textBoxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_comboBoxColumns = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).BeginInit();
            this.m_panelButtons.SuspendLayout();
            this.m_groupBoxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dataGridView
            // 
            this.m_dataGridView.AllowUserToAddRows = false;
            this.m_dataGridView.AllowUserToDeleteRows = false;
            this.m_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.m_dataGridView.Name = "m_dataGridView";
            this.m_dataGridView.ReadOnly = true;
            this.m_dataGridView.RowHeadersVisible = false;
            this.m_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dataGridView.Size = new System.Drawing.Size(333, 247);
            this.m_dataGridView.TabIndex = 0;
            // 
            // m_panelButtons
            // 
            this.m_panelButtons.Controls.Add(this.m_buttonCancel);
            this.m_panelButtons.Controls.Add(this.m_buttonOK);
            this.m_panelButtons.Location = new System.Drawing.Point(0, 247);
            this.m_panelButtons.Name = "m_panelButtons";
            this.m_panelButtons.Size = new System.Drawing.Size(495, 43);
            this.m_panelButtons.TabIndex = 1;
            this.m_panelButtons.Resize += new System.EventHandler(this.PanelButtonsResizeHandler);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonCancel.Location = new System.Drawing.Point(408, 3);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.m_buttonCancel.TabIndex = 1;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.ButtonCancelClickHandler);
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonOK.Location = new System.Drawing.Point(12, 3);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 29);
            this.m_buttonOK.TabIndex = 0;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickHandler);
            // 
            // m_groupBoxSearch
            // 
            this.m_groupBoxSearch.Controls.Add(this.m_buttonReset);
            this.m_groupBoxSearch.Controls.Add(this.m_buttonSearch);
            this.m_groupBoxSearch.Controls.Add(this.m_textBoxSearch);
            this.m_groupBoxSearch.Controls.Add(this.label2);
            this.m_groupBoxSearch.Controls.Add(this.m_comboBoxColumns);
            this.m_groupBoxSearch.Controls.Add(this.label1);
            this.m_groupBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_groupBoxSearch.Location = new System.Drawing.Point(334, 0);
            this.m_groupBoxSearch.Name = "m_groupBoxSearch";
            this.m_groupBoxSearch.Size = new System.Drawing.Size(160, 247);
            this.m_groupBoxSearch.TabIndex = 2;
            this.m_groupBoxSearch.TabStop = false;
            this.m_groupBoxSearch.Text = "Поиск";
            // 
            // m_buttonReset
            // 
            this.m_buttonReset.Location = new System.Drawing.Point(37, 151);
            this.m_buttonReset.Name = "m_buttonReset";
            this.m_buttonReset.Size = new System.Drawing.Size(75, 29);
            this.m_buttonReset.TabIndex = 5;
            this.m_buttonReset.Text = "Сброс";
            this.m_buttonReset.UseVisualStyleBackColor = true;
            this.m_buttonReset.Click += new System.EventHandler(this.ButtonResetClickHandler);
            // 
            // m_buttonSearch
            // 
            this.m_buttonSearch.Location = new System.Drawing.Point(37, 116);
            this.m_buttonSearch.Name = "m_buttonSearch";
            this.m_buttonSearch.Size = new System.Drawing.Size(75, 29);
            this.m_buttonSearch.TabIndex = 4;
            this.m_buttonSearch.Text = "Поиск";
            this.m_buttonSearch.UseVisualStyleBackColor = true;
            this.m_buttonSearch.Click += new System.EventHandler(this.ButtonSearchClickHandler);
            // 
            // m_textBoxSearch
            // 
            this.m_textBoxSearch.Location = new System.Drawing.Point(6, 89);
            this.m_textBoxSearch.Name = "m_textBoxSearch";
            this.m_textBoxSearch.Size = new System.Drawing.Size(143, 21);
            this.m_textBoxSearch.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Значение:";
            // 
            // m_comboBoxColumns
            // 
            this.m_comboBoxColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxColumns.FormattingEnabled = true;
            this.m_comboBoxColumns.Location = new System.Drawing.Point(6, 45);
            this.m_comboBoxColumns.Name = "m_comboBoxColumns";
            this.m_comboBoxColumns.Size = new System.Drawing.Size(143, 23);
            this.m_comboBoxColumns.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Столбец для поиска:";
            // 
            // FormSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 287);
            this.Controls.Add(this.m_groupBoxSearch);
            this.Controls.Add(this.m_panelButtons);
            this.Controls.Add(this.m_dataGridView);
            this.Name = "FormSelect";
            this.Text = "Выбор";
            this.Load += new System.EventHandler(this.LoadHandler);
            this.Resize += new System.EventHandler(this.ResizeHandler);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).EndInit();
            this.m_panelButtons.ResumeLayout(false);
            this.m_groupBoxSearch.ResumeLayout(false);
            this.m_groupBoxSearch.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView m_dataGridView;
    private System.Windows.Forms.Panel m_panelButtons;
    private System.Windows.Forms.Button m_buttonOK;
    private System.Windows.Forms.Button m_buttonCancel;
    private System.Windows.Forms.GroupBox m_groupBoxSearch;
    private System.Windows.Forms.Button m_buttonSearch;
    private System.Windows.Forms.TextBox m_textBoxSearch;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox m_comboBoxColumns;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button m_buttonReset;
}