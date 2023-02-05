using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary
{
    public partial class MasterBookForm : Form
    {
        public MasterBookForm()
        {
            InitializeComponent();
        }

        private void MasterBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.master_book_active = false;
        }
    }
}
