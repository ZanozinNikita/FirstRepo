namespace Zanozin_vek
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.RCross = new System.Windows.Forms.RadioButton();
            this.RLine = new System.Windows.Forms.RadioButton();
            this.RCircle = new System.Windows.Forms.RadioButton();
            this.Clear_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RCross
            // 
            this.RCross.AutoSize = true;
            this.RCross.Location = new System.Drawing.Point(402, 326);
            this.RCross.Name = "RCross";
            this.RCross.Size = new System.Drawing.Size(59, 17);
            this.RCross.TabIndex = 0;
            this.RCross.TabStop = true;
            this.RCross.Text = "RCross";
            this.RCross.UseVisualStyleBackColor = true;
            this.RCross.CheckedChanged += new System.EventHandler(this.R_CheckedChanged);
            // 
            // RLine
            // 
            this.RLine.AutoSize = true;
            this.RLine.Location = new System.Drawing.Point(402, 350);
            this.RLine.Name = "RLine";
            this.RLine.Size = new System.Drawing.Size(53, 17);
            this.RLine.TabIndex = 1;
            this.RLine.TabStop = true;
            this.RLine.Text = "RLine";
            this.RLine.UseVisualStyleBackColor = true;
            this.RLine.CheckedChanged += new System.EventHandler(this.R_CheckedChanged);
            // 
            // RCircle
            // 
            this.RCircle.AutoSize = true;
            this.RCircle.Location = new System.Drawing.Point(402, 374);
            this.RCircle.Name = "RCircle";
            this.RCircle.Size = new System.Drawing.Size(59, 17);
            this.RCircle.TabIndex = 2;
            this.RCircle.TabStop = true;
            this.RCircle.Text = "RCircle";
            this.RCircle.UseVisualStyleBackColor = true;
            this.RCircle.CheckedChanged += new System.EventHandler(this.R_CheckedChanged);
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(321, 360);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(75, 23);
            this.Clear_button.TabIndex = 3;
            this.Clear_button.Text = "Clear";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 395);
            this.Controls.Add(this.Clear_button);
            this.Controls.Add(this.RCircle);
            this.Controls.Add(this.RLine);
            this.Controls.Add(this.RCross);
            this.Name = "Form1";
            this.Text = "Form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RCross;
        private System.Windows.Forms.RadioButton RLine;
        private System.Windows.Forms.RadioButton RCircle;
        private System.Windows.Forms.Button Clear_button;
    }
}

