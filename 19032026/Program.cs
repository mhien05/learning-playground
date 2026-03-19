using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;

namespace _19032026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = builder.Build();

            using var conn = new SqlConnection(configuration.GetConnectionString("HRDB"));

            conn.Open();

            //ListCountries(conn);
            //DisplayCountriesCount(conn);

            Console.WriteLine(
            CreateNewEmployee(
                "huy",
                "tran",
                "0852227725",
                "hientm0978@gmail.com",
                DateTime.Today,
                9,
                100000,
                100,
                6,

                conn));

            conn.Close();
        }

        private static int CreateNewEmployee(
            string firstName, string lastName, string phonenumber, string email, DateTime hireDate, int jobId, decimal salary, int managerId, int departmentId,
            SqlConnection conn
            )
        {
            var cmd = new SqlCommand(@"INSERT INTO employees (
                            first_name,
                            last_name,
                            email,
                            phone_number,
                            hire_date,
                            job_id,
                            salary,
                            manager_id,
                            department_id
                   ) VALUES (
                            @first_name,
                            @last_name,
                            @email,
                            @phone_number,
                            @hire_date,
                            @job_id,
                            @salary,
                            @manager_id,
                            @department_id
                          )
                ", conn);

            cmd.Parameters.Add(new SqlParameter("@first_name", System.Data.SqlDbType.VarChar, 20)).Value = firstName;
            cmd.Parameters.Add(new SqlParameter("@last_name", System.Data.SqlDbType.VarChar, 25)).Value = lastName;
            cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar, 100)).Value = email;
            cmd.Parameters.Add(new SqlParameter("@phone_number", System.Data.SqlDbType.VarChar, 20)).Value = phonenumber;
            cmd.Parameters.Add(new SqlParameter("@hire_date", System.Data.SqlDbType.Date)).Value = hireDate;
            cmd.Parameters.Add(new SqlParameter("@job_id", System.Data.SqlDbType.Int, 20)).Value = jobId;
            cmd.Parameters.Add(new SqlParameter("@salary", System.Data.SqlDbType.Decimal, 20)).Value = salary;
            cmd.Parameters.Add(new SqlParameter("@manager_id", System.Data.SqlDbType.Int, 20)).Value = managerId;
            cmd.Parameters.Add(new SqlParameter("@department_id", System.Data.SqlDbType.Int, 20)).Value = departmentId;

            var result = cmd.ExecuteNonQuery();

            return result;
        }

        private static void DisplayCountriesCount(SqlConnection conn)
        {
            var cmd = new SqlCommand("select count(*) from countries", conn);

            int countCountries = (int)cmd.ExecuteScalar();
            Console.WriteLine($"Total rows: {countCountries}");
        }

        private static void ListCountries(SqlConnection conn)
        {
            var cmd = new SqlCommand("select * from countries", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader[0]}, Name: {reader.GetSqlString(1)}");
            }
            reader.Close();
        }
    }
}
