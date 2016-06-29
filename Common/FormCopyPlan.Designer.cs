namespace Common
{
    partial class FormCopyPlan
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
            this.m_radioGroupPlan = new System.Windows.Forms.RadioButton();
            this.m_radioOtherPlan = new System.Windows.Forms.RadioButton();
            this.m_buttonOK = new System.Windows.Forms.Button();
            this.m_panelRadio = new System.Windows.Forms.Panel();
            this.m_panelRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Скопировать из:";
            // 
            // m_radioGroupPlan
            // 
            this.m_radioGroupPlan.AutoSize = true;
            this.m_radioGroupPlan.Checked = true;
            this.m_radioGroupPlan.Location = new System.Drawing.Point(3, 5);
            this.m_radioGroupPlan.Name = "m_radioGroupPlan";
            this.m_radioGroupPlan.Size = new System.Drawing.Size(105, 19);
            this.m_radioGroupPlan.TabIndex = 1;
            this.m_radioGroupPlan.TabStop = true;
            this.m_radioGroupPlan.Text = "Плана группы";
            this.m_radioGroupPlan.UseVisualStyleBackColor = true;
            // 
            // m_radioOtherPlan
            // 
            this.m_radioOtherPlan.AutoSize = true;
            this.m_radioOtherPlan.Location = new System.Drawing.Point(3, 30);
            this.m_radioOtherPlan.Name = "m_radioOtherPlan";
            this.m_radioOtherPlan.Size = new System.Drawing.Size(108, 19);
            this.m_radioOtherPlan.TabIndex = 2;
            this.m_radioOtherPlan.Text = "Другого плана";
            this.m_radioOtherPlan.UseVisualStyleBackColor = true;
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.Location = new System.Drawing.Point(89, 73);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(75, 29);
            this.m_buttonOK.TabIndex = 3;
            this.m_buttonOK.Text = "ОК";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            this.m_buttonOK.Click += new System.EventHandler(this.ButtonOKClickHandler);
            // 
            // m_panelRadio
            // 
            this.m_panelRadio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelRadio.Controls.Add(this.m_radioGroupPlan);
            this.m_panelRadio.Controls.Add(this.m_radioOtherPlan);
            this.m_panelRadio.Location = new System.Drawing.Point(121, 9);
            this.m_panelRadio.Name = "m_panelRadio";
            this.m_panelRadio.Size = new System.Drawing.Size(113, 58);
            this.m_panelRadio.TabIndex = 4;
            // 
            // FormCopyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 105);
            this.Controls.Add(this.m_panelRadio);
            this.Controls.Add(this.m_buttonOK);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(281, 144);
            this.MinimumSize = new System.Drawing.Size(281, 144);
            this.Name = "FormCopyPlan";
            this.Text = "Копирование плана";
            this.m_panelRadio.ResumeLayout(false);
            this.m_panelRadio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton m_radioGroupPlan;
        private System.Windows.Forms.RadioButton m_radioOtherPlan;
        private System.Windows.Forms.Button m_buttonOK;
        private System.Windows.Forms.Panel m_panelRadio;
    }
}