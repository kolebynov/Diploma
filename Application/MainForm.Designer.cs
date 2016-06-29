partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxParting = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveGroup = new System.Windows.Forms.Button();
            this.listBoxGroups = new System.Windows.Forms.ListBox();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveStudent = new System.Windows.Forms.Button();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.listBoxStudents = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonEditMark = new System.Windows.Forms.Button();
            this.listBoxMarks = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSheetView = new System.Windows.Forms.Button();
            this.comboBoxSemestr = new System.Windows.Forms.ComboBox();
            this.comboBoxSheet = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.m_buttonEditGroupTypes = new System.Windows.Forms.Button();
            this.m_mainMenu = new System.Windows.Forms.MenuStrip();
            this.m_itemProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.m_subitemConnectionSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.m_subitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_itemSubjects = new System.Windows.Forms.ToolStripMenuItem();
            this.m_subitemSubjects = new System.Windows.Forms.ToolStripMenuItem();
            this.m_subitemSubjectTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.m_itemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.m_subitemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.m_subitemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.m_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отделение";
            // 
            // comboBoxParting
            // 
            this.comboBoxParting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParting.FormattingEnabled = true;
            this.comboBoxParting.Location = new System.Drawing.Point(108, 33);
            this.comboBoxParting.Name = "comboBoxParting";
            this.comboBoxParting.Size = new System.Drawing.Size(444, 21);
            this.comboBoxParting.TabIndex = 3;
            this.comboBoxParting.SelectedIndexChanged += new System.EventHandler(this.UpdateGroupsListHandler);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.buttonRemoveGroup);
            this.groupBox1.Controls.Add(this.listBoxGroups);
            this.groupBox1.Controls.Add(this.buttonAddGroup);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(15, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 309);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы";
            // 
            // buttonRemoveGroup
            // 
            this.buttonRemoveGroup.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveGroup.Location = new System.Drawing.Point(148, 280);
            this.buttonRemoveGroup.Name = "buttonRemoveGroup";
            this.buttonRemoveGroup.Size = new System.Drawing.Size(66, 23);
            this.buttonRemoveGroup.TabIndex = 6;
            this.buttonRemoveGroup.Text = "Удалить";
            this.buttonRemoveGroup.UseVisualStyleBackColor = true;
            this.buttonRemoveGroup.Click += new System.EventHandler(this.RemoveGroupHandler);
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.ItemHeight = 18;
            this.listBoxGroups.Location = new System.Drawing.Point(6, 19);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(208, 256);
            this.listBoxGroups.TabIndex = 0;
            this.listBoxGroups.SelectedIndexChanged += new System.EventHandler(this.UpdateStudentsListHandler);
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonAddGroup.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddGroup.Location = new System.Drawing.Point(6, 280);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(66, 23);
            this.buttonAddGroup.TabIndex = 5;
            this.buttonAddGroup.Text = "Добавить";
            this.buttonAddGroup.UseVisualStyleBackColor = true;
            this.buttonAddGroup.Click += new System.EventHandler(this.AddGroupHandler);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.buttonRemoveStudent);
            this.groupBox2.Controls.Add(this.buttonAddStudent);
            this.groupBox2.Controls.Add(this.listBoxStudents);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(241, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 309);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Учащиеся";
            // 
            // buttonRemoveStudent
            // 
            this.buttonRemoveStudent.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveStudent.Location = new System.Drawing.Point(148, 280);
            this.buttonRemoveStudent.Name = "buttonRemoveStudent";
            this.buttonRemoveStudent.Size = new System.Drawing.Size(66, 23);
            this.buttonRemoveStudent.TabIndex = 9;
            this.buttonRemoveStudent.Text = "Удалить";
            this.buttonRemoveStudent.UseVisualStyleBackColor = true;
            this.buttonRemoveStudent.Click += new System.EventHandler(this.RemoveStudentHandler);
            // 
            // buttonAddStudent
            // 
            this.buttonAddStudent.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddStudent.Location = new System.Drawing.Point(6, 280);
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.Size = new System.Drawing.Size(66, 23);
            this.buttonAddStudent.TabIndex = 8;
            this.buttonAddStudent.Text = "Добавить";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.AddStudentHandler);
            // 
            // listBoxStudents
            // 
            this.listBoxStudents.FormattingEnabled = true;
            this.listBoxStudents.ItemHeight = 18;
            this.listBoxStudents.Location = new System.Drawing.Point(6, 19);
            this.listBoxStudents.Name = "listBoxStudents";
            this.listBoxStudents.Size = new System.Drawing.Size(208, 256);
            this.listBoxStudents.TabIndex = 1;
            this.listBoxStudents.SelectedIndexChanged += new System.EventHandler(this.UpdateMarksListHandler);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.buttonEditMark);
            this.groupBox3.Controls.Add(this.listBoxMarks);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(467, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 309);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Успеваемость";
            // 
            // buttonEditMark
            // 
            this.buttonEditMark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditMark.Location = new System.Drawing.Point(75, 280);
            this.buttonEditMark.Name = "buttonEditMark";
            this.buttonEditMark.Size = new System.Drawing.Size(68, 23);
            this.buttonEditMark.TabIndex = 10;
            this.buttonEditMark.Text = "Изменить";
            this.buttonEditMark.UseVisualStyleBackColor = true;
            this.buttonEditMark.Click += new System.EventHandler(this.buttonEditMark_Click);
            // 
            // listBoxMarks
            // 
            this.listBoxMarks.FormattingEnabled = true;
            this.listBoxMarks.ItemHeight = 18;
            this.listBoxMarks.Location = new System.Drawing.Point(6, 19);
            this.listBoxMarks.Name = "listBoxMarks";
            this.listBoxMarks.Size = new System.Drawing.Size(208, 256);
            this.listBoxMarks.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.buttonSheetView);
            this.groupBox4.Controls.Add(this.comboBoxSemestr);
            this.groupBox4.Controls.Add(this.comboBoxSheet);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(15, 380);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 80);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ведомость";
            // 
            // buttonSheetView
            // 
            this.buttonSheetView.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSheetView.Location = new System.Drawing.Point(11, 46);
            this.buttonSheetView.Name = "buttonSheetView";
            this.buttonSheetView.Size = new System.Drawing.Size(203, 23);
            this.buttonSheetView.TabIndex = 2;
            this.buttonSheetView.Text = "Вывод ведомости";
            this.buttonSheetView.UseVisualStyleBackColor = true;
            this.buttonSheetView.Click += new System.EventHandler(this.ViewSheetHandler);
            // 
            // comboBoxSemestr
            // 
            this.comboBoxSemestr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSemestr.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSemestr.FormattingEnabled = true;
            this.comboBoxSemestr.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxSemestr.Location = new System.Drawing.Point(168, 19);
            this.comboBoxSemestr.Name = "comboBoxSemestr";
            this.comboBoxSemestr.Size = new System.Drawing.Size(46, 22);
            this.comboBoxSemestr.TabIndex = 1;
            // 
            // comboBoxSheet
            // 
            this.comboBoxSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSheet.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSheet.FormattingEnabled = true;
            this.comboBoxSheet.Items.AddRange(new object[] {
            "Семестровая",
            "Итоговая"});
            this.comboBoxSheet.Location = new System.Drawing.Point(11, 19);
            this.comboBoxSheet.Name = "comboBoxSheet";
            this.comboBoxSheet.Size = new System.Drawing.Size(151, 22);
            this.comboBoxSheet.TabIndex = 0;
            this.comboBoxSheet.SelectedIndexChanged += new System.EventHandler(this.SelectSheetHandler);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(433, 52);
            this.button1.TabIndex = 8;
            this.button1.Text = "Перейти к созданию плана";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_buttonEditGroupTypes
            // 
            this.m_buttonEditGroupTypes.Location = new System.Drawing.Point(558, 33);
            this.m_buttonEditGroupTypes.Name = "m_buttonEditGroupTypes";
            this.m_buttonEditGroupTypes.Size = new System.Drawing.Size(102, 26);
            this.m_buttonEditGroupTypes.TabIndex = 9;
            this.m_buttonEditGroupTypes.Text = "Редактировать";
            this.m_buttonEditGroupTypes.UseVisualStyleBackColor = true;
            this.m_buttonEditGroupTypes.Click += new System.EventHandler(this.ButtonEditGroupTypesClicHandler);
            // 
            // m_mainMenu
            // 
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_itemProgram,
            this.m_itemSubjects,
            this.m_itemHelp});
            this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_mainMenu.Name = "m_mainMenu";
            this.m_mainMenu.Size = new System.Drawing.Size(704, 24);
            this.m_mainMenu.TabIndex = 10;
            this.m_mainMenu.Text = "menuStrip1";
            // 
            // m_itemProgram
            // 
            this.m_itemProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_subitemConnectionSettings,
            this.m_subitemExit});
            this.m_itemProgram.Name = "m_itemProgram";
            this.m_itemProgram.Size = new System.Drawing.Size(84, 20);
            this.m_itemProgram.Text = "Программа";
            // 
            // m_subitemConnectionSettings
            // 
            this.m_subitemConnectionSettings.Name = "m_subitemConnectionSettings";
            this.m_subitemConnectionSettings.Size = new System.Drawing.Size(212, 22);
            this.m_subitemConnectionSettings.Text = "Настройка подключения";
            this.m_subitemConnectionSettings.Click += new System.EventHandler(this.SubitemConnectionSettingsClickHandler);
            // 
            // m_subitemExit
            // 
            this.m_subitemExit.Name = "m_subitemExit";
            this.m_subitemExit.Size = new System.Drawing.Size(212, 22);
            this.m_subitemExit.Text = "Выход";
            this.m_subitemExit.Click += new System.EventHandler(this.SubitemExitClickHandler);
            // 
            // m_itemSubjects
            // 
            this.m_itemSubjects.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_subitemSubjects,
            this.m_subitemSubjectTypes});
            this.m_itemSubjects.Name = "m_itemSubjects";
            this.m_itemSubjects.Size = new System.Drawing.Size(91, 20);
            this.m_itemSubjects.Text = "Дисциплины";
            // 
            // m_subitemSubjects
            // 
            this.m_subitemSubjects.Name = "m_subitemSubjects";
            this.m_subitemSubjects.Size = new System.Drawing.Size(168, 22);
            this.m_subitemSubjects.Text = "Дисциплины";
            this.m_subitemSubjects.Click += new System.EventHandler(this.SubitemSubjectsClickHandler);
            // 
            // m_subitemSubjectTypes
            // 
            this.m_subitemSubjectTypes.Name = "m_subitemSubjectTypes";
            this.m_subitemSubjectTypes.Size = new System.Drawing.Size(168, 22);
            this.m_subitemSubjectTypes.Text = "Типы дисциплин";
            this.m_subitemSubjectTypes.Click += new System.EventHandler(this.SubitemSubjectTypesClickHandler);
            // 
            // m_itemHelp
            // 
            this.m_itemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_subitemHelp,
            this.m_subitemAbout});
            this.m_itemHelp.Name = "m_itemHelp";
            this.m_itemHelp.Size = new System.Drawing.Size(65, 20);
            this.m_itemHelp.Text = "Справка";
            // 
            // m_subitemHelp
            // 
            this.m_subitemHelp.Name = "m_subitemHelp";
            this.m_subitemHelp.Size = new System.Drawing.Size(179, 22);
            this.m_subitemHelp.Text = "Просмотр справки";
            this.m_subitemHelp.Click += new System.EventHandler(this.SubitemHelpClickHandler);
            // 
            // m_subitemAbout
            // 
            this.m_subitemAbout.Name = "m_subitemAbout";
            this.m_subitemAbout.Size = new System.Drawing.Size(179, 22);
            this.m_subitemAbout.Text = "О программе";
            this.m_subitemAbout.Click += new System.EventHandler(this.SubitemAboutClickHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.BackgroundImage = global::Application.Properties.Resources.Diploma;
            this.ClientSize = new System.Drawing.Size(704, 463);
            this.Controls.Add(this.m_buttonEditGroupTypes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxParting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Автоматизированное рабочее место заведующего отделением";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBoxParting;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button buttonRemoveGroup;
    private System.Windows.Forms.ListBox listBoxGroups;
    private System.Windows.Forms.Button buttonAddGroup;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ListBox listBoxStudents;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.ListBox listBoxMarks;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.ComboBox comboBoxSemestr;
    private System.Windows.Forms.ComboBox comboBoxSheet;
    private System.Windows.Forms.Button buttonSheetView;
    private System.Windows.Forms.Button buttonRemoveStudent;
    private System.Windows.Forms.Button buttonAddStudent;
    private System.Windows.Forms.Button buttonEditMark;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button m_buttonEditGroupTypes;
    private System.Windows.Forms.MenuStrip m_mainMenu;
    private System.Windows.Forms.ToolStripMenuItem m_itemProgram;
    private System.Windows.Forms.ToolStripMenuItem m_subitemExit;
    private System.Windows.Forms.ToolStripMenuItem m_itemSubjects;
    private System.Windows.Forms.ToolStripMenuItem m_subitemSubjects;
    private System.Windows.Forms.ToolStripMenuItem m_subitemSubjectTypes;
    private System.Windows.Forms.ToolStripMenuItem m_itemHelp;
    private System.Windows.Forms.ToolStripMenuItem m_subitemHelp;
    private System.Windows.Forms.ToolStripMenuItem m_subitemAbout;
    private System.Windows.Forms.ToolStripMenuItem m_subitemConnectionSettings;
}