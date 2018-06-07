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
            Console.WriteLine("--- Welcome to the Address Book App. Please choose from the options below to get started! ---");
            foreach(var option in _options)
                Console.WriteLine(option);
        }
    }
}
