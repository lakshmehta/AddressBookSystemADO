using System;
using System.Collections.Generic;
using System.Data;
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
        public bool Addcontatct(AddressBookModel data)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                using (connection)
                {
                    SqlCommand command = new SqlCommand("Sp_AddContactDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", data.first_name);
                    command.Parameters.AddWithValue("@last_name", data.last_name);
                    command.Parameters.AddWithValue("@address", data.address);
                    command.Parameters.AddWithValue("@city", data.city);
                    command.Parameters.AddWithValue("@state", data.state);
                    command.Parameters.AddWithValue("@zip", data.zip);
                    command.Parameters.AddWithValue("@phone_number", data.phone_number);
                    command.Parameters.AddWithValue("@email", data.email);
                    command.Parameters.AddWithValue("@addressbook_name", data.addressbook_name);
                    command.Parameters.AddWithValue("@addressbook_type", data.addressbook_type);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("connection close");
            }
        }
        public void EditContactUsingPersonName(AddressBookModel data)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string updateQuery = @"UPDATE AddreshBookADo SET last_name = @last_name, City = @city, state = @state, email = @email, addressbook_name = @addressbook_name, addressbook_type = @addressbook_type WHERE first_name = @first_name;";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@first_name", data.first_name);
                    command.Parameters.AddWithValue("@last_name", data.last_name);
                    command.Parameters.AddWithValue("@city", data.city);
                    command.Parameters.AddWithValue("@state", data.state);
                    command.Parameters.AddWithValue("email", data.email);
                    command.Parameters.AddWithValue("@addressbook_name", data.addressbook_name);
                    command.Parameters.AddWithValue("@addressbook_type", data.addressbook_type);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Contact Updated successfully");
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
