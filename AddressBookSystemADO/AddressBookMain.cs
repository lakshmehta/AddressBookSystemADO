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
        public void DeleteContactUsingName(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("Sp_DeletContactDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.first_name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Contact Deleted successfully");
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
        public void RetrievePersonFromPErticulatCityOrState()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT * FROM AddreshBookADo WHERE city = 'Rishikesh' OR state = 'Uk';
                        SELECT * FROM AddreshBookADo WHERE city = 'Ruderpryag' OR state = 'Uk'; ", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.first_name = reader.GetString(0);
                                model.last_name = reader.GetString(1);
                                model.address = reader.GetString(2);
                                model.city = reader.GetString(3);
                                model.state = reader.GetString(4);
                                model.zip = reader.GetInt32(5);
                                model.phone_number = reader.GetString(6);
                                model.email = reader.GetString(7);

                                Console.WriteLine($"\nFirrst Nmae::{model.first_name}\nlast name::{model.last_name}\naddress::{model.address}\ncity::{model.city}\nstate::{model.state}\nzip::{model.zip}\nphone_number::{model.phone_number}\nemail::{model.email}");
                                Console.WriteLine("-------------\n");
                            }
                             if (reader.NextResult())
                             {
                                 while (reader.Read())
                                 {
                                     model.first_name = reader.GetString(0);
                                     model.last_name = reader.GetString(1);
                                     model.address = reader.GetString(2);
                                     model.city = reader.GetString(3);
                                     model.state = reader.GetString(4);
                                     model.zip = reader.GetInt32(5);
                                     model.phone_number = reader.GetString(6);
                                     model.email = reader.GetString(7);
                                     Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", model.first_name, model.last_name, model.address, model.city,
                                         model.state, model.zip, model.phone_number, model.email);
                                     Console.WriteLine("\n");
                                 }
                             }
                        }
                    }
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
        public void AddressBookSizeByCityANDState()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT COUNT(first_name) FROM AddreshBookADo WHERE city = 'Rishikesh' AND state = 'UK'; 
                        SELECT COUNT(first_name) FROM AddreshBookADo WHERE city = 'Ruderpryag' AND state = 'UP';", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var count = reader.GetInt32(0);
                                Console.WriteLine($"Number of Persons belonging to City 'Rishikesh' And State 'Uk' : {count}");
                                Console.WriteLine("\n");
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    var count = reader.GetInt32(0);
                                    Console.WriteLine($"Number of Persons belonging to City 'Ruderpryag' And State 'UP' : {count}");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
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
        public void SortPersonNameByCity()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT * FROM AddreshBookADo WHERE city = 'Rishikesh' order by first_name; 
                        SELECT * FROM AddreshBookADo WHERE city = 'Ruderpryag' order by first_name, last_name;", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("------Sorted Contact based of first name of person belonging to city Rishikesh-----");
                            while (reader.Read())
                            {
                                model.first_name = reader.GetString(0);
                                model.last_name = reader.GetString(1);
                                model.address = reader.GetString(2);
                                model.city = reader.GetString(3);
                                model.state = reader.GetString(4);
                                model.zip = reader.GetInt32(5);
                                model.phone_number = reader.GetString(6);
                                model.email = reader.GetString(7);

                                Console.WriteLine($"\nFirrst Nmae::{model.first_name}\nlast name::{model.last_name}\naddress::{model.address}\ncity::{model.city}\nstate::{model.state}\nzip::{model.zip}\nphone_number::{model.phone_number}\nemail::{model.email}");

                                Console.WriteLine("------------\n");
                            }
                            if (reader.NextResult())
                            {
                                Console.WriteLine("------Sorted Contact based of first name of person belonging to city Ruderpryag-----");
                                while (reader.Read())
                                {
                                    model.first_name = reader.GetString(0);
                                    model.last_name = reader.GetString(1);
                                    model.address = reader.GetString(2);
                                    model.city = reader.GetString(3);
                                    model.state = reader.GetString(4);
                                    model.zip = reader.GetInt32(5);
                                    model.phone_number = reader.GetString(6);
                                    model.email = reader.GetString(7);

                                    Console.WriteLine($"\nFirrst Nmae::{model.first_name}\nlast name::{model.last_name}\naddress::{model.address}\ncity::{model.city}\nstate::{model.state}\nzip::{model.zip}\nphone_number::{model.phone_number}\nemail::{model.email}");
                                    Console.WriteLine("--------------\n");
                                }
                            }
                        }
                    }
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
