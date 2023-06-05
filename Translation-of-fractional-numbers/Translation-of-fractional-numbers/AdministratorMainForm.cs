using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Translation_of_fractional_numbers
{
    public partial class AdministratorMainForm : Form
    {
        private const string _alphabet = "0123456789ABCDEF.-";
        private string _currentUser;
        private DataTable _dataTable;

        public AdministratorMainForm()
        {
            InitializeComponent();
            deleteButton.Enabled = false;
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
                else if (Path.GetFileNameWithoutExtension(filepath).Contains("Log"))
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
                index++;
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox.Items.Add(column.HeaderText);
            }
            comboBox.SelectedIndex = 0;

            _dataTable = new DataTable();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                _dataTable.Columns.Add(column.HeaderText);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dataRow = _dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                _dataTable.Rows.Add(dataRow);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = _dataTable;
            label26.Text = "Количество записей: " + dataGridView1.Rows.Count;
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
            if (_currentUser == "admin")
                MessageBox.Show("Главный администратор не может редактировать свои данные", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            string messageToLog = "AdminEditLogs";
            new ProfileEditForm(userLoginBox.Text, userPasswordBox.Text, userNameBox.Text, userSurnameBox.Text, true).ShowDialog();
            profileEditCount.Text = (Int32.Parse(warningsCount.Text) + 1).ToString();
            UpdateUserInfo(translateCountLabel.Text, profileEditCount.Text, warningsCount.Text, _currentUser);
            LoadUserAdminData(userLoginBox.Text);
            UpdateLogInfo("Имя", userNameBox.Text, messageToLog);
            UpdateLogInfo("Фамилия", userSurnameBox.Text, messageToLog);
            UpdateLogInfo("Логин", userLoginBox.Text, messageToLog);
            UpdateLogInfo("Пароль", userPasswordBox.Text, messageToLog);
        }

        private void UpdateLogInfo(string message, string dataToLog, string user)
        {
            DateTime time;
            time = DateTime.Now;
            using (StreamWriter sw = new StreamWriter($"Users\\{user}.txt", true))
            {
                sw.WriteLine($"{message} - {dataToLog}: {time.ToShortTimeString()}\n");
            }
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
            if (numberForTranslateBox.Text.Contains("."))
            {
                int countSymb = numberForTranslateBox.Text.Length - numberForTranslateBox.Text.IndexOf(".") - 1;
                if (countSymb > 6)
                {
                    symbolCountError.Visible = true;
                    resultBox.Text = string.Empty;
                    return;
                }
                try
                {
                    decimal decimalNumber = (decimal)ConvertToDecimal(Convert.ToDouble(numberForTranslateBox.Text, CultureInfo.InvariantCulture), Convert.ToInt32(startNumberSystemBox.Text));
                    string result = ConvertFromDecimal(decimalNumber, Convert.ToInt32(endNumberSystemBox.Text));
                    resultBox.Text = DelZero(result);
                    translateCountLabel.Text = (Int32.Parse(translateCountLabel.Text) + 1).ToString();
                    UpdateUserInfo(translateCountLabel.Text, profileEditCount.Text, warningsCount.Text, _currentUser);
                    ConvertToBinary((int)decimalNumber, Convert.ToInt32(endNumberSystemBox.Text));
                    UpdateLogInfo("Было переведено число " + numberForTranslateBox.Text + " из " + startNumberSystemBox.Text + " в " + endNumberSystemBox.Text, _currentUser);
                }
                catch (Exception)
                {
                    label21.Visible = true;
                }
            }
            else
            {
                try
                {
                    decimal decimalNumber = (decimal)ConvertToDecimal(Convert.ToDouble(numberForTranslateBox.Text, CultureInfo.InvariantCulture), Convert.ToInt32(startNumberSystemBox.Text));
                    string result = ConvertFromDecimal(decimalNumber, Convert.ToInt32(endNumberSystemBox.Text));
                    resultBox.Text = DelZero(result);
                    translateCountLabel.Text = (Int32.Parse(translateCountLabel.Text) + 1).ToString();
                    UpdateUserInfo(translateCountLabel.Text, profileEditCount.Text, warningsCount.Text, _currentUser);
                    ConvertToBinary((int)decimalNumber, Convert.ToInt32(endNumberSystemBox.Text));
                    UpdateLogInfo("Было переведено число " + numberForTranslateBox.Text + " из " + startNumberSystemBox.Text + " в " + endNumberSystemBox.Text, _currentUser);
                }
                catch (Exception)
                {
                    label21.Visible = true;
                }
            }
        }

        private string DelZero(string result)
        {
            string minus = "";
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '-')
                {
                    minus += result[i];
                    continue;
                }

                if (result[i] != '0')
                {
                    result = result.Substring(i, result.Length - i);
                    break;
                }
            }
            return minus += result;
        }

        private void UpdateUserInfo(string translates, string edits, string warnings, string user)
        {
            using (StreamWriter sw = new StreamWriter($"Users\\{user}Info.txt"))
            {
                sw.Write($"{translates}\n{edits}\n{warnings}\n");
            }
            if (_currentUser == "admin")
                LoadAdminData(_currentUser);
            else
            {
                LoadUserAdminData(_currentUser);
                LoadUsersData();
            }
        }

        static double ConvertToDecimal(double number, int baseValue)
        {
            if (baseValue < 1 || baseValue > 16) { throw new ArgumentException("Неверное или неподдерживаемое основание системы счисления."); }

            double decimalNumber = number;

            if (number < 0)
            {
                decimalNumber = Math.Abs(number);
            }

            string[] parts = decimalNumber.ToString().Replace(",", ".").Split('.');

            double resultInt = 0;
            string chars;

            if (baseValue == 1)
            {
                chars = "1";
                if (!decimalNumber.ToString().All(c => chars.Contains(c)))
                {
                    throw new ArgumentException("Некорректный символ в числе.");
                }

                for (int i = 0; i < parts[0].Length; i++)
                {
                    resultInt++;
                }
                return (number < 0) ? -resultInt : resultInt;
            }
            else
            {
                chars = _alphabet.Substring(0, baseValue) + "-,";
                if (!decimalNumber.ToString().All(c => chars.Contains(c)))
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

            double result = resultInt + resultFraction;

            return (number < 0) ? -result : result;
        }

        static string ConvertFromDecimal(decimal decimalNumber, int baseValue)
        {
            if (baseValue < 1 || baseValue > 16) { throw new ArgumentException("Неверное или неподдерживаемое основание системы счисления."); }

            bool isNegative = false;
            if (decimalNumber < 0)
            {
                isNegative = true;
                decimalNumber = Math.Abs(decimalNumber);
            }

            string resultInt = "";
            decimal intPart = Math.Truncate(decimalNumber);
            decimal fractionPart = decimalNumber - intPart;

            if (baseValue == 1)
            {
                for (int i = 0; i < (int)intPart; i++)
                {
                    resultInt += '1';
                }
                return (isNegative) ? "-" + resultInt : resultInt;
            }

            while (intPart > 0)
            {
                decimal remainder = intPart % baseValue;
                char digit = (remainder < 10) ? (char)('0' + (int)remainder) : (char)('A' + (int)remainder - 10);
                resultInt = digit + resultInt;
                intPart /= baseValue;
            }

            string resultFraction = "";
            for (int i = 0; i < 10 && fractionPart > 0; i++)
            {
                decimal value = fractionPart * baseValue;
                decimal intPartFraction = Math.Truncate(value);
                char digit = (intPartFraction < 10) ? (char)('0' + (int)intPartFraction) : (char)('A' + (int)intPartFraction - 10);
                resultFraction += digit;
                fractionPart = value - intPartFraction;
            }

            string result = resultInt;
            if (resultFraction.Length > 0)
            {
                result += "." + resultFraction;
            }

            return (isNegative) ? "-" + result : result;
        }

        private string[] ConvertToBinary(int number, int baseNumber)
        {
            string binary = Convert.ToString(number, 2);
            binary = binary.PadLeft(8, '0');
            string inverted = new string(binary.Select(b => b == '1' ? '0' : '1').ToArray());
            string direct = binary;

            inverted = ConvertFromDecimal(((decimal)ConvertToDecimal(Convert.ToDouble(inverted), 2)), baseNumber);
            direct = ConvertFromDecimal(((decimal)ConvertToDecimal(Convert.ToDouble(direct), 2)), baseNumber);
            binaryTextBox.Text = DelZero(direct);
            inverseBinaryTextBox.Text = DelZero(inverted);
            if (int.Parse(binaryTextBox.Text) != 0 && int.Parse(inverseBinaryTextBox.Text) != 0)
            {
                UpdateLogInfo("Было переведено число " + numberForTranslateBox.Text + " в обратный код с результатом: " + inverseBinaryTextBox.Text + " , прямой код: " + binaryTextBox.Text, _currentUser);
            }
            return new string[] { direct, inverted };
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
            UpdateLogInfo("Пользователь " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + " был назначен администратором ", _currentUser);
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

                if (e.KeyChar == '-' && numberForTranslateBox.Text.Contains("-"))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '-' && numberForTranslateBox.Text.Length == 0) { }
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

        private void DeleteSelectedUser()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                deleteButton.Enabled = true;
                // получаем имя пользователя из выбранной строки dataGridView
                string username = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string messageToLog = $"Был удален пользователь под следующим именем";
                UpdateLogInfo(messageToLog + " " + username, _currentUser);
                // вызываем функцию для удаления пользователя
                DeleteUser(username);
            }
        }

        private void DeleteUser(string username)
        {
            string userFilePath = $"Users\\{username}.txt";
            string userInfoFilePath = $"Users\\{username}Info.txt";

            if (File.Exists(userFilePath))
            {
                File.Delete(userFilePath);
            }

            if (File.Exists(userInfoFilePath))
            {
                File.Delete(userInfoFilePath);
            }

            // перезагрузка данных пользователей, чтобы обновить таблицу
            dataGridView1.Rows.Clear();
            LoadUsersData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedUser();
        }

        private void UpdateLogInfo(string messageToLog, string user)
        {
            DateTime time;
            time = DateTime.Now;
            using (StreamWriter sw = new StreamWriter($"Users\\{user}Log.txt", true))
            {
                sw.Write($"{messageToLog} ; {time.ToShortTimeString()}\n");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что двойной щелчок произошел на строке
            if (e.RowIndex >= 0)
            {
                // Получаем DataGridView, на котором произошел двойной щелчок
                DataGridView dataGridView = (DataGridView)sender;

                // Вызываем функцию для открытия файла
                OpenFileFromSelectedRow(dataGridView);
            }
        }

        private void OpenFileFromSelectedRow(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Получаем значение из ячейки с именем файла в выделенной строке
                string username = dataGridView.SelectedRows[0].Cells["Column7"].Value.ToString();
                string fileName = $"Users\\{username}Log.txt";

                try
                {
                    // Открываем файл с именем, указанным в ячейке
                    Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось открыть файл: " + ex.Message);
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text == "")
            {
                _dataTable.DefaultView.RowFilter = null;
                return;
            }

            try
            {
                _dataTable.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", comboBox.SelectedItem, textBox.Text);
            }
            catch
            {
                _dataTable.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", comboBox.SelectedItem, textBox.Text);
            }
        }
    }
}
