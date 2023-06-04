using System;
using System.Drawing;
using System.IO;
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
            if (File.Exists("Users\\LastUserInfo.txt"))
            {
                using (StreamReader sr = new StreamReader("Users\\LastUserInfo.txt"))
                {
                    userLoginBox_Enter(null, null);
                    userLoginBox.Text = sr.ReadLine();
                    userLoginBox_Leave(null, null);
                    userPasswordBox_Enter(null, null);
                    userPasswordBox.Text = sr.ReadLine();
                    userPasswordBox_Leave(null, null);
                }
            }
        }

        private void autgBtn_Click(object sender, EventArgs e)
        {
            if (userLoginBox.ForeColor == Color.Gray && userPasswordBox.ForeColor == Color.Gray)
            {
                Hide();
                new AdministratorMainForm("admin").ShowDialog();
                Show();
                using (StreamWriter sw = new StreamWriter("Users\\LastUserInfo.txt"))
                {
                    sw.WriteLine("");
                    sw.WriteLine("");
                }
                return;
            }

            string login = TryLogin();
            if (login == "")
            {
                MessageBox.Show("Пользователь с такими данными не найден, создайте учётную запись.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (login == "False")
            {
                new DefaultUserMainForm(userLoginBox.Text).ShowDialog();
            }
            else
            {
                new AdministratorMainForm(userLoginBox.Text).ShowDialog();
            }

            using (StreamWriter sw = new StreamWriter("Users\\LastUserInfo.txt"))
            {
                sw.WriteLine(userLoginBox.Text);
                sw.WriteLine(userPasswordBox.Text);
            }
        }

        private string TryLogin()
        {
            if (File.Exists($"Users\\{userLoginBox.Text}.txt"))
            {
                using (StreamReader sr = new StreamReader($"Users\\{userLoginBox.Text}.txt"))
                {
                    while (sr.Peek() > 0)
                    {
                        string currentLine = sr.ReadLine();
                        if (currentLine.Contains($"{userLoginBox.Text}") && sr.ReadLine().Contains($"{userPasswordBox.Text}"))
                        {
                            sr.ReadLine();
                            sr.ReadLine();
                            currentLine = sr.ReadLine();
                            if (currentLine.Contains("False"))
                                return "False";
                            else return "True";
                        }
                    }
                }
            }
            return "";
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
