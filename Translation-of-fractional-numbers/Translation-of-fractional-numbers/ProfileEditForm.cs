using System;
using System.IO;
using System.Windows.Forms;

namespace Translation_of_fractional_numbers
{
    public partial class ProfileEditForm : Form
    {
        private string _currentUser;
        private string _password;
        private bool _admin;

        public ProfileEditForm()
        {
            InitializeComponent();
        }

        public ProfileEditForm(string login, string password, string name, string surname, bool admin)
        {
            InitializeComponent();

            editNameBox.Text = name;
            EditSurnameBox.Text = surname;
            editLoginBox.Text = login;
            _currentUser = login;
            _admin = admin;
            _password = password;
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (userPasswordBox.Text != _password)
            {
                MessageBox.Show("Введён неправильный текущий пароль.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (editLoginBox.Text != _currentUser)
            {
                foreach (string filepath in Directory.GetFiles("Users", "*.txt"))
                {
                    if (Path.GetFileNameWithoutExtension(filepath).Contains(editLoginBox.Text))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            UpdateUserData(editLoginBox.Text, userPasswordBox.Text, editNameBox.Text, EditSurnameBox.Text);
            MessageBox.Show("Данные успешно изменены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void UpdateUserData(string login, string password, string name, string surname)
        {
            using (StreamWriter sw = new StreamWriter($"Users\\{login}.txt"))
            {
                sw.Write($"{login}\n{password}\n{name}\n{surname}\n{_admin}\n");
                sw.Close();
            }
        }
    }
}
