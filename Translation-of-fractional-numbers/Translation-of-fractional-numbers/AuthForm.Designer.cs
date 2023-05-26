namespace Translation_numbers
{
    partial class AuthForm
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
            this.userLoginBox = new System.Windows.Forms.TextBox();
            this.userPasswordBox = new System.Windows.Forms.TextBox();
            this.autgBtn = new System.Windows.Forms.Button();
            this.goToRegForm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(202, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // userLoginBox
            // 
            this.userLoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLoginBox.ForeColor = System.Drawing.Color.Gray;
            this.userLoginBox.Location = new System.Drawing.Point(206, 118);
            this.userLoginBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userLoginBox.Name = "userLoginBox";
            this.userLoginBox.Size = new System.Drawing.Size(150, 28);
            this.userLoginBox.TabIndex = 1;
            this.userLoginBox.Text = "Логин";
            this.userLoginBox.Enter += new System.EventHandler(this.userLoginBox_Enter);
            this.userLoginBox.Leave += new System.EventHandler(this.userLoginBox_Leave);
            // 
            // userPasswordBox
            // 
            this.userPasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPasswordBox.ForeColor = System.Drawing.Color.Gray;
            this.userPasswordBox.Location = new System.Drawing.Point(206, 173);
            this.userPasswordBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userPasswordBox.Name = "userPasswordBox";
            this.userPasswordBox.Size = new System.Drawing.Size(150, 28);
            this.userPasswordBox.TabIndex = 2;
            this.userPasswordBox.Text = "Пароль";
            this.userPasswordBox.Enter += new System.EventHandler(this.userPasswordBox_Enter);
            this.userPasswordBox.Leave += new System.EventHandler(this.userPasswordBox_Leave);
            // 
            // autgBtn
            // 
            this.autgBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autgBtn.Location = new System.Drawing.Point(229, 222);
            this.autgBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autgBtn.Name = "autgBtn";
            this.autgBtn.Size = new System.Drawing.Size(103, 36);
            this.autgBtn.TabIndex = 3;
            this.autgBtn.Text = "Вход";
            this.autgBtn.UseVisualStyleBackColor = true;
            this.autgBtn.Click += new System.EventHandler(this.autgBtn_Click);
            // 
            // goToRegForm
            // 
            this.goToRegForm.AutoSize = true;
            this.goToRegForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToRegForm.ForeColor = System.Drawing.Color.Blue;
            this.goToRegForm.Location = new System.Drawing.Point(159, 260);
            this.goToRegForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.goToRegForm.Name = "goToRegForm";
            this.goToRegForm.Size = new System.Drawing.Size(238, 13);
            this.goToRegForm.TabIndex = 4;
            this.goToRegForm.Text = "Не зарегистрированы? Сделайте это сейчас!";
            this.goToRegForm.Click += new System.EventHandler(this.goToRegForm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 343);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(563, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "© 2023 Sergeev Danil, Smolyak Anton, Isayenko Vladislav, Tkachenko Maxim, Novitsk" +
    "y Stanislav. All rights reserved.";
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(578, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.goToRegForm);
            this.Controls.Add(this.autgBtn);
            this.Controls.Add(this.userPasswordBox);
            this.Controls.Add(this.userLoginBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthForm";
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userLoginBox;
        private System.Windows.Forms.TextBox userPasswordBox;
        private System.Windows.Forms.Button autgBtn;
        private System.Windows.Forms.Label goToRegForm;
        private System.Windows.Forms.Label label3;
    }
}