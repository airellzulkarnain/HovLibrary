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
    public partial class NewBorrowingForm : Form
    {
        HovLibraryDatabaseDataContext db;
        public NewBorrowingForm()
        {
            AutoCompleteStringCollection titleStrColl = new AutoCompleteStringCollection();
            AutoCompleteStringCollection memberNameStrColl = new AutoCompleteStringCollection();
            db = new HovLibraryDatabaseDataContext();
            InitializeComponent();
            titleStrColl.AddRange((from bd in db.book_details where bd.deleted_at == null select bd.title).ToArray());
            memberNameStrColl.AddRange((from m in db.members where m.deleted_at == null select m.name).ToArray());
            titleTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            titleTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            titleTextBox.AutoCompleteCustomSource = titleStrColl;
            MemberNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MemberNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MemberNameTextBox.AutoCompleteCustomSource = memberNameStrColl;
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadBookListDataGridView();
        }

        private void LoadBookListDataGridView()
        {
            bookListDataGridView.DataSource = null;
            bookListDataGridView.Columns.Clear();
            bookListDataGridView.DataSource = (
            from books in db.books
            join b_loc in db.book_locations
            on books.book_location_id equals b_loc.id
            join b_detail in db.book_details
            on books.book_details_id equals b_detail.id
            where books.deleted_at == null
            && books.book_detail.title == titleTextBox.Text
            && books.return_date != null
            select new
            {
                books.id,
                code = $"{books.book_details_id}.{books.id}.{books.book_location_id}.{b_detail.publish_date.Year}",
                location = b_loc.name,
                status = (books.return_date != null) ? "available" : "unavailable"
            }
            ).ToList();
            DataGridViewCheckBoxColumn dgvCheckBox = new DataGridViewCheckBoxColumn();
            dgvCheckBox.Name = "selectCheckbox";
            dgvCheckBox.HeaderText = "";
            dgvCheckBox.ValueType = typeof(bool);
            dgvCheckBox.TrueValue = true;
            dgvCheckBox.FalseValue = false;
            dgvCheckBox.ThreeState = false;
            bookListDataGridView.Columns.Add( dgvCheckBox );
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int id = (
                from m in db.members 
                where m.deleted_at == null 
                && m.name.ToLower().Trim() == MemberNameTextBox.Text.ToLower().Trim()
                select m.id).First();
            List<int> selected_row_ids = new List<int>();
            foreach (DataGridViewRow row in bookListDataGridView.Rows)
            {
                if (!(row.Index > 0)) continue;
                if ((bool)row.Cells[bookListDataGridView.Columns["selectCheckbox"].Index].Value)
                {
                    selected_row_ids.Add(Convert.ToInt32(row.Cells[bookListDataGridView.Columns["id"].Index].Value));
                }
            }
            if ( id != 0 && selected_row_ids.Count > 0) 
            {
                foreach (int selected_row_id in selected_row_ids)
                {
                    book bk = (from b in db.books where b.id == selected_row_id select b).First();
                    bk.borrow_date = DateTime.Now;
                    bk.member_id = id;
                    bk.return_date = null;
                    bk.updated_at = DateTime.Now;
                    db.SubmitChanges();
                }
                LoadBookListDataGridView();
                titleTextBox.Text = string.Empty;
                MemberNameTextBox.Text = string.Empty;
            }
        }

        private void NewBorrowingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.new_borowing_active = false;
        }
    }
}
