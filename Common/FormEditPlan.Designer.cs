partial class FormEditPlan
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
            this.m_buttonCopy = new System.Windows.Forms.Button();
            this.m_buttonDeduction = new System.Windows.Forms.Button();
            this.m_buttonSemesters = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_buttonDeletePlan = new System.Windows.Forms.Button();
            this.m_buttonAddPlan = new System.Windows.Forms.Button();
            this.m_planSelector = new PlanSelector();
            this.m_groupSelector = new GroupSelector();
            this.m_panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelButtons
            // 
            this.m_panelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.m_panelButtons.Controls.Add(this.m_buttonCopy);
            this.m_panelButtons.Controls.Add(this.m_buttonDeduction);
            this.m_panelButtons.Controls.Add(this.m_buttonSemesters);
            this.m_panelButtons.Controls.Add(this.m_buttonCancel);
            this.m_panelButtons.Controls.Add(this.m_buttonOK);
            this.m_panelButtons.Controls.Add(this.m_buttonDeletePlan);
            this.m_panelButtons.Controls.Add(this.m_buttonAddPlan);
            this.m_panelButtons.Location = new System.Drawing.Point(0, 258);
            this.m_panelButtons.Name = "m_panelButtons";
            this.m_panelButtons.Size = new System.Drawing.Size(588, 75);
            this.m_panelButtons.TabIndex = 1;
            this.m_panelButtons.Resize += new System.EventHandler(this.PanelButtonsResizeHandler);
            // 
            // m_buttonCopy
            // 
            this.m_buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonCopy.Location = new System.Drawing.Point(305, 3);
            this.m_buttonCopy.Name = "m_buttonCopy";
            this.m_buttonCopy.Size = new System.Drawing.Size(92, 29);
            this.m_buttonCopy.TabIndex = 6;
            this.m_buttonCopy.Text = "Скопировать";
            this.m_buttonCopy.UseVisualStyleBackColor = true;
            this.m_buttonCopy.Click += new System.EventHandler(this.ButtonCopyClickHandler);
            // 
            // m_buttonDeduction
            // 
            this.m_buttonDeduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonDeduction.Location = new System.Drawing.Point(403, 3);
            this.m_buttonDeduction.Name = "m_buttonDeduction";
            this.m_buttonDeduction.Size = new System.Drawing.Size(91, 29);
            this.m_buttonDeduction.TabIndex = 5;
            this.m_buttonDeduction.Text = "Вычет часов";
            this.m_buttonDeduction.UseVisualStyleBackColor = true;
            this.m_buttonDeduction.Click += new System.EventHandler(this.ButtonDeductionClickHandler);
            // 
            // m_buttonSemesters
            // 
            this.m_buttonSemesters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonSemesters.Location = new System.Drawing.Point(500, 3);
            this.m_buttonSemesters.Name = "m_buttonSemesters";
            this.m_buttonSemesters.Size = new System.Drawing.Size(75, 29);
            this.m_buttonSemesters.TabIndex = 4;
            this.m_buttonSemesters.Text = "Семестры";
            this.m_buttonSemesters.UseVisualStyleBackColor = true;
            this.m_buttonSemesters.Click += new System.EventHandler(this.ButtonSemestersClickHandler);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonCancel.Location = new System.Drawing.Point(500, 43);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.m_buttonCancel.TabIndex = 3;
            this.m_buttonCancel.Text = "Отмена";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            this.m_buttonCancel.Click += new System.EventHandler(this.ButtonCancelClickHandler);
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonOK.Location = new System.Drawing.Point(12, 43);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 29);
            this.m_buttonOK.TabIndex = 2;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickHandler);
            // 
            // m_buttonDeletePlan
            // 
            this.m_buttonDeletePlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonDeletePlan.Location = new System.Drawing.Point(93, 3);
            this.m_buttonDeletePlan.Name = "m_buttonDeletePlan";
            this.m_buttonDeletePlan.Size = new System.Drawing.Size(75, 29);
            this.m_buttonDeletePlan.TabIndex = 1;
            this.m_buttonDeletePlan.Text = "Удалить";
            this.m_buttonDeletePlan.UseVisualStyleBackColor = true;
            this.m_buttonDeletePlan.Click += new System.EventHandler(this.ButtonDeletePlanClickHandler);
            // 
            // m_buttonAddPlan
            // 
            this.m_buttonAddPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_buttonAddPlan.Location = new System.Drawing.Point(12, 3);
            this.m_buttonAddPlan.Name = "m_buttonAddPlan";
            this.m_buttonAddPlan.Size = new System.Drawing.Size(75, 29);
            this.m_buttonAddPlan.TabIndex = 0;
            this.m_buttonAddPlan.Text = "Добавить";
            this.m_buttonAddPlan.UseVisualStyleBackColor = true;
            this.m_buttonAddPlan.Click += new System.EventHandler(this.ButtonAddPlanClickHandler);
            // 
            // m_planSelector
            // 
            this.m_planSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_planSelector.College = null;
            this.m_planSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_planSelector.GroupInfo = null;
            this.m_planSelector.GroupTypeId = ((short)(0));
            this.m_planSelector.Location = new System.Drawing.Point(301, 0);
            this.m_planSelector.Name = "m_planSelector";
            this.m_planSelector.Size = new System.Drawing.Size(287, 49);
            this.m_planSelector.TabIndex = 2;
            // 
            // m_groupSelector
            // 
            this.m_groupSelector.BackColor = System.Drawing.SystemColors.Control;
            this.m_groupSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_groupSelector.College = null;
            this.m_groupSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_groupSelector.GroupInfo = null;
            this.m_groupSelector.GroupTypeId = ((short)(0));
            this.m_groupSelector.Location = new System.Drawing.Point(0, 0);
            this.m_groupSelector.Name = "m_groupSelector";
            this.m_groupSelector.Size = new System.Drawing.Size(302, 49);
            this.m_groupSelector.TabIndex = 0;
            // 
            // FormEditPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(587, 333);
            this.Controls.Add(this.m_planSelector);
            this.Controls.Add(this.m_panelButtons);
            this.Controls.Add(this.m_groupSelector);
            this.Name = "FormEditPlan";
            this.Text = "Редактирование плана";
            this.Resize += new System.EventHandler(this.ResizeHandler);
            this.m_panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private GroupSelector m_groupSelector;
    private System.Windows.Forms.Panel m_panelButtons;
    private System.Windows.Forms.Button m_buttonAddPlan;
    private System.Windows.Forms.Button m_buttonDeletePlan;
    private System.Windows.Forms.Button m_buttonCancel;
    private System.Windows.Forms.Button m_buttonOK;
    private System.Windows.Forms.Button m_buttonSemesters;
    private System.Windows.Forms.Button m_buttonDeduction;
    private PlanSelector m_planSelector;
    private System.Windows.Forms.Button m_buttonCopy;
}