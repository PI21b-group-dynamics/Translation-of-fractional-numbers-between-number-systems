using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Translation_of_fractional_numbers
{
    public partial class AdministratorMainForm : Form
    {
        private const string _alphabet = "0123456789ABCDEF.";
        private string _currentUser;

        public AdministratorMainForm()
        {
            InitializeComponent();
        }

        public AdministratorMainForm(string userLogin)
        {
            InitializeComponent();
            label21.Visible = false;

            if (userLogin == "admin")
                LoadAdminData(userLogin);
            else LoadUserAdminData(userLogin);
            LoadUsersData();
        }

        private void AdministratorMainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadUsersData()
        {
            int index = 1;
            foreach (string filepath in Directory.GetFiles("Users", "*.txt"))
            {
                if (Path.GetFileNameWithoutExtension(filepath).Contains("Info"))
                {
                    continue;
                }

                string login, password, name, surname, admin;
                using (StreamReader sr = new StreamReader(filepath))
                {
                    login = sr.ReadLine();
                    password = sr.ReadLine();
                    name = sr.ReadLine();
                    surname = sr.ReadLine();
                    admin = "";
                    if (sr.ReadLine() == "True")
                        admin = "*";
                }

                if (!File.Exists("Users\\" + Path.GetFileNameWithoutExtension(filepath) + "Info.txt"))
                {
                    UpdateUserInfo("0", "0", "0", Path.GetFileNameWithoutExtension(filepath));
                }

                string translate, edit, warning;
                using (StreamReader sr = new StreamReader("Users\\" + Path.GetFileNameWithoutExtension(filepath) + "Info.txt"))
                {
                    translate = sr.ReadLine();
                    edit = sr.ReadLine();
                    warning = sr.ReadLine();
                }

                dataGridView1.Rows.Add(index + admin, login, password, name, surname, warning, edit, translate);
            }
        }

        private void LoadUserAdminData(string userLogin)
        {
            if (!File.Exists($"Users\\{userLogin}Info.txt"))
            {
                UpdateUserInfo("0", "0", "0", userLogin);
            }

            using (StreamReader sr = new StreamReader($"Users\\{userLogin}Info.txt"))
            {
                translateCountLabel.Text = sr.ReadLine();
                profileEditCount.Text = sr.ReadLine();
                warningsCount.Text = sr.ReadLine();
            }

            using (StreamReader sr = new StreamReader($"Users\\{userLogin}.txt"))
            {
                userLoginBox.Text = sr.ReadLine();
                userPasswordBox.Text = sr.ReadLine();
                userNameBox.Text = sr.ReadLine();
                userSurnameBox.Text = sr.ReadLine();
            }

            label2.Text = userLogin;
            label12.Text = userLogin;
            label17.Text = userLogin;
            _currentUser = userLogin;
        }

        private void LoadAdminData(string userLogin)
        {
            if (!File.Exists($"Users\\{userLogin}Info.txt"))
            {
                using (StreamWriter sw = new StreamWriter($"Users\\{userLogin}Info.txt", true))
                    sw.Write("0\n0\n0\n");
            }

            using (StreamReader sr = new StreamReader($"Users\\{userLogin}Info.txt"))
            {
                translateCountLabel.Text = sr.ReadLine();
                profileEditCount.Text = sr.ReadLine();
                warningsCount.Text = sr.ReadLine();
            }

            label2.Text = userLogin;
            label12.Text = userLogin;
            label17.Text = userLogin;
            _currentUser = userLogin;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            new ProfileEditForm(userLoginBox.Text, userPasswordBox.Text, userNameBox.Text, userSurnameBox.Text, false).ShowDialog();
            LoadUserAdminData(userLoginBox.Text);
        }

        private void numberForTranslateBox_TextChanged(object sender, EventArgs e)
        {
            if (startNumberSystemBox.ForeColor == Color.Gray || endNumberSystemBox.ForeColor == Color.Gray || numberForTranslateBox.Text == "")
            {
                resultBox.Text = string.Empty;
                return;
            }

            TranslateNumber();
        }

        private void startNumberSystemBox_TextChanged(object sender, EventArgs e)
        {
            if (numberForTranslateBox.Text == "" || endNumberSystemBox.ForeColor == Color.Gray || startNumberSystemBox.Text == "")
            {
                resultBox.Text = string.Empty;
                return;
            }

            TranslateNumber();
        }

        private void endNumberSystemBox_TextChanged(object sender, EventArgs e)
        {
            if (numberForTranslateBox.Text == "" || startNumberSystemBox.ForeColor == Color.Gray || endNumberSystemBox.Text == "")
            {
                resultBox.Text = string.Empty;
                return;
            }

            TranslateNumber();
        }

        private void TranslateNumber()
        {
            label21.Visible = false;
            try
            {
                double decimalNumber = ConvertToDecimal(numberForTranslateBox.Text, Convert.ToInt32(startNumberSystemBox.Text));
                string result = ConvertFromDecimal(decimalNumber, Convert.ToInt32(endNumberSystemBox.Text));
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] != '0')
                    {
                        resultBox.Text = result.Substring(i, result.Length - i);
                        break;
                    }
                }
                translateCountLabel.Text = (Int32.Parse(translateCountLabel.Text) + 1).ToString();
                UpdateUserInfo(translateCountLabel.Text, profileEditCount.Text, warningsCount.Text, _currentUser);
            }
            catch (Exception)
            {
                label21.Visible = true;
            }
        }

        private void UpdateUserInfo(string translates, string edits, string warnings, string user)
        {
            using (StreamWriter sw = new StreamWriter($"Users\\{user}Info.txt"))
            {
                sw.Write($"{translates}\n{edits}\n{warnings}\n");
            }
        }

        static double ConvertToDecimal(string number, int baseValue)
        {
            if (baseValue < 1 || baseValue > 16)
            {
                throw new ArgumentException("Неверное или неподдерживаемое основание системы счисления.");
            }

            string decimalNumber = number.Replace(",", ".");

            string[] parts = decimalNumber.Split('.');

            double resultInt = 0;
            string chars;

            if (baseValue == 1)
            {
                chars = "1";
                if (!number.All(c => chars.Contains(c)))
                {
                    throw new ArgumentException("Некорректный символ в числе.");
                }

                for (int i = 0; i < parts[0].Length; i++)
                {
                    resultInt++;
                }
                return resultInt;
            }
            else
            {
                chars = _alphabet.Substring(0, baseValue);
                if (!number.All(c => chars.Contains(c)))
                {
                    throw new ArgumentException("Некорректный символ в числе.");
                }
            }

            for (int i = 0; i < parts[0].Length; i++)
            {
                double value;

                if (char.IsDigit(parts[0][i]))
                {
                    value = double.Parse(parts[0][i].ToString());
                }
                else
                {
                    value = parts[0][i] - 'A' + 10;
                }

                resultInt += value * Math.Pow(baseValue, parts[0].Length - 1 - i);
            }

            double resultFraction = 0;
            if (parts.Length > 1)
            {
                for (int i = 0; i < parts[1].Length; i++)
                {
                    double value;

                    if (char.IsDigit(parts[1][i]))
                    {
                        value = double.Parse(parts[1][i].ToString());
                    }
                    else
                    {
                        value = parts[1][i] - 'A' + 10;
                    }

                    resultFraction += value / Math.Pow(baseValue, i + 1);
                }
            }

            return resultInt + resultFraction;
        }

        static string ConvertFromDecimal(double decimalNumber, int baseValue)
        {
            if (baseValue < 1 || baseValue > 16)
            {
                throw new ArgumentException("Неверное или неподдерживаемое основание системы счисления.");
            }

            string resultInt = "";
            double intPart = Math.Truncate(decimalNumber);
            double fractionPart = decimalNumber - intPart;

            if (baseValue == 1)
            {
                for (int i = 0; i < intPart; i++)
                {
                    resultInt += '1';
                }
                return resultInt;
            }

            while (intPart > 0)
            {
                double remainder = intPart % baseValue;
                char digit = (remainder < 10) ? (char)('0' + remainder) : (char)('A' + remainder - 10);
                resultInt = digit + resultInt;
                intPart /= baseValue;
            }

            string resultFraction = "";
            for (int i = 0; i < 10 && fractionPart > 0; i++)
            {
                double value = fractionPart * baseValue;
                double intPartFraction = Math.Truncate(value);
                char digit = (intPartFraction < 10) ? (char)('0' + intPartFraction) : (char)('A' + intPartFraction - 10);
                resultFraction += digit;
                fractionPart = value - intPartFraction;
            }

            string result = resultInt;
            if (resultFraction.Length > 0)
            {
                result += "." + resultFraction;
            }

            return result;
        }

        private void addNewAdmin_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString().Contains("*"))
            {
                MessageBox.Show("Данный пользователь уже является администратором.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                warningsCount.Text = (Int32.Parse(warningsCount.Text) + 1).ToString();
                UpdateUserInfo(translateCountLabel.Text, profileEditCount.Text, warningsCount.Text, _currentUser);
                return;
            }

            dataGridView1.CurrentRow.Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString() + '*';
            UpdateUserData(dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString());
            MessageBox.Show("Данный пользователь назначен администратором.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateUserData(string login, string password, string name, string surname)
        {
            using (StreamWriter sw = new StreamWriter($"Users\\{login}.txt"))
            {
                sw.Write($"{login}\n{password}\n{name}\n{surname}\n{true}\n");
            }
        }

        private void startNumberSystemBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            int num = int.Parse(startNumberSystemBox.Text + e.KeyChar.ToString());

            if (num < 1 || num > 16)
            {
                e.Handled = true;
                return;
            }
        }

        private void endNumberSystemBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            int num = int.Parse(endNumberSystemBox.Text + e.KeyChar.ToString());

            if (num < 1 || num > 16)
            {
                e.Handled = true;
                return;
            }
        }

        private void startNumberSystemBox_Enter(object sender, EventArgs e)
        {
            if (startNumberSystemBox.ForeColor != Color.Gray)
                return;
            startNumberSystemBox.Text = string.Empty;
            startNumberSystemBox.ForeColor = Color.Black;
        }

        private void startNumberSystemBox_Leave(object sender, EventArgs e)
        {
            if (startNumberSystemBox.Text != string.Empty)
                return;
            startNumberSystemBox.Text = "1-16";
            startNumberSystemBox.ForeColor = Color.Gray;
        }

        private void endNumberSystemBox_Enter(object sender, EventArgs e)
        {
            if (endNumberSystemBox.ForeColor != Color.Gray)
                return;
            endNumberSystemBox.Text = string.Empty;
            endNumberSystemBox.ForeColor = Color.Black;
        }

        private void endNumberSystemBox_Leave(object sender, EventArgs e)
        {
            if (endNumberSystemBox.Text != string.Empty)
                return;
            endNumberSystemBox.Text = "1-16";
            endNumberSystemBox.ForeColor = Color.Gray;
        }

        private void numberForTranslateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            if (_alphabet.Contains(e.KeyChar.ToString()))
            {
                if (e.KeyChar == '.' && numberForTranslateBox.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearFields_Click(object sender, EventArgs e)
        {
            numberForTranslateBox.Text = string.Empty;
            startNumberSystemBox.Text = string.Empty;
            startNumberSystemBox_Leave(null, null);
            endNumberSystemBox.Text = string.Empty;
            endNumberSystemBox_Leave(null, null);
        }

        private void downloadTest_Click(object sender, EventArgs e)
        {
            numberForTranslateBox.Text = "1010";
            startNumberSystemBox_Enter(null, null);
            startNumberSystemBox.Text = "2";
            endNumberSystemBox_Enter(null, null);
            endNumberSystemBox.Text = "10";
        }
    }
}
