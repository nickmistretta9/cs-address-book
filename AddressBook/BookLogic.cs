using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class BookLogic
    {
        private List<string> _options = new List<string>();
        private AddressBook _addressBook = new AddressBook();

        public BookLogic()
        {
            _addressBook = new AddressBook();
            _options.Add("1) View current address book");
            _options.Add("2) Add person(s) to the address book");
            _options.Add("3) Remove person(s) from the address book");
            _options.Add("4) Update person(s) in the address book");
            _options.Add("5) Quit");
        }
        public void Run()
        {
            bool finished = false;
            Console.WriteLine("--- Welcome to the Address Book App. Please choose from the options below to get started! ---");
            while(!finished)
            {
                Console.WriteLine("What would you like to do?");
                foreach(var option in _options)
                    Console.WriteLine(option);
                var input = Console.ReadLine();
                switch(input)
                {
                    default:
                    case "1":
                        break;
                    case "2":
                        _addressBook.AddPerson();
                        break;
                    case "3":
                        _addressBook.RemovePerson();
                        break;
                    case "4":
                        _addressBook.UpdatePerson();
                        break;
                    case "5":
                        Console.WriteLine("--- Thank you for using the Address Book App. ---");
                        finished = true;
                        break;
                }
            }

        }
    }
}
