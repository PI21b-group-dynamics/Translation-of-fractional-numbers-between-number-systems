﻿using System;
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
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void goToRegForm_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            this.Hide();
            reg.ShowDialog();
        }
    }
}