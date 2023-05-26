using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translation_numbers;

namespace Translation_of_fractional_numbers
{
    public partial class AdministratorMainForm : Form
    {
        private const string _alphabet = "0123456789ABCDEF";
        private string _currentUser;

        public AdministratorMainForm()
        {
            InitializeComponent();
        }

        public AdministratorMainForm(string userLogin)
        {
            InitializeComponent();

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

        private void AdministratorMainForm_Load(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (_currentUser == "admin")
            {
                MessageBox.Show("Данные главного администратора не могу быть изменены.", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }

        private void numberForTranslateBox_TextChanged(object sender, EventArgs e)
        {
            if (startNumberSystemBox.ForeColor == Color.Gray || endNumberSystemBox.ForeColor == Color.Gray)
                return;

            TranslateNumber();
        }

        private void startNumberSystemBox_TextChanged(object sender, EventArgs e)
        {
            if (numberForTranslateBox.Text == "" || endNumberSystemBox.ForeColor == Color.Gray)
                return;

            TranslateNumber();
        }

        private void endNumberSystemBox_TextChanged(object sender, EventArgs e)
        {
            if (numberForTranslateBox.Text == "" || startNumberSystemBox.ForeColor == Color.Gray)
                return;

            TranslateNumber();
        }

        private void TranslateNumber()
        {
            if (numberForTranslateBox.Text != "")
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
            }        
        }

        static double ConvertToDecimal(string number, int baseValue)
        {
            if (baseValue < 2 || baseValue > 16)
            {
                throw new ArgumentException("Неверное или неподдерживаемое основание системы счисления.");
            }

            if (!Regex.IsMatch(number, $"^[0-{baseValue - 1}]+([.,][0-{baseValue - 1}]+)?$"))
            {
                throw new ArgumentException("Неверный формат числа в системе счисления.");
            }

            string decimalNumber = number.Replace(",", ".");

            string[] parts = decimalNumber.Split('.');

            double resultInt = 0;
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
            if (baseValue < 2 || baseValue > 16)
            {
                throw new ArgumentException("Неверное или неподдерживаемое основание системы счисления.");
            }

            double intPart = Math.Truncate(decimalNumber);
            double fractionPart = decimalNumber - intPart;

            string resultInt = "";
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

        }

        private void startNumberSystemBox_KeyPress(object sender, KeyPressEventArgs e)
        {
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
    }
}
