using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary
{
    public partial class MasterBookForm : Form
    {
        HovLibraryDatabaseDataContext db;
        static int curr_id;
        static int curr_row_id;
        static bool input_active;
        HashSet<string> languageSet = new HashSet<string>();
        HashSet<int> pageCountSet = new HashSet<int>();
        HashSet<double> ratingsSet = new HashSet<double>();
        List<Helper.books> current_books;

        public MasterBookForm()
        {
            InitializeComponent();
            db = new HovLibraryDatabaseDataContext();
            curr_id = 0;
            curr_row_id = 0;
            input_active = false;
            searchByCombobox.Items.AddRange(new string[] { "title", "authors", "publisher" });
            mBookDgv.CellClick += new DataGridViewCellEventHandler(masterBookCell_Clicked);
            LoadMasterBookDataGridView();
        }

        private void update_filter()
        {
            languageSet = new HashSet<string>();
            pageCountSet = new HashSet<int>();
            ratingsSet = new HashSet<double>();
            languageCombobox.Items.Clear();
            pageCountComboBoxTo.Items.Clear();
            PageCountComboBoxFrom.Items.Clear();
            ratingsComboBoxTo.Items.Clear();
            ratingsComboBoxFrom.Items.Clear();
            foreach (DataGridViewRow item in mBookDgv.Rows)
            {
                languageSet.Add(item.Cells[mBookDgv.Columns["language"].Index].Value.ToString());
                pageCountSet.Add(Convert.ToInt32(item.Cells[mBookDgv.Columns["page_count"].Index].Value));
                ratingsSet.Add(Convert.ToDouble(item.Cells[mBookDgv.Columns["ratings"].Index].Value.ToString().Split('(')[0]));
            }
            foreach (string item in languageSet) {
                languageCombobox.Items.Add(item);
            }
            foreach (int item in pageCountSet) {
                PageCountComboBoxFrom.Items.Add(item);
                pageCountComboBoxTo.Items.Add(item);
            }
            foreach (double item in ratingsSet) {
                ratingsComboBoxFrom.Items.Add(item);
                ratingsComboBoxTo.Items.Add(item);
            }
        }

        private void MasterBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.master_book_active = false;
        }

        private void masterBookCell_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            curr_id = (int)mBookDgv.Rows[e.RowIndex].Cells[mBookDgv.Columns["id"].Index].Value;
            curr_row_id = e.RowIndex;
            if (e.ColumnIndex == mBookDgv.Columns["editButton"].Index && !input_active) {
                EditButton();
            }
            else if (e.ColumnIndex == mBookDgv.Columns["deleteButton"].Index && !input_active) {
                DeleteButton();
                return;
            }
            else if (e.ColumnIndex == mBookDgv.Columns["showButton"].Index && !input_active) {
                ShowButton();
            }
            LoadInput();

        }

        private void SearchButton_Clicked(object sender, EventArgs e) 
        {
            mBookDgv.DataSource = null;
            mBookDgv.Columns.Clear();
            switch (searchByCombobox.SelectedItem)
            {
                case "title":
                    mBookDgv.DataSource = (from mb in db.book_details 
                                           where mb.deleted_at == null 
                                           && SqlMethods.Like(mb.title, $"%{keywordTextBox.Text}%") 
                                           select new Helper.books
                                           {
                                               id = mb.id,
                                               language = mb.language,
                                               title = mb.title,
                                               isbn = mb.isbn,
                                               isbn13 = mb.isbn13,
                                               authors = mb.authors,
                                               publisher = mb.publisher,
                                               publish_date = mb.publish_date,
                                               page_count = mb.page_count,
                                               ratings = mb.ratings,
                                           }).ToList();
                    break;
                case "authors":
                    mBookDgv.DataSource = (from mb in db.book_details 
                                           where mb.deleted_at == null 
                                           && SqlMethods.Like(mb.authors, $"%{keywordTextBox.Text}%")  
                                           select new Helper.books
                                           {
                                               id = mb.id,
                                               language = mb.language,
                                               title = mb.title,
                                               isbn = mb.isbn,
                                               isbn13 = mb.isbn13,
                                               authors = mb.authors,
                                               publisher = mb.publisher,
                                               publish_date = mb.publish_date,
                                               page_count = mb.page_count,
                                               ratings = mb.ratings,
                                           }).ToList();
                    break;
                case "publisher":
                    mBookDgv.DataSource = (from mb in db.book_details 
                                           where mb.deleted_at == null 
                                           && SqlMethods.Like(mb.publisher, $"%{keywordTextBox.Text}%") 
                                           select new Helper.books
                                           {
                                               id = mb.id,
                                               language = mb.language,
                                               title = mb.title,
                                               isbn = mb.isbn,
                                               isbn13 = mb.isbn13,
                                               authors = mb.authors,
                                               publisher = mb.publisher,
                                               publish_date = mb.publish_date,
                                               page_count = mb.page_count,
                                               ratings = mb.ratings,
                                           }).ToList();
                    break;
            }
            current_books = mBookDgv.DataSource as List<Helper.books>;
            AddActionButton();
            update_filter();
        }

        private void FilterApply(object sender, EventArgs e) 
        {
            List<Helper.books> result_books = current_books;
            if (languageCombobox.SelectedItem != null)
            {
                result_books = (
                    from mb in result_books 
                    where mb.language == languageCombobox.SelectedItem.ToString() 
                    select mb).ToList();
            }
            if (PageCountComboBoxFrom.SelectedItem != null && pageCountComboBoxTo.SelectedItem != null)
            {
                result_books = (
                    from mb in result_books
                    where mb.publish_date >= publishDateTimePickerFrom.Value 
                    && mb.publish_date <= publishDateTimePickerTo.Value 
                    select mb).ToList();
            }
            if (ratingsComboBoxFrom.SelectedItem != null && ratingsComboBoxFrom.SelectedItem != null)
            {
                result_books = (
                    from mb in result_books
                    where Convert.ToDouble(mb.ratings.Split('(')[0]) >= (double)ratingsComboBoxFrom.SelectedItem
                    && Convert.ToDouble(mb.ratings.Split('(')[0]) <= (double)ratingsComboBoxTo.SelectedItem
                    select mb
                    ).ToList();
            }
            if (publishDateTimePickerFrom.Value >= (from mb in current_books select mb.publish_date).Max() 
                && publishDateTimePickerTo.Value <= (from mb in current_books select mb.publish_date).Min())
            {
                result_books = (
                    from mb in result_books
                    where mb.publish_date >= publishDateTimePickerFrom.Value
                    && mb.publish_date <= publishDateTimePickerTo.Value
                    select mb
                    ).ToList();
            }
            mBookDgv.DataSource = result_books;
        }
        private void SaveChanges(object sender, EventArgs e) 
        {
            if (
                titleTextBox.Text.Length > 0 &&
                Helper.letter_regex.IsMatch(languageTextBox.Text) &&
                Helper.letter_regex.IsMatch(authorsTextBox.Text) &&
                Helper.letter_regex.IsMatch(PublisherTextBox.Text) &&
                Helper.ratings_regex.IsMatch(ratingsTextBox.Text) &&
                Helper.number_regex.IsMatch(pageCountTextBox.Text) &&
                Helper.number_regex.IsMatch(isbn13TextBox.Text) &&
                Helper.number_regex.IsMatch(isbnTextBox.Text)
                ) {
                    var masterBook = (
                    from mb in db.book_details 
                    where mb.id == curr_id 
                    && mb.deleted_at == null 
                    select mb).First();
                    masterBook.title = titleTextBox.Text;
                    masterBook.language = languageTextBox.Text;
                    masterBook.isbn = isbnTextBox.Text;
                    masterBook.isbn13 = isbn13TextBox.Text;
                    masterBook.authors = authorsTextBox.Text;
                    masterBook.publisher = PublisherTextBox.Text;
                    masterBook.publish_date = publishDateTimePicker.Value;
                    masterBook.page_count = Convert.ToInt32(pageCountTextBox.Text);
                    masterBook.ratings = ratingsTextBox.Text;
                    db.SubmitChanges();
                    LoadMasterBookDataGridView();
                    ToggleInput(); 
                }
        }
        private void ShowButton() 
        {
            BookListForm bookListForm = new BookListForm(curr_id);
            bookListForm.ShowDialog(this);
        }
        private void DeleteButton() 
        {
            if (MessageBox.Show("Are you sure wanted to delete this row ?", "Delete Operation !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var masterBook = (from mb in db.book_details where mb.id == curr_id && mb.deleted_at == null select mb).First();
                masterBook.deleted_at = DateTime.Now;
                db.SubmitChanges();
                LoadMasterBookDataGridView();
            }
        }
        private void EditButton() 
        {
            if(!input_active) ToggleInput();
        }
        private void ToggleInput() 
        {
                input_active = !input_active;
                languageTextBox.Enabled = !languageTextBox.Enabled;
                titleTextBox.Enabled = !titleTextBox.Enabled;
                isbnTextBox.Enabled = !isbnTextBox.Enabled;
                isbn13TextBox.Enabled = !isbn13TextBox.Enabled;
                authorsTextBox.Enabled = !authorsTextBox.Enabled;
                PublisherTextBox.Enabled = !PublisherTextBox.Enabled;
                publishDateTimePicker.Enabled = !publishDateTimePicker.Enabled;
                pageCountTextBox.Enabled = !pageCountTextBox.Enabled;
                ratingsTextBox.Enabled = !ratingsTextBox.Enabled;
                saveChangesButton.Enabled = !saveChangesButton.Enabled;
        }
        private void ClearInput() 
        {
            languageTextBox.Text = string.Empty;
            titleTextBox.Text = string.Empty;
            isbnTextBox.Text = string.Empty;
            isbn13TextBox.Text = string.Empty;
            authorsTextBox.Text = string.Empty;
            PublisherTextBox.Text = string.Empty;
            publishDateTimePicker.Value = DateTime.Now;
            pageCountTextBox.Text = string.Empty;
            ratingsTextBox.Text = string.Empty;
        }

        private void LoadInput()
        {
            languageTextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["language"].Index].Value.ToString();
            titleTextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["title"].Index].Value.ToString();
            isbnTextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["isbn"].Index].Value.ToString();
            isbn13TextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["isbn13"].Index].Value.ToString();
            authorsTextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["authors"].Index].Value.ToString();
            PublisherTextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["publisher"].Index].Value.ToString();
            publishDateTimePicker.Value = (DateTime)mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["publish_date"].Index].Value;
            pageCountTextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["page_count"].Index].Value.ToString();
            ratingsTextBox.Text = mBookDgv.Rows[curr_row_id].Cells[mBookDgv.Columns["ratings"].Index].Value.ToString();
        }
        private void AddActionButton() 
        {
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            DataGridViewButtonColumn showButton = new DataGridViewButtonColumn();
            deleteButton.Name = "deleteButton";
            deleteButton.Text = "Delete";
            deleteButton.HeaderText = "";
            deleteButton.UseColumnTextForButtonValue = true;
            editButton.Name = "editButton";
            editButton.Text = "Edit";
            editButton.HeaderText = "";
            editButton.UseColumnTextForButtonValue = true;
            showButton.Name = "showButton";
            showButton.Text = "Show";
            editButton.HeaderText = "";
            showButton.UseColumnTextForButtonValue = true;
            mBookDgv.Columns.AddRange(new DataGridViewButtonColumn[] { showButton, editButton, deleteButton});
        }
        private void LoadMasterBookDataGridView() 
        {
            mBookDgv.DataSource = null;
            mBookDgv.Columns.Clear();
            mBookDgv.DataSource = (from book in db.book_details where book.deleted_at == null select new Helper.books
            {
                id = book.id, 
                language = book.language, 
                title = book.title,
                isbn = book.isbn, 
                isbn13 = book.isbn13, 
                authors = book.authors, 
                publisher = book.publisher, 
                publish_date = book.publish_date, 
                page_count = book.page_count, 
                ratings = book.ratings, 
            }).ToList();
            current_books = mBookDgv.DataSource as List<Helper.books>;
            AddActionButton();
            update_filter();
        }
        private void LoadSearchBy() { }
        private void LoadFilter() { }

        private void searchByCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchByCombobox.SelectedItem != null)
            {
                searchButton.Enabled = true;
                keywordTextBox.Enabled = true;
            }
            else
            {
                searchButton.Enabled = false;
                keywordTextBox.Enabled = false;
            }
        }
    }
}
