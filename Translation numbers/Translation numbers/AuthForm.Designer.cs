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
            this.label1.Location = new System.Drawing.Point(249, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // userLoginBox
            // 
            this.userLoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLoginBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.userLoginBox.Location = new System.Drawing.Point(255, 146);
            this.userLoginBox.Name = "userLoginBox";
            this.userLoginBox.Size = new System.Drawing.Size(198, 34);
            this.userLoginBox.TabIndex = 1;
            this.userLoginBox.Text = "Логин";
            // 
            // userPasswordBox
            // 
            this.userPasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPasswordBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.userPasswordBox.Location = new System.Drawing.Point(255, 214);
            this.userPasswordBox.Name = "userPasswordBox";
            this.userPasswordBox.Size = new System.Drawing.Size(198, 34);
            this.userPasswordBox.TabIndex = 2;
            this.userPasswordBox.Text = "Пароль";
            // 
            // autgBtn
            // 
            this.autgBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autgBtn.Location = new System.Drawing.Point(278, 275);
            this.autgBtn.Name = "autgBtn";
            this.autgBtn.Size = new System.Drawing.Size(137, 44);
            this.autgBtn.TabIndex = 3;
            this.autgBtn.Text = "Вход";
            this.autgBtn.UseVisualStyleBackColor = true;
            // 
            // goToRegForm
            // 
            this.goToRegForm.AutoSize = true;
            this.goToRegForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToRegForm.Location = new System.Drawing.Point(205, 322);
            this.goToRegForm.Name = "goToRegForm";
            this.goToRegForm.Size = new System.Drawing.Size(305, 16);
            this.goToRegForm.TabIndex = 4;
            this.goToRegForm.Text = "Не зарегистрированы? Сделайте это сейчас!";
            this.goToRegForm.Click += new System.EventHandler(this.goToRegForm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(699, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "© 2023 Sergeev Danil, Smolyak Anton, Isayenko Vladislav, Tkachenko Maxim, Novitsk" +
    "y Stanislav. All rights reserved.";
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.goToRegForm);
            this.Controls.Add(this.autgBtn);
            this.Controls.Add(this.userPasswordBox);
            this.Controls.Add(this.userLoginBox);
            this.Controls.Add(this.label1);
            this.Name = "AuthForm";
            this.Text = "AuthForm";
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