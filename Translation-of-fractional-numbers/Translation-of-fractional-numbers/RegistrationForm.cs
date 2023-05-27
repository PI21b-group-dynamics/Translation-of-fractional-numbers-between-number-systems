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

namespace Translation_numbers
{
    public partial class RegistrationForm : Form
    {
        private List<TextBox> _textBoxes;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void accountLabel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            _textBoxes = new List<TextBox>
            {
            userNameBox,
            userSurnameBox,
            userLoginBox,
            userPasswordBox,
            userRPassworBox
            };
        }

        private void completeReg_Click(object sender, EventArgs e)
        {
            if (_textBoxes.All(tb => tb.ForeColor != Color.Gray))
            {
                if (userPasswordBox.Text == userRPassworBox.Text)
                {
                    if (!File.Exists($"Users\\{userLoginBox.Text}.txt"))
                    {
                        using (StreamWriter sw = new StreamWriter($"Users\\{userLoginBox.Text}.txt", true))
                            sw.Write($"{userLoginBox.Text}\n{userPasswordBox.Text}\n{userNameBox.Text}\n{userSurnameBox.Text}\n{false}\n");
                        MessageBox.Show("Регистрация прошла успешно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else MessageBox.Show("Введенный пароли не совпадают.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else MessageBox.Show("Заполните все поля для регистрации.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TextBoxEnter(TextBox textBox)
        {
            if (textBox.ForeColor != Color.Gray)
                return;
            textBox.Text = string.Empty;
            textBox.ForeColor = Color.Black;
        }

        private void TextBoxLeave(TextBox textBox, string text)
        {
            if (textBox.Text != string.Empty)
                return;
            textBox.Text = text;
            textBox.ForeColor = Color.Gray;
        }

        private void PassBoxEnter(TextBox textBox)
        {
            if (textBox.ForeColor != Color.Gray)
                return;
            textBox.Text = string.Empty;
            textBox.ForeColor = Color.Black;
            textBox.UseSystemPasswordChar = true;
        }

        private void PassBoxLeave(TextBox textBox, string text)
        {
            if (textBox.Text != string.Empty)
                return;
            textBox.Text = text;
            textBox.ForeColor = Color.Gray;
            textBox.UseSystemPasswordChar = false;
        }

        private void userNameBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter(userNameBox);
        }

        private void userNameBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(userNameBox, "Имя");
        }

        private void userSurnameBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter(userSurnameBox);
        }

        private void userSurnameBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(userSurnameBox, "Фамилия");
        }

        private void userLoginBox_Enter(object sender, EventArgs e)
        {
            TextBoxEnter(userLoginBox);
        }

        private void userLoginBox_Leave(object sender, EventArgs e)
        {
            TextBoxLeave(userLoginBox, "Логин");
        }

        private void userPasswordBox_Enter(object sender, EventArgs e)
        {
            PassBoxEnter(userPasswordBox);
        }

        private void userPasswordBox_Leave(object sender, EventArgs e)
        {
            PassBoxLeave(userPasswordBox, "Пароль");
        }

        private void userRPassworBox_Enter(object sender, EventArgs e)
        {
            PassBoxEnter(userRPassworBox);
        }

        private void userRPassworBox_Leave(object sender, EventArgs e)
        {
            PassBoxLeave(userRPassworBox, "Пароль повторно");
        }
    }
}
