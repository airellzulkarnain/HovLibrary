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
        static bool input_active = false;
        static int curr_member_id;
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
            addButton();
        }

        private void addButton()
        {
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "editButton";
            editButton.HeaderText = "";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            memberDataGridView.Columns.Add(editButton);
            memberDataGridView.CellClick += new DataGridViewCellEventHandler(EditButton_Clicked);
        }

        private void MasterMemberForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.master_member_active = false;
            curr_member_id = 0;
            input_active = false;
        }

        private void MasterMemberForm_Load(object sender, EventArgs e)
        {

        }

        private void save_changes(object sender, EventArgs e)
        {
            if (
                Helper.letter_regex.IsMatch(nameTextBox.Text) &&
                Helper.number_regex.IsMatch(phoneTextBox.Text) && 
                Helper.email_regex.IsMatch(emailTextBox.Text) && 
                Helper.letter_regex.IsMatch(cityOfBirthTextBox.Text) && 
                (radioButton1.Checked || radioButton2.Checked)
                )
            {
                member mmbr = (from m in db.members where m.id == curr_member_id select m).First();
                mmbr.name = nameTextBox.Text;
                mmbr.phone = phoneTextBox.Text;
                mmbr.email = emailTextBox.Text;
                mmbr.city_of_birth = cityOfBirthTextBox.Text;
                mmbr.date_of_birth = dateOfBirthDateTimePicker.Value;
                mmbr.gender = (radioButton1.Checked) ? radioButton1.Text : radioButton2.Text;
                mmbr.gender = mmbr.gender.ToLower();
                mmbr.updated_at = DateTime.Now;
                db.SubmitChanges();
                memberDataGridView.Columns.Clear();
                memberDataGridView.DataSource = null;
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
                addButton();
                toggle_input();
            }
        }


        private void EditButton_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == memberDataGridView.Columns["editButton"].Index && !input_active) toggle_input();
            curr_member_id = (int)memberDataGridView.Rows[e.RowIndex].Cells[memberDataGridView.Columns["id"].Index].Value;
            nameTextBox.Text = memberDataGridView.Rows[e.RowIndex].Cells[memberDataGridView.Columns["name"].Index].Value.ToString();
            phoneTextBox.Text = memberDataGridView.Rows[e.RowIndex].Cells[memberDataGridView.Columns["phone"].Index].Value.ToString();
            emailTextBox.Text = memberDataGridView.Rows[e.RowIndex].Cells[memberDataGridView.Columns["email"].Index].Value.ToString();
            cityOfBirthTextBox.Text = memberDataGridView.Rows[e.RowIndex].Cells[memberDataGridView.Columns["city_of_birth"].Index].Value.ToString();
            dateOfBirthDateTimePicker.Value = (DateTime)memberDataGridView.Rows[e.RowIndex].Cells[memberDataGridView.Columns["date_of_birth"].Index].Value;
            switch (memberDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString())
            {
                case "male":
                    radioButton1.Select();
                    break;
                case "female":
                    radioButton2.Select();
                    break;
            }
        }

        private void clear_input()
        {
            nameTextBox.Text = string.Empty;
            phoneTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            cityOfBirthTextBox.Text = string.Empty;
            dateOfBirthDateTimePicker.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
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
            input_active = !input_active;
        }
    }
}
