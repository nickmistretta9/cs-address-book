using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class AddressBook
    {
        const string fileURL = @"C:\Users\Nicholas Mistretta\Desktop\C#\Address Book\AddressBook\bin\addresses.txt";
        private List<Person> _people;

        public AddressBook()
        {
            _people = new List<Person>();
        }

        public void ReadFromFile()
        {
            string[] people = System.IO.File.ReadAllLines(fileURL);
            foreach (var person in people)
            {
                System.Console.WriteLine(person);
            }
        }

        public void AddPerson(Person person)
        {
            _people.Add(person);
            System.IO.File.AppendAllText(fileURL, person.ToString() + Environment.NewLine);
        }

        public void RemovePerson(Person person)
        {
            _people.Remove(person);
        }

        public void UpdatePerson()
        {

        }
    }
}
