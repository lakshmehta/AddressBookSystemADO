using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemADO
{
    class AddressBookMain
    {
        public static String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void CheckConnection()
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    Console.WriteLine("connection open");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("connection close");
            }
        }
        public void CreateTable()
        {
            try
            {
                using (this.connection)
                {
                    string query = @"insert into AddreshBookADo values
                    ('preeti','Semwal','Thane','mumbai.','MH',548512,'2134567890','neha123@gmail.com','Addressbook4', 'friends');";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("success");
                    }
                    else
                    {
                        Console.WriteLine("fail");
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"sorry!!! {e}");
            }
        }
    }
}
