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
    public partial class AllBorrowingForm : Form
    {
        HovLibraryDatabaseDataContext db;
        List<Helper.borrow> borrows;
        public AllBorrowingForm()
        {
            db = new HovLibraryDatabaseDataContext();
            InitializeComponent();
            BorrowStatusComboBox.Items.AddRange(new string[] { "OnGoing", "Late", "Returned" });
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            borrows = (
                from b in db.books
                where b.deleted_at == null
                && b.borrow_date != null
                select new Helper.borrow
                {
                    id = b.id,
                    memberName = b.member.name,
                    bookTitle = b.book_detail.title,
                    bookCode = $"{b.book_detail.id}.{b.id}.{b.book_location.id}.{b.book_detail.publish_date.Year}",
                    borrowDate = b.borrow_date,
                    returnDate = b.return_date,
                    fine=0
                }
                ).ToList();
            for(int i = 0; i < borrows.Count; i++)
            {
                if (DateTime.Now.Subtract(borrows[i].borrowDate.Value).Days > 7 && borrows[i].returnDate != null)
                {
                    borrows[i].fine = borrows[i].borrowDate.Value.Subtract(borrows[i].returnDate.Value).Days * 1000;
                }
            }
            dataGridView1.DataSource = borrows;
            DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            dgvbtn.HeaderText = string.Empty;
            dgvbtn.Name = "Return";
            dataGridView1.Columns.Add( dgvbtn );
            dgvbtn.UseColumnTextForButtonValue = false;
        }

        private void ReturnButton_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Return"].Index && dataGridView1.Rows[e.RowIndex].Cells["Return"].Value.ToString() == "Return")
            {
                book b_ = (from b in db.books where b.deleted_at == null && b.id == (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value select b).First();
                b_.return_date = DateTime.Now;
                b_.updated_at = DateTime.Now;
                db.SubmitChanges();
                LoadDataGridView();
            }
        }

        private void ApplyFilter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            switch (BorrowStatusComboBox.SelectedItem)
            {
                case "OnGoing":
                    dataGridView1.DataSource = (
                        from b in borrows 
                        where DateTime.Now.Subtract(b.borrowDate.Value).Days <= 7 
                        && b.returnDate == null
                        select b).ToList();
                    break;
                case "Late":
                    dataGridView1.DataSource = (
                        from b in borrows
                        where DateTime.Now.Subtract(b.borrowDate.Value).Days > 7
                        && b.returnDate == null
                        select b).ToList();
                    break;
                case "Returned":
                    dataGridView1.DataSource = (
                        from b in borrows where b.returnDate != null select b).ToList();
                    break;
                default:
                    dataGridView1.DataSource = borrows;
                    break;
            }
            if (dateTimePickerFrom.Value >= (DateTime)(from b in borrows select b.borrowDate).Min().Value 
                && dateTimePickerTo.Value <= (DateTime)(from b in borrows select b.borrowDate).Max().Value)
            {
                List<Helper.borrow> ds = dataGridView1.DataSource as List<Helper.borrow>;
                dataGridView1.DataSource = (from d in ds where d.borrowDate.Value >= dateTimePickerFrom.Value 
                                            && d.borrowDate.Value <= dateTimePickerTo.Value
                                            select ds).ToList();
            }
            DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            dgvbtn.HeaderText = string.Empty;
            dgvbtn.Name = "Return";
            dataGridView1.Columns.Add(dgvbtn);
            dgvbtn.UseColumnTextForButtonValue = false;
        }

        private void AllBorrowingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.all_borrowing_active = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                dataGridView1.Rows[e.RowIndex].Cells["Return"].Value = (dataGridView1.Rows[e.RowIndex].Cells["returnDate"].Value == null) ? "Return":"";
  
        }
    }
}
