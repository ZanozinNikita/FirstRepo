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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 385);
            this.Controls.Add(this.RLine);
            this.Controls.Add(this.RCross);
            this.Name = "Form1";
            this.Text = "Form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RCross;
        private System.Windows.Forms.RadioButton RLine;
    }
}

