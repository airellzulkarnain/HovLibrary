using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary
{
    public partial class LoginForm : Form
    {
        private HovLibraryDatabaseDataContext db;
        private employee _employee;
        public int employee_id { get { return _employee.id; } }
        Regex email_regex = new Regex(@"^[a-zA-Z0-9.]+@[a-zA-Z]+.[a-zA-Z]+$", RegexOptions.IgnoreCase);
        public LoginForm()
        {
            InitializeComponent();
            db = new HovLibraryDatabaseDataContext();
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            _employee = Helper.checkLogin(emailTextBox.Text, passwordTextBox.Text, db);
            if (_employee != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (!email_regex.IsMatch(emailTextBox.Text))
                {
                    MessageBox.Show("Email is invalid !", "Login Failed !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Email or password invalid !", "Login Failed !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void PasswordKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                loginButton.PerformClick();
            }
        }

        private void EmailKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                passwordTextBox.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            emailTextBox.Focus();
        }
    }
}
