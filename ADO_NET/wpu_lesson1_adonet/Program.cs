#define READ
using System.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;


namespace wpu221_lesson1_adonet
{
    public class Program
    {
        SqlConnection? conn = null;
        SqlDataReader? rdr = null;
        public Program()
        {
            conn = new SqlConnection("Data Source=WINDOWS10\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StoredProcedure();
            program.InsertQuery();
        }

        public void InsertQuery()
        {
            try
            {
                conn.Open();

#if INSERT_TO_AUTHORS
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText =
                    @"insert into Authors (FirstName, LastName) values ('Fridrih', 'Nizshe');
                      insert into Authors (FirstName, LastName) values ('Robert', 'Kiosake');
                      insert into Authors (FirstName, LastName) values ('Albert', 'Entshyein');
                      insert into Authors (FirstName, LastName) values ('Azic', 'Azimov');
                      insert into Authors (FirstName, LastName) values ('Gerbert', 'Wels')";
                cmd.ExecuteNonQuery();
#endif

#if INSERT_TO_BOOKS
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"INSERT INTO Books (AuthorId,Title,PRICE,PAGES) values (3,'Rich daddy, poor daddy', 500, 100);
                                    INSERT INTO Books (AuthorId,Title,PRICE,PAGES) values (2,'Antichrist', 250, 400);
                                    INSERT INTO Books (AuthorId,Title,PRICE,PAGES) values (6,'War of the Worlds', 380, 170);";
                cmd.ExecuteNonQuery();
#endif

#if READ
                SqlCommand cmd = new SqlCommand("select * from Books", conn);
                rdr = cmd.ExecuteReader();

                for (int i = 1; i < rdr.FieldCount; i++)
                {
                    Console.Write(rdr.GetName(i).ToString() + "\t\t");
                }
                Console.WriteLine();
                int line = 0;
                foreach (var row in rdr)
                {
                    Console.WriteLine(rdr[1] + "\t\t" + rdr[2] + "\t" + rdr[3] + "\t\t" + rdr[4]);
                    line++;
                }
                Console.WriteLine("Обработано записей: " + line.ToString());
                Console.WriteLine();
#endif
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }
        public void InsertAuthor()
        {

            Console.WriteLine("Введите Имя автора:");
            string? FirstName = Console.ReadLine();
            Console.WriteLine("Введите Фамилию автора:");
            string? LastName = Console.ReadLine();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into Authors (FirstName, LastName) values (@FirstName,@LastName)";
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }
        public void InsertBook()
        {
            Console.WriteLine("Введите Имя автора:");
            string? FirstName = Console.ReadLine();
            Console.WriteLine("Введите Фамилию автора:");
            string? LastName = Console.ReadLine();
            Console.WriteLine("Введите название книги:");
            string? Title = Console.ReadLine();
            Console.WriteLine("Введите цену книги:");
            int? Price = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите количество страниц книги:");
            int? Pages = Convert.ToInt16(Console.ReadLine());

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT A.Id FROM Authors AS A WHERE FirstName = @FirstName AND LastName = @LastName";
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    conn.Close();
                    conn.Open();
                    cmd.CommandText =
                        @"insert into Authors (FirstName, LastName) values (@FirstName, @LastName);";
                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                if (rdr != null) conn.Close();
            }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Books (AuthorId, Title, PRICE, PAGES) SELECT A.Id, @Title, @PRICE, @PAGES FROM Authors AS A WHERE FirstName = @FirstName AND LastName = @LastName";
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Pages", Pages);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
        public void StoredProcedure()
        {
            int authorId = Convert.ToInt32(Console.ReadLine());
            conn.Open();
            SqlCommand cmd = new SqlCommand("getBooksNumber", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AuthorId", authorId);

            SqlParameter outputParam = new SqlParameter("@BookCount", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(outputParam);

            cmd.ExecuteNonQuery();
            Console.WriteLine(cmd.Parameters["@BookCount"].Value.ToString());

        }
    }
}

