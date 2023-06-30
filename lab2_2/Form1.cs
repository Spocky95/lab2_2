using lab2_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace lab2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)// left data grid
        {

        }

        private void button3_Click(object sender, EventArgs e)//add both
        {
            // With transaction
            /*using (Lab2Context db = new())
            {
                using (IDbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string authorName = textBox3.Text;
                        string authorDescription = textBox4.Text;

                        Author addedAuthor = new() { Name = authorName, Description = authorDescription };
                        db.Authors.Add(addedAuthor);
                        db.SaveChanges();

                        db.Authors.Load();
                        this.authorBindingSource.DataSource = db.Authors.Local.ToBindingList();

                        string bookTitle = textBox3.Text;
                        int bookPages;
                        if (!Int32.TryParse(textBox4.Text, out bookPages)) bookPages = 3;

                        db.Books.Add(new() { Title = bookTitle, Pages = bookPages });
                        db.SaveChanges();

                        db.Books.Load();
                        this.bookBindingSource.DataSource = db.Books.Local.ToBindingList();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Occured error: {ex.Message}");

                        db.ChangeTracker.Clear();

                        db.Authors.Load();
                        this.dataGridView1.DataSource = db.Authors.Local.ToBindingList();

                        db.Books.Load();
                        this.dataGridView2.DataSource = db.Books.Local.ToBindingList();
                    }
                }
            }
            */

            // Without transaction
            using (Lab2Context db = new())
            {
                try
                {
                    string authorName = textBox1.Text;
                    string authorDescription = textBox2.Text;

                    Author addedAuthor = new() { Name = authorName, Description = authorDescription };
                    db.Authors.Add(addedAuthor);
                    db.SaveChanges();

                    db.Authors.Load();
                    this.authorBindingSource.DataSource = db.Authors.Local.ToBindingList();

                    string bookTitle = textBox3.Text;
                    int bookPages;
                    if (!Int32.TryParse(textBox4.Text, out bookPages)) bookPages = 3;

                    db.Books.Add(new() { Title = bookTitle, Pages = bookPages });
                    db.SaveChanges();

                    db.Books.Load();
                    this.bookBindingSource.DataSource = db.Books.Local.ToBindingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Occured error: {ex.Message}");
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//name textbox
        {

        }

        private void button1_Click(object sender, EventArgs e)//add author
        {
            using (Lab2Context db = new())
            {
                try
                {
                    string authorName = textBox1.Text;
                    string authorDescription = textBox2.Text;

                    db.Authors.Add(new() { Name = authorName, Description = authorDescription });
                    db.SaveChanges();

                    db.Authors.Load();
                    this.authorBindingSource.DataSource = db.Authors.Local.ToBindingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Occured erorr {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//add book
        {
            using (Lab2Context db = new())
            {
                try
                {
                    string bookTitle = textBox3.Text;
                    int bookPages;
                    if (!Int32.TryParse(textBox4.Text, out bookPages)) bookPages = 3;

                    db.Books.Add(new() { Title = bookTitle, Pages = bookPages });
                    db.SaveChanges();

                    db.Books.Load();
                    this.bookBindingSource.DataSource = db.Books.Local.ToBindingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Occured erorr {ex.Message}");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)//clear both
        {
            using (Lab2Context db = new())
            {
                db.Authors.RemoveRange(db.Authors);
                db.Books.RemoveRange(db.Books);
                db.SaveChanges();
            }

            fillAuthorDataGridView();
            fillBooksDataGridView();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//name description
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//title textbox
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//pages textbox
        {

        }

        public void fillAuthorDataGridView()
        {
            using (Lab2Context db = new())
            {
                try
                {
                    db.Authors.Load();
                    this.authorBindingSource.DataSource = db.Authors.Local.ToBindingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Occured erorr {ex.Message}");
                }
            }
        }

        public void fillBooksDataGridView()
        {
            using (Lab2Context db = new())
            {
                try
                {
                    db.Books.Load();
                    this.bookBindingSource.DataSource = db.Books.Local.ToBindingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Occured erorr {ex.Message}");
                }
            }
        }

    }
}