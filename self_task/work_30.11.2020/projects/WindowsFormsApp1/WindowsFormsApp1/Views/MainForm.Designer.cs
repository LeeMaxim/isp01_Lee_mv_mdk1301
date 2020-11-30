namespace WindowsFormsApp1
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SpecialtiesButton = new System.Windows.Forms.Button();
            this.GroupButton = new System.Windows.Forms.Button();
            this.StudentsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SpecialtiesButton
            // 
            this.SpecialtiesButton.Location = new System.Drawing.Point(38, 84);
            this.SpecialtiesButton.Name = "SpecialtiesButton";
            this.SpecialtiesButton.Size = new System.Drawing.Size(134, 45);
            this.SpecialtiesButton.TabIndex = 0;
            this.SpecialtiesButton.Text = "Специальности";
            this.SpecialtiesButton.UseVisualStyleBackColor = true;
            // 
            // GroupButton
            // 
            this.GroupButton.Location = new System.Drawing.Point(188, 84);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(134, 45);
            this.GroupButton.TabIndex = 1;
            this.GroupButton.Text = "Группы";
            this.GroupButton.UseVisualStyleBackColor = true;
            // 
            // StudentsButton
            // 
            this.StudentsButton.Location = new System.Drawing.Point(352, 84);
            this.StudentsButton.Name = "StudentsButton";
            this.StudentsButton.Size = new System.Drawing.Size(134, 45);
            this.StudentsButton.TabIndex = 2;
            this.StudentsButton.Text = "Студенты";
            this.StudentsButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 455);
            this.Controls.Add(this.StudentsButton);
            this.Controls.Add(this.GroupButton);
            this.Controls.Add(this.SpecialtiesButton);
            this.Name = "MainForm";
            this.Text = "Главное окно";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SpecialtiesButton;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button StudentsButton;
    }
}

