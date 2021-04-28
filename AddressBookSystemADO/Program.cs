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
             data.addressbook_name = "AddressBook1";s
             data.addressbook_type = "Professional";
             check.EditContactUsingPersonName(data);


             data.first_name = "poonam";
             check.DeleteContactUsingName(data);
            */


            //check.RetrievePersonFromPErticulatCityOrState();

            //check.AddressBookSizeByCityANDState();
            //check.SortPersonNameByCity();
            check.GetNumberOfPersonsCountByType();
        }
        public static void checkthread()
        {
            AddressBookMain check = new AddressBookMain();
            // check.CheckConnection();
            AddressBookModel data = new AddressBookModel();
            //insert data
            data.first_name = "suman";
            data.last_name = "Gupta";
            data.address = "kotdwar";
            data.city = "Khandwa";
            data.state = "MP";
            data.zip = 723233;
            data.phone_number = "9879455434";
            data.email = "Aman1234@gmail.com";
            data.addressbook_name = "AddressBook1";
            data.addressbook_type = "Family";
            check.Addcontatct(data);
        }
    }
}
