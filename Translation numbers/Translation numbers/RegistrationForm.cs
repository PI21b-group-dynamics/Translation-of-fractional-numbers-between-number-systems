using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translation_numbers
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void accountLabel_Click(object sender, EventArgs e)
        {
            AuthForm authForm= new AuthForm();
            this.Hide();
            authForm.ShowDialog();

        }
    }
}
