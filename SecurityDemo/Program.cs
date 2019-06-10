using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=.;Initial Catalog=SecurityDemo;";
            using (var connection = new SqlConnection())
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString) {UserID = "User1", Password = "xx"};
                connection.ConnectionString = connectionStringBuilder.ConnectionString;
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * from Kunden";
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Name"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            using (var connection = new SqlConnection())
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString) {UserID = "User1", Password = "xx"};
                connection.ConnectionString = connectionStringBuilder.ConnectionString;
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "GetKunden";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Name"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
