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
            this.label1.Location = new System.Drawing.Point(196, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            // 
            // userNameBox
            // 
            this.userNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameBox.ForeColor = System.Drawing.Color.Gray;
            this.userNameBox.Location = new System.Drawing.Point(201, 71);
            this.userNameBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(149, 26);
            this.userNameBox.TabIndex = 1;
            this.userNameBox.Text = "Имя";
            this.userNameBox.Enter += new System.EventHandler(this.userNameBox_Enter);
            this.userNameBox.Leave += new System.EventHandler(this.userNameBox_Leave);
            // 
            // userSurnameBox
            // 
            this.userSurnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userSurnameBox.ForeColor = System.Drawing.Color.Gray;
            this.userSurnameBox.Location = new System.Drawing.Point(201, 110);
            this.userSurnameBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userSurnameBox.Name = "userSurnameBox";
            this.userSurnameBox.Size = new System.Drawing.Size(149, 26);
            this.userSurnameBox.TabIndex = 2;
            this.userSurnameBox.Text = "Фамилия";
            this.userSurnameBox.Enter += new System.EventHandler(this.userSurnameBox_Enter);
            this.userSurnameBox.Leave += new System.EventHandler(this.userSurnameBox_Leave);
            // 
            // userLoginBox
            // 
            this.userLoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLoginBox.ForeColor = System.Drawing.Color.Gray;
            this.userLoginBox.Location = new System.Drawing.Point(201, 153);
            this.userLoginBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userLoginBox.Name = "userLoginBox";
            this.userLoginBox.Size = new System.Drawing.Size(149, 26);
            this.userLoginBox.TabIndex = 3;
            this.userLoginBox.Text = "Логин";
            this.userLoginBox.Enter += new System.EventHandler(this.userLoginBox_Enter);
            this.userLoginBox.Leave += new System.EventHandler(this.userLoginBox_Leave);
            // 
            // userPasswordBox
            // 
            this.userPasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPasswordBox.ForeColor = System.Drawing.Color.Gray;
            this.userPasswordBox.Location = new System.Drawing.Point(201, 198);
            this.userPasswordBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userPasswordBox.Name = "userPasswordBox";
            this.userPasswordBox.Size = new System.Drawing.Size(149, 26);
            this.userPasswordBox.TabIndex = 4;
            this.userPasswordBox.Text = "Пароль";
            this.userPasswordBox.Enter += new System.EventHandler(this.userPasswordBox_Enter);
            this.userPasswordBox.Leave += new System.EventHandler(this.userPasswordBox_Leave);
            // 
            // userRPassworBox
            // 
            this.userRPassworBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userRPassworBox.ForeColor = System.Drawing.Color.Gray;
            this.userRPassworBox.Location = new System.Drawing.Point(201, 240);
            this.userRPassworBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userRPassworBox.Name = "userRPassworBox";
            this.userRPassworBox.Size = new System.Drawing.Size(149, 26);
            this.userRPassworBox.TabIndex = 5;
            this.userRPassworBox.Text = "Пароль повторно";
            this.userRPassworBox.Enter += new System.EventHandler(this.userRPassworBox_Enter);
            this.userRPassworBox.Leave += new System.EventHandler(this.userRPassworBox_Leave);
            // 
            // completeReg
            // 
            this.completeReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.completeReg.Location = new System.Drawing.Point(162, 282);
            this.completeReg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.completeReg.Name = "completeReg";
            this.completeReg.Size = new System.Drawing.Size(216, 29);
            this.completeReg.TabIndex = 6;
            this.completeReg.Text = "Зарегестрироваться";
            this.completeReg.UseVisualStyleBackColor = true;
            this.completeReg.Click += new System.EventHandler(this.completeReg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 366);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(563, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "© 2023 Sergeev Danil, Smolyak Anton, Isayenko Vladislav, Tkachenko Maxim, Novitsk" +
    "y Stanislav. All rights reserved.";
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountLabel.ForeColor = System.Drawing.Color.Blue;
            this.accountLabel.Location = new System.Drawing.Point(224, 313);
            this.accountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(104, 13);
            this.accountLabel.TabIndex = 8;
            this.accountLabel.Text = "Уже есть аккаунт?";
            this.accountLabel.Click += new System.EventHandler(this.accountLabel_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(569, 386);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.completeReg);
            this.Controls.Add(this.userRPassworBox);
            this.Controls.Add(this.userPasswordBox);
            this.Controls.Add(this.userLoginBox);
            this.Controls.Add(this.userSurnameBox);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
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

