#define LINQ
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using wpu221_lesson3__LINQ;
using System.Runtime.CompilerServices;

namespace wpu221_lesson3_LINQ
{
    public class Program
    {
        SqlConnection conn = null;
        Program()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL_dbGeography"].ConnectionString;
        }
        static void Main(string[] args)
        {
#if AddToDb
            Program program = new Program();
            string[] countries = File.ReadAllLines("Z:\\Academy_TOP\\ADO_NET\\wpu221_lesson3_ LINQ\\countries.txt");
            foreach (string country in countries)
            {
                string[] fields = country.Split(' ');
                program.InsertCountry(fields[0], fields[1], fields[2], float.Parse(fields[3]));
            }
#endif
#if LINQ
            DataClasses1DataContext db = new DataClasses1DataContext();
            
            //Отобразить всю информацию о странах
            var queryResults1 = from c in db.Countries                               
                               select new { c.Name, c.Сapital, c.PartOfTheWorld, c.Area };

            //Отобразить название всех европейских стран
            var queryResults2 = from c in db.Countries
                               where c.PartOfTheWorld =="Европа"
                               select c.Name;

            //Отобразить название стран с площадью большей конкретного числа
            var queryResults3 = from c in db.Countries
                                where c.Area > 1000000
                                select new { c.Name, c.Area };

            //Отобразить все страны, у которых в названии есть буквы ф
            var queryResults4 = from c in db.Countries
                                where c.Name.Contains("ф")
                                select c.Name;

            //Отобразить все страны, у которых название начинается с буквы ч
            var queryResults5 = from c in db.Countries
                                where c.Name.StartsWith("Ч")
                                select c.Name;

            //Отобразить название стран, у которых площадь находится в указанном диапазоне
            var queryResults6 = from c in db.Countries
                                where c.Area > 500000 && c.Area < 1000000
                                select c.Name;

            //Показать топ-5 стран по площади
            var queryResults7 = from c in db.Countries
                                orderby c.Area descending
                                select c.Name;
            //foreach (var item in queryResults7.Take(5)) Console.WriteLine(item);

            //Показать страну с самой большой площадью
            float? area_max = db.Countries.Max(c => c.Area);
            string queryResults8 = db.Countries.Where(c => c.Area == area_max).Select(c => c.Name).First();            
            Console.WriteLine(queryResults8);



            Console.WriteLine("Press any key to complete...");
            Console.ReadLine();
#endif
        }

        void InsertCountry(string pName, string pСapital, string pPartOfTheWorld, float pArea)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertCountry", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pName", SqlDbType.NVarChar).Value = pName;
                cmd.Parameters.Add("@pСapital", SqlDbType.NVarChar).Value = pСapital;
                cmd.Parameters.Add("@pPartOfTheWorld", SqlDbType.NVarChar).Value = pPartOfTheWorld;
                cmd.Parameters.Add("@pArea", SqlDbType.Real).Value = pArea;
                cmd.ExecuteNonQuery();
            }
            finally { if (conn != null) conn.Close(); }
        }
    }
}
