namespace Translation_numbers
{
    partial class AddNewAdminForm
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
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.adminNameBox = new System.Windows.Forms.TextBox();
            this.adminSurnameBox = new System.Windows.Forms.TextBox();
            this.adminLoginBox = new System.Windows.Forms.TextBox();
            this.adminPasswordBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавление нового администратора";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Фамилия: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Логин: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Пароль: ";
            // 
            // adminNameBox
            // 
            this.adminNameBox.Location = new System.Drawing.Point(157, 70);
            this.adminNameBox.Name = "adminNameBox";
            this.adminNameBox.Size = new System.Drawing.Size(213, 22);
            this.adminNameBox.TabIndex = 5;
            // 
            // adminSurnameBox
            // 
            this.adminSurnameBox.Location = new System.Drawing.Point(157, 115);
            this.adminSurnameBox.Name = "adminSurnameBox";
            this.adminSurnameBox.Size = new System.Drawing.Size(213, 22);
            this.adminSurnameBox.TabIndex = 6;
            // 
            // adminLoginBox
            // 
            this.adminLoginBox.Location = new System.Drawing.Point(157, 159);
            this.adminLoginBox.Name = "adminLoginBox";
            this.adminLoginBox.Size = new System.Drawing.Size(213, 22);
            this.adminLoginBox.TabIndex = 7;
            // 
            // adminPasswordBox
            // 
            this.adminPasswordBox.Location = new System.Drawing.Point(157, 204);
            this.adminPasswordBox.Name = "adminPasswordBox";
            this.adminPasswordBox.Size = new System.Drawing.Size(213, 22);
            this.adminPasswordBox.TabIndex = 8;
            // 
            // acceptButton
            // 
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptButton.Location = new System.Drawing.Point(466, 312);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(154, 33);
            this.acceptButton.TabIndex = 9;
            this.acceptButton.Text = "Подвердить";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // AddNewAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(632, 357);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.adminPasswordBox);
            this.Controls.Add(this.adminLoginBox);
            this.Controls.Add(this.adminSurnameBox);
            this.Controls.Add(this.adminNameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNewAdminForm";
            this.Text = "AddNewAdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adminNameBox;
        private System.Windows.Forms.TextBox adminSurnameBox;
        private System.Windows.Forms.TextBox adminLoginBox;
        private System.Windows.Forms.TextBox adminPasswordBox;
        private System.Windows.Forms.Button acceptButton;
    }
}