partial class FormSettingConnection
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
            this.m_comboServerName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_comboDBName = new System.Windows.Forms.ComboBox();
            this.m_groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.m_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_texBoxPass = new System.Windows.Forms.TextBox();
            this.m_textBoxLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_checkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_buttonCheckConnection = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_groupBoxSettings.SuspendLayout();
            this.m_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя сервера:";
            // 
            // m_comboServerName
            // 
            this.m_comboServerName.FormattingEnabled = true;
            this.m_comboServerName.Location = new System.Drawing.Point(98, 24);
            this.m_comboServerName.Name = "m_comboServerName";
            this.m_comboServerName.Size = new System.Drawing.Size(166, 23);
            this.m_comboServerName.TabIndex = 1;
            this.m_comboServerName.DropDown += new System.EventHandler(this.ComboServerNameDropDownHandler);
            this.m_comboServerName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя БД:";
            // 
            // m_comboDBName
            // 
            this.m_comboDBName.FormattingEnabled = true;
            this.m_comboDBName.Location = new System.Drawing.Point(98, 51);
            this.m_comboDBName.Name = "m_comboDBName";
            this.m_comboDBName.Size = new System.Drawing.Size(166, 23);
            this.m_comboDBName.TabIndex = 3;
            this.m_comboDBName.DropDown += new System.EventHandler(this.ComboDBNameDropDownHandler);
            this.m_comboDBName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // m_groupBoxSettings
            // 
            this.m_groupBoxSettings.Controls.Add(this.m_panel);
            this.m_groupBoxSettings.Controls.Add(this.m_checkIntegratedSecurity);
            this.m_groupBoxSettings.Controls.Add(this.label1);
            this.m_groupBoxSettings.Controls.Add(this.m_comboDBName);
            this.m_groupBoxSettings.Controls.Add(this.m_comboServerName);
            this.m_groupBoxSettings.Controls.Add(this.label2);
            this.m_groupBoxSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_groupBoxSettings.Location = new System.Drawing.Point(0, 0);
            this.m_groupBoxSettings.Name = "m_groupBoxSettings";
            this.m_groupBoxSettings.Size = new System.Drawing.Size(293, 170);
            this.m_groupBoxSettings.TabIndex = 4;
            this.m_groupBoxSettings.TabStop = false;
            this.m_groupBoxSettings.Text = "Параметры";
            // 
            // m_panel
            // 
            this.m_panel.Controls.Add(this.label3);
            this.m_panel.Controls.Add(this.m_texBoxPass);
            this.m_panel.Controls.Add(this.m_textBoxLogin);
            this.m_panel.Controls.Add(this.label4);
            this.m_panel.Location = new System.Drawing.Point(6, 108);
            this.m_panel.Name = "m_panel";
            this.m_panel.Size = new System.Drawing.Size(276, 56);
            this.m_panel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Имя входа:";
            // 
            // m_texBoxPass
            // 
            this.m_texBoxPass.Location = new System.Drawing.Point(92, 28);
            this.m_texBoxPass.Name = "m_texBoxPass";
            this.m_texBoxPass.PasswordChar = '*';
            this.m_texBoxPass.Size = new System.Drawing.Size(166, 21);
            this.m_texBoxPass.TabIndex = 8;
            this.m_texBoxPass.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // m_textBoxLogin
            // 
            this.m_textBoxLogin.Location = new System.Drawing.Point(92, 2);
            this.m_textBoxLogin.Name = "m_textBoxLogin";
            this.m_textBoxLogin.Size = new System.Drawing.Size(166, 21);
            this.m_textBoxLogin.TabIndex = 6;
            this.m_textBoxLogin.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль:";
            // 
            // m_checkIntegratedSecurity
            // 
            this.m_checkIntegratedSecurity.AutoSize = true;
            this.m_checkIntegratedSecurity.Location = new System.Drawing.Point(9, 83);
            this.m_checkIntegratedSecurity.Name = "m_checkIntegratedSecurity";
            this.m_checkIntegratedSecurity.Size = new System.Drawing.Size(215, 19);
            this.m_checkIntegratedSecurity.TabIndex = 4;
            this.m_checkIntegratedSecurity.Text = "Проверка подлинности Windows";
            this.m_checkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.m_checkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.CheckIntegratedSecurityCheckedChangedHandler);
            this.m_checkIntegratedSecurity.CheckStateChanged += new System.EventHandler(this.ValueChanged);
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Location = new System.Drawing.Point(12, 176);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 28);
            this.m_buttonOK.TabIndex = 5;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickHandler);
            // 
            // m_buttonCheckConnection
            // 
            this.m_buttonCheckConnection.Location = new System.Drawing.Point(109, 176);
            this.m_buttonCheckConnection.Name = "m_buttonCheckConnection";
            this.m_buttonCheckConnection.Size = new System.Drawing.Size(81, 28);
            this.m_buttonCheckConnection.TabIndex = 6;
            this.m_buttonCheckConnection.Text = "Проверить";
            this.m_buttonCheckConnection.UseVisualStyleBackColor = true;
            this.m_buttonCheckConnection.Click += new System.EventHandler(this.ButtonCheckConnectionClickHandler);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Location = new System.Drawing.Point(207, 176);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 28);
            this.m_buttonCancel.TabIndex = 7;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.ButtonCancelClickHandler);
            // 
            // FormSettingConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 214);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonCheckConnection);
            this.Controls.Add(this.m_buttonOK);
            this.Controls.Add(this.m_groupBoxSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 253);
            this.MinimumSize = new System.Drawing.Size(310, 253);
            this.Name = "FormSettingConnection";
            this.Text = "Настройка подключения";
            this.m_groupBoxSettings.ResumeLayout(false);
            this.m_groupBoxSettings.PerformLayout();
            this.m_panel.ResumeLayout(false);
            this.m_panel.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox m_comboServerName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox m_comboDBName;
    private System.Windows.Forms.GroupBox m_groupBoxSettings;
    private System.Windows.Forms.TextBox m_textBoxLogin;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox m_checkIntegratedSecurity;
    private System.Windows.Forms.Panel m_panel;
    private System.Windows.Forms.TextBox m_texBoxPass;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button m_buttonOK;
    private System.Windows.Forms.Button m_buttonCheckConnection;
    private System.Windows.Forms.Button m_buttonCancel;
}