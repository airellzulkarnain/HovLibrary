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
    public partial class MasterMemberForm : Form
    {
        HovLibraryDatabaseDataContext db = new HovLibraryDatabaseDataContext();
        public MasterMemberForm()
        {
            InitializeComponent();
            memberDataGridView.DataSource = (
                from member in db.members
                select new
                {
                    member.id, 
                    member.name, 
                    member.phone, 
                    member.email, 
                    member.city_of_birth, 
                    member.date_of_birth, 
                    member.gender, 
                }
                ).ToList();
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "editButton";
            editButton.HeaderText = "";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            memberDataGridView.Columns.Add( editButton );
            memberDataGridView.CellClick += new DataGridViewCellEventHandler(EditButton_Clicked);
        }

        private void MasterMemberForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.master_member_active = false;
        }

        private void MasterMemberForm_Load(object sender, EventArgs e)
        {

        }

        private void EditButton_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == memberDataGridView.Columns["editButton"].Index) toggle_input();
        }

        private void toggle_input()
        {
            nameTextBox.Enabled = !nameTextBox.Enabled;
            phoneTextBox.Enabled = !phoneTextBox.Enabled;
            emailTextBox.Enabled = !emailTextBox.Enabled;
            cityOfBirthTextBox.Enabled = !cityOfBirthTextBox.Enabled;
            dateOfBirthDateTimePicker.Enabled = !dateOfBirthDateTimePicker.Enabled;
            radioButton1.Enabled = !radioButton1.Enabled;
            radioButton2.Enabled = !radioButton2.Enabled;
            saveChangesButton.Enabled = !saveChangesButton.Enabled;
        }
    }
}
