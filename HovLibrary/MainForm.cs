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
    public partial class MainForm : Form
    {
        public static bool master_book_active = false, 
            master_member_active = false, 
            new_borowing_active = false, 
            all_borrowing_active = false;

        public MainForm(int employee_id)
        {
            InitializeComponent();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!master_book_active)
            {
                master_book_active = true;
                MasterBookForm masterBookForm = new MasterBookForm();
                masterBookForm.MdiParent = this;
                masterBookForm.Show();
            }
        }

        private void newBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!new_borowing_active)
            {
                new_borowing_active = true;
                NewBorrowingForm newBorrowingForm = new NewBorrowingForm();
                newBorrowingForm.MdiParent = this;
                newBorrowingForm.Show();
            }
        }

        private void allBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!all_borrowing_active)
            {
                all_borrowing_active = true;
                AllBorrowingForm allBorrowingForm = new AllBorrowingForm();
                allBorrowingForm.MdiParent = this;
                allBorrowingForm.Show();
            }
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!master_member_active)
            {
                master_member_active = true;
                MasterMemberForm masterMemberForm = new MasterMemberForm();
                masterMemberForm.MdiParent = this;
                masterMemberForm.Show();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
