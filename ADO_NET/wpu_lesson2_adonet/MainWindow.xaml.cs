using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;


namespace wpu_lesson2_adonet
{
    public partial class MainWindow : Window
    {
        private SqlDataReader reader;
        private DataTable table;
        private SqlConnection conn;
        DataSet? set = null;
        SqlDataAdapter? adapter = null;
        SqlCommandBuilder? builder = null;

        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["cs_SQLEXPRESS"].ConnectionString;
        }

        private void executeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(textBox.Text, conn);

                dataGrid.ItemsSource = null;
                conn.Open();

                table = new DataTable();
                reader = cmd.ExecuteReader();
                int line = 0;
                do
                {
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));

                            }
                            line++;
                        }
                        DataRow row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }
                } while (reader.NextResult());

                dataGrid.ItemsSource = table.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
        }

        private void fillAuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                set = new DataSet();
                adapter = new SqlDataAdapter(textBox.Text, conn);
                dataGrid.ItemsSource = null;
                builder = new SqlCommandBuilder(adapter);
                adapter.Fill(set, "authorsTable");
                dataGrid.ItemsSource = set.Tables["authorsTable"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateAuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd_updateAuthors = new SqlCommand("authorsTable", conn);
            cmd_updateAuthors.CommandType = CommandType.StoredProcedure;
            cmd_updateAuthors.Parameters.Add("@pId", SqlDbType.Int, 0, "Id");
            cmd_updateAuthors.Parameters["@pId"].SourceVersion = DataRowVersion.Original;
            cmd_updateAuthors.Parameters.Add("@pFirstName", SqlDbType.NVarChar, 50, "FirstName");
            cmd_updateAuthors.Parameters.Add("@pLastName", SqlDbType.NVarChar, 50, "LastName");            
            adapter.UpdateCommand = cmd_updateAuthors;

            SqlCommand cmd_insertAuthor = new SqlCommand("InsertAuthor", conn);
            cmd_insertAuthor.CommandType = CommandType.StoredProcedure;
            cmd_insertAuthor.Parameters.Add("@pFirstName", SqlDbType.NVarChar, 50, "FirstName");
            cmd_insertAuthor.Parameters.Add("@pLastName", SqlDbType.NVarChar, 50, "LastName");
            adapter.InsertCommand = cmd_insertAuthor;

            SqlCommand cmd_deleteAuthor = new SqlCommand("deleteAuthor", conn);
            cmd_deleteAuthor.CommandType = CommandType.StoredProcedure;
            SqlParameter parametr = cmd_deleteAuthor.Parameters.Add("@pId", SqlDbType.Int, 0, "Id");
            parametr.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = cmd_deleteAuthor;

            adapter.Update(set, "authorsTable");
        }
        

        private void fillBooksButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                set = new DataSet();
                adapter = new SqlDataAdapter(textBox.Text, conn);
                dataGrid.ItemsSource = null;
                builder = new SqlCommandBuilder(adapter);
                adapter.Fill(set, "bookTable");
                dataGrid.ItemsSource = set.Tables["bookTable"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateBooksButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd_updateBooks = new SqlCommand("UpdateBooks", conn);
            cmd_updateBooks.CommandType = CommandType.StoredProcedure;
            cmd_updateBooks.Parameters.Add("@pId", SqlDbType.Int, 0, "Id");
            cmd_updateBooks.Parameters["@pId"]. SourceVersion = DataRowVersion.Original;
            cmd_updateBooks.Parameters.Add("@pAuthorId", SqlDbType.Int, 3, "AuthorId");
            cmd_updateBooks.Parameters.Add("@pTitle", SqlDbType.NVarChar, 50, "Title");
            cmd_updateBooks.Parameters.Add("@pPrice", SqlDbType.Money, 3, "Price");
            cmd_updateBooks.Parameters.Add("@pPages", SqlDbType.Int, 3, "Pages");
            adapter.UpdateCommand = cmd_updateBooks;

            SqlCommand cmd_insertBook = new SqlCommand("InsertBook", conn);
            cmd_insertBook.CommandType = CommandType.StoredProcedure;
            cmd_insertBook.Parameters.Add("@pAuthorId", SqlDbType.Int, 3, "AuthorId");
            cmd_insertBook.Parameters.Add("@pTitle", SqlDbType.NVarChar, 50, "Title");
            cmd_insertBook.Parameters.Add("@pPRICE", SqlDbType.Money, 3, "PRICE");
            cmd_insertBook.Parameters.Add("@pPAGES", SqlDbType.Int, 3, "PAGES");
            adapter.InsertCommand = cmd_insertBook;

            SqlCommand cmd_deleteBook = new SqlCommand("DeleteBook", conn);
            cmd_deleteBook.CommandType=CommandType.StoredProcedure;            
            SqlParameter parametr = cmd_deleteBook.Parameters.Add("@pId", SqlDbType.Int, 0, "Id");
            parametr.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = cmd_deleteBook;

            adapter.Update(set, "bookTable");
        }        
    }
}
