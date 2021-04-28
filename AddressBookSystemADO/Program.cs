using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book ADO.NET");
            AddressBookMain check = new AddressBookMain();
            check.CheckConnection();
           
            AddressBookModel data = new AddressBookModel();

           /* data.first_name = "Neha";
            data.last_name = "Gupta";
            data.city = "Bhopal";
            data.state = "Madhya Pradesh";
            data.email = "Neha432@gmail.com";
            data.addressbook_name = "AddressBook1";
            data.addressbook_type = "Professional";
            check.EditContactUsingPersonName(data);


            data.first_name = "poonam";
            check.DeleteContactUsingName(data);
           */


            check.RetrievePersonFromPErticulatCityOrState();
        }
    }
}
