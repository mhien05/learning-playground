using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace _18032026
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestDbConnection();
        }

        public static void TestDbConnection()
        {
            var conn = new SqlConnection("Server=.;Database=HR;Trusted_Connection=yes; TrustServerCertificate=True");
            conn.Open();

            Console.WriteLine("Connect to db successfull");

            var cmd = conn.CreateCommand();
            cmd.CommandText = "select employee_id, email from employees";
            
            using var reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}");
                }
            }

            conn.Close(); 
        }
    }
}
