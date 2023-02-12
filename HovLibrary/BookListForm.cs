using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary
{
    public partial class BookListForm : Form
    {
        HovLibraryDatabaseDataContext db;
        private book_detail _book_detail;
        public BookListForm(int book_detail_id)
        {
            InitializeComponent();
            db = new HovLibraryDatabaseDataContext();
            _book_detail = (from b_detail in db.book_details where b_detail.deleted_at == null && b_detail.id == book_detail_id select b_detail).First();
            LoadDataGridView();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(DeleteCellButton_Clicked);
            locationComboBox.DataSource = (from b_loc in db.book_locations where b_loc.deleted_at == null select b_loc).ToList();
            locationComboBox.DisplayMember = "name";
            locationComboBox.ValueMember = "id";
            titleTextBox.Text = (from b_detail in db.book_details where b_detail.id == _book_detail.id select b_detail.title).First();

        }

        private void locationComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int id = (from b in db.books select b.id).Max() + 1;
            CodetextBox.Text = $"{_book_detail.id}.{id}.{locationComboBox.SelectedValue}.{_book_detail.publish_date.Year}";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            book b = new book() 
            {
                book_details_id=_book_detail.id, 
                book_location_id=Convert.ToInt32(locationComboBox.SelectedValue), 
                created_at=DateTime.Now,
            };
            db.books.InsertOnSubmit(b);
            db.SubmitChanges();
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = (
            from books in db.books
            join b_loc in db.book_locations
            on books.book_location_id equals b_loc.id
            join b_detail in db.book_details
            on books.book_details_id equals b_detail.id
            where books.deleted_at == null
            && books.book_details_id == _book_detail.id
            select new
            {
                books.id,
                code = $"{books.book_details_id}.{books.id}.{books.book_location_id}.{b_detail.publish_date.Year}",
                location = b_loc.name,
                status = (books.return_date != null) ? "available" : "unavailable"
            }
            ).ToList();
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Text = "Delete";
            dataGridViewButtonColumn.Name = "deleteButton";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(dataGridViewButtonColumn);
        }

        private void DeleteCellButton_Clicked(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.ColumnIndex == dataGridView1.Columns["deleteButton"].Index 
                && e.RowIndex >= 0 
                && dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["status"].Index].Value.ToString() == "available")
            {
                if (MessageBox.Show("Are you sure want to delete this row ?", "Delete Operation!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var book = (
                        from b in db.books
                        where b.id == Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["id"].Index].Value)
                        select b
                        ).First();
                    book.deleted_at = DateTime.Now;
                    db.SubmitChanges();
                    LoadDataGridView();
                }
            }
        }
    }
}
