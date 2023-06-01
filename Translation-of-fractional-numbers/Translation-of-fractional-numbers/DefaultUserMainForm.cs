using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Translation_of_fractional_numbers
{
    public partial class DefaultUserMainForm : Form
    {
        private const string _alphabet = "0123456789ABCDEF.-";
        private string _currentUser;

        public DefaultUserMainForm()
        {
            InitializeComponent();
        }

        public DefaultUserMainForm(string currentLine)
        {
            InitializeComponent();
            label21.Visible = false;
            LoadUserData(currentLine);
        }

        private void DefaultUserMainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadUserData(string userLogin)
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
            _currentUser = userLogin;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string messageToLog = "LogsUser";
            string Name = "Имя";
            string SurName = "Фамилия";
            string Login = "Логин";
            string Password = "Пароль";
            new ProfileEditForm(userLoginBox.Text, userPasswordBox.Text, userNameBox.Text, userSurnameBox.Text, false).ShowDialog();
            profileEditCount.Text = (Int32.Parse(warningsCount.Text) + 1).ToString();
            UpdateUserInfo(translateCountLabel.Text, profileEditCount.Text, warningsCount.Text, _currentUser);
            LoadUserData(userLoginBox.Text);
            UpdateLogInfo(Name, userNameBox.Text, messageToLog);
            UpdateLogInfo(SurName, userSurnameBox.Text, messageToLog);
            UpdateLogInfo(Login, userLoginBox.Text, messageToLog);
            UpdateLogInfo(Password, userPasswordBox.Text, messageToLog);
            
        }
        
        private void UpdateLogInfo(string message, string messageToLog, string user)
        {
            DateTime time;
            time = DateTime.Now;
            using (StreamWriter sw = new StreamWriter($"Users\\{user}.txt", true))
            {
                sw.WriteLine($"{message} - {messageToLog}: {time.ToShortTimeString()}\n");
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
            try
            {
                decimal decimalNumber = (decimal)ConvertToDecimal(Convert.ToDouble(numberForTranslateBox.Text, CultureInfo.InvariantCulture), Convert.ToInt32(startNumberSystemBox.Text));
                string result = ConvertFromDecimal(decimalNumber, Convert.ToInt32(endNumberSystemBox.Text));
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
                minus += result;
                resultBox.Text = minus;
                translateCountLabel.Text = (Int32.Parse(translateCountLabel.Text) + 1).ToString();
                UpdateUserInfo(translateCountLabel.Text, profileEditCount.Text, warningsCount.Text, _currentUser);
                ConvertToBinary(int.Parse(result), Convert.ToInt32(endNumberSystemBox.Text));
                UpdateLogInfo("Было переведено число " + numberForTranslateBox.Text + " из " + startNumberSystemBox.Text + " в " + endNumberSystemBox.Text, _currentUser);


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
            // Переводим число в двоичную систему счисления
            string binary = Convert.ToString(number, 2);
            // Дополняем нулями до 8 символов для байта
            binary = binary.PadLeft(8, '0');
            // Рассчитываем обратный код
            string inverted = new string(binary.Select(b => b == '1' ? '0' : '1').ToArray());
            // Рассчитываем прямой код
            string direct = binary;
            // Переводим обратный и прямой коды в заданную систему счисления
            inverted = Convert.ToString(Convert.ToInt32(inverted, 2), baseNumber);
            direct = Convert.ToString(Convert.ToInt32(direct, 2), baseNumber);
            binaryTextBox.Text = direct;
            inverseBinaryTextBox.Text = inverted;
            if (int.Parse(binaryTextBox.Text) != 0 && int.Parse(inverseBinaryTextBox.Text) != 0)
            {
                UpdateLogInfo("Было переведено число " + numberForTranslateBox.Text + " в обратный код с результатом: " + inverseBinaryTextBox.Text + " , прямой код: " + binaryTextBox.Text, _currentUser);
            }
            return new string[] { direct, inverted };
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
            UpdateLogInfo("Был загружен тестовый пример ", _currentUser);
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
    }
}
