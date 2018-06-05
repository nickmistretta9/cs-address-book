using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
    public class AddressBook
    {
        const string fileURL = @"C:\Users\Nick\Desktop\C# Programs\AddressBook\AddressBook\bin\addresses.txt";
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
                Console.WriteLine(person);
            }
        }

        public bool AddPerson(Person personToAdd)
        {
            foreach(var person in _people)
            {
                if(_people.Contains(person))
                {
                    Console.WriteLine("Person already exists in your Address Book");
                    return false;
                }
            }

            _people.Add(personToAdd);
            System.IO.File.AppendAllText(fileURL, personToAdd.ToString() + Environment.NewLine);
            return true;
        }

        public void RemovePerson()
        {
            var personToRemove = FindPerson();
            _people.Remove(personToRemove);
        }

        public void UpdatePerson()
        {

        }

        private Person FindPerson()
        {
            Person personToReturn = new Person();
            List<string> options = new List<string>() {
                "1) Enter a first name",
                "2) Enter a last name",
                "3) Enter an address",
                "4) Enter a phone number"
            };
            Console.WriteLine("How would you like to search the address book?");
            foreach(var option in options)
                Console.WriteLine(option);
            string input = Console.ReadLine();
            switch(input)
            {
                default:
                case "1":
                    Console.Write("Enter the first name to search by: ");
                    string firstName = Console.ReadLine();
                    IEnumerable<Person> people = _people.Where(p => p.FirstName == firstName);
                    Console.WriteLine("{0} person(s) found with the first name {1}. Which one would you like to look up?", people.Count(), firstName);
                    Dictionary<int, Person> peopleLookup = new Dictionary<int, Person>();
                    var count = 0;
                    foreach (var person in people)
                    {
                        peopleLookup.Add(count, person);
                        Console.WriteLine("{1}", person);
                        count++;
                    }
                    var validInput = int.TryParse(Console.ReadLine(), out int personChoice);
                    if(validInput)
                    {
                        var foundPerson = peopleLookup.TryGetValue(personChoice, out personToReturn);
                    }
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
            }
            return personToReturn;
        }
    }
}
