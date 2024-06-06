using System;
using System.Data.Common;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Lb3_Primer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Отримую дані...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Підключаюсь...");

                conn.Open();
                Console.WriteLine("Пiдключення успiшне!");
                QueryEmployee(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Console.Read();
        }

        private static void QueryEmployee(MySqlConnection conn)
        {
            string staff_num, staff_name, staff_post;
            string sql = "SELECT * FROM mydb.k_staff";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        staff_num = reader["staff_num"].ToString();
                        staff_name = reader["staff_name"].ToString();
                        staff_post = reader["staff_post"].ToString();
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("Код cотрудника:" + staff_num + "   Ім'я:" + staff_name + "   Посада:" + staff_post);
                        Console.WriteLine("---------------------------------------------------------");
                    }
                }
            }
        }

    }
}
