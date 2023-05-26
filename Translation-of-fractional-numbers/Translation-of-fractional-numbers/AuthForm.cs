using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translation_of_fractional_numbers;

namespace Translation_numbers
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void goToRegForm_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            Hide();
            reg.ShowDialog();
            Show();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void autgBtn_Click(object sender, EventArgs e)
        {
            if (userLoginBox.ForeColor == Color.Gray && userPasswordBox.ForeColor == Color.Gray)
            {
                Hide();
                new AdministratorMainForm("admin").ShowDialog();
                Close();
            }

            if (File.Exists($"Users\\{userLoginBox.Text}"))
            {
                using (StreamReader sr = new StreamReader($"Users\\{userLoginBox.Text}"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string currentLine = sr.ReadLine();
                        if (currentLine.Contains($"{userLoginBox.Text} {userPasswordBox.Text}"))
                        {
                            Hide();
                            if (currentLine.Contains("False"))
                                new DefaultUserMainForm(userLoginBox.Text).ShowDialog();
                            else new AdministratorMainForm(userLoginBox.Text).ShowDialog();
                            Close();
                        }
                    }
                }
            }          

            MessageBox.Show("Пользователь с такими данными не найден, создайте учётную запись.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void userLoginBox_Enter(object sender, EventArgs e)
        {
            if (userLoginBox.ForeColor != Color.Gray)
                return;
            userLoginBox.Text = string.Empty;
            userLoginBox.ForeColor = Color.Black;
        }

        private void userLoginBox_Leave(object sender, EventArgs e)
        {
            if (userLoginBox.Text != string.Empty)
                return;
            userLoginBox.Text = "Логин";
            userLoginBox.ForeColor = Color.Gray;
        }

        private void userPasswordBox_Enter(object sender, EventArgs e)
        {
            if (userPasswordBox.ForeColor != Color.Gray)
                return;
            userPasswordBox.Text = string.Empty;
            userPasswordBox.ForeColor = Color.Black;
            userPasswordBox.UseSystemPasswordChar = true;
        }

        private void userPasswordBox_Leave(object sender, EventArgs e)
        {
            if (userPasswordBox.Text != string.Empty)
                return;
            userPasswordBox.Text = "Пароль";
            userPasswordBox.ForeColor = Color.Gray;
            userPasswordBox.UseSystemPasswordChar = false;
        }
    }
}
