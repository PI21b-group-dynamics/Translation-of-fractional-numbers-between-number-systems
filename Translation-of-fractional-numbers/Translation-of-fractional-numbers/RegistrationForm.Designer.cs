namespace Translation_numbers
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.userSurnameBox = new System.Windows.Forms.TextBox();
            this.userLoginBox = new System.Windows.Forms.TextBox();
            this.userPasswordBox = new System.Windows.Forms.TextBox();
            this.userRPassworBox = new System.Windows.Forms.TextBox();
            this.completeReg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.accountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(262, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            // 
            // userNameBox
            // 
            this.userNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.userNameBox.Location = new System.Drawing.Point(268, 87);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(197, 30);
            this.userNameBox.TabIndex = 1;
            this.userNameBox.Text = "Имя";
            // 
            // userSurnameBox
            // 
            this.userSurnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userSurnameBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.userSurnameBox.Location = new System.Drawing.Point(268, 135);
            this.userSurnameBox.Name = "userSurnameBox";
            this.userSurnameBox.Size = new System.Drawing.Size(197, 30);
            this.userSurnameBox.TabIndex = 2;
            this.userSurnameBox.Text = "Фамилия";
            // 
            // userLoginBox
            // 
            this.userLoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLoginBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.userLoginBox.Location = new System.Drawing.Point(268, 188);
            this.userLoginBox.Name = "userLoginBox";
            this.userLoginBox.Size = new System.Drawing.Size(197, 30);
            this.userLoginBox.TabIndex = 3;
            this.userLoginBox.Text = "Логин";
            // 
            // userPasswordBox
            // 
            this.userPasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPasswordBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.userPasswordBox.Location = new System.Drawing.Point(268, 244);
            this.userPasswordBox.Name = "userPasswordBox";
            this.userPasswordBox.Size = new System.Drawing.Size(197, 30);
            this.userPasswordBox.TabIndex = 4;
            this.userPasswordBox.Text = "Пароль";
            // 
            // userRPassworBox
            // 
            this.userRPassworBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userRPassworBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.userRPassworBox.Location = new System.Drawing.Point(268, 295);
            this.userRPassworBox.Name = "userRPassworBox";
            this.userRPassworBox.Size = new System.Drawing.Size(197, 30);
            this.userRPassworBox.TabIndex = 5;
            this.userRPassworBox.Text = "Пароль повторно";
            // 
            // completeReg
            // 
            this.completeReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.completeReg.Location = new System.Drawing.Point(156, 346);
            this.completeReg.Name = "completeReg";
            this.completeReg.Size = new System.Drawing.Size(435, 36);
            this.completeReg.TabIndex = 6;
            this.completeReg.Text = "Подтвердить и вернуться к авторизации";
            this.completeReg.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(699, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "© 2023 Sergeev Danil, Smolyak Anton, Isayenko Vladislav, Tkachenko Maxim, Novitsk" +
    "y Stanislav. All rights reserved.";
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountLabel.Location = new System.Drawing.Point(299, 385);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(128, 16);
            this.accountLabel.TabIndex = 8;
            this.accountLabel.Text = "Уже есть аккаунт?";
            this.accountLabel.Click += new System.EventHandler(this.accountLabel_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(759, 475);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.completeReg);
            this.Controls.Add(this.userRPassworBox);
            this.Controls.Add(this.userPasswordBox);
            this.Controls.Add(this.userLoginBox);
            this.Controls.Add(this.userSurnameBox);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.TextBox userSurnameBox;
        private System.Windows.Forms.TextBox userLoginBox;
        private System.Windows.Forms.TextBox userPasswordBox;
        private System.Windows.Forms.TextBox userRPassworBox;
        private System.Windows.Forms.Button completeReg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label accountLabel;
    }
}

