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
                _people.Add(ParsePersonInfo(person));
            }
        }

        public bool AddPerson()
        {
            Console.Write("Enter the new person's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter the new person's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter the new person's street address: ");
            string streetAddress = Console.ReadLine();
            Console.Write("Enter the new person's city: ");
            string city = Console.ReadLine();
            Console.Write("Enter the new person's state: ");
            string state = Console.ReadLine();
            Console.Write("Enter the new person's zip code: ");
            string zip = Console.ReadLine();
            Console.Write("Enter the new person's phone number: ");
            string phoneNumber = Console.ReadLine();
            Person personToAdd = new Person(firstName, lastName, streetAddress, city, state, zip, phoneNumber);
            foreach (var person in _people)
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
            if (personToRemove != null)
            {
                _people.Remove(personToRemove);
            }
        }

        public void UpdatePerson()
        {
            Person personToUpdate = FindPerson();
            UpdatePersonInfo(personToUpdate);
        }

        private Person FindPerson()
        {
            Person personToReturn = new Person();
            IEnumerable<Person> people;
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
                    people = _people.Where(p => p.FirstName == firstName);
                    if (people.Count() == 0)
                    {
                        Console.WriteLine("Sorry, no one with the first name {0} was found. Try a different search.", firstName);
                    }
                    else
                    {
                        Console.WriteLine("{0} person(s) found with the first name {1}. Which one would you like to look up?", people.Count(), firstName);
                        personToReturn = SearchAddressBook(people);
                        Console.WriteLine("{0} {1} has been found! What would you like to do now?", personToReturn.FirstName, personToReturn.LastName);
                    }
                    break;
                case "2":
                    Console.Write("Enter the last name to search by: ");
                    string lastName = Console.ReadLine();
                    people = _people.Where(p => p.LastName == lastName);
                    if (people.Count() == 0)
                    {
                        Console.WriteLine("Sorry, no one with the last name {0} was found. Try a different search.", lastName);
                    } else
                    {
                        Console.WriteLine("{0} person(s) found with the last name {1}. Which one would you like to look up?", people.Count(), lastName);
                        personToReturn = SearchAddressBook(people);
                        Console.WriteLine("{0} {1} has been found! What would you like to do now?", personToReturn.FirstName, personToReturn.LastName);
                    }
                    break;
                case "3":
                    Console.Write("Enter the address to search by: ");
                    string address = Console.ReadLine();
                    people = _people.Where(p => p.Address == address);
                    if (people.Count() == 0)
                    {
                        Console.WriteLine("Sorry, no one with the address {0} was found. Try a different search.", address);
                    } else
                    {
                        Console.WriteLine("{0} person(s) found with the address {1}. Which one would you like to look up?", people.Count(), address);
                        personToReturn = SearchAddressBook(people);
                        Console.WriteLine("{0} {1} has been found! What would you like to do now?", personToReturn.FirstName, personToReturn.LastName);
                    }
                    break;
                case "4":
                    Console.Write("Enter the phone number to search by: ");
                    string phoneNumber = Console.ReadLine();
                    people = _people.Where(p => p.PhoneNumber == phoneNumber);
                    if (people.Count() == 0)
                    {
                        Console.WriteLine("Sorry, no one with the phone number {0} was found. Try a different search.", phoneNumber);
                    } else
                    {
                        Console.WriteLine("{0} person(s) found with the phone number {1}. Which one would you like to look up?", people.Count(), phoneNumber);
                        personToReturn = SearchAddressBook(people);
                        Console.WriteLine("{0} {1} has been found! What would you like to do now?", personToReturn.FirstName, personToReturn.LastName);
                    }
                    break;
            }
            return personToReturn;
        }
        private Person ParsePersonInfo(string person)
        {
            var personInfo = person.Split('|');
            var personName = personInfo[0].Split(',');
            string firstName = personName[1].Trim();
            string lastName = personName[0].Trim();
            var fullAddress = personInfo[1].Split(',');
            string streetName = fullAddress[0].Trim();
            string city = fullAddress[1].Trim();
            var stateZip = fullAddress[2].Split(' ');
            string state = stateZip[0].Trim();
            string zip = stateZip[1].Trim();
            string phoneNumber = personInfo[2].Trim();
            return new Person(firstName, lastName, streetName, city, state, zip, phoneNumber);
        }

        private Person SearchAddressBook(IEnumerable<Person> people)
        {
            var personToReturn = new Person();
            Dictionary<int, Person> peopleLookup = new Dictionary<int, Person>();
            bool personHasBeenFound = false;
            var count = 0;
            foreach (var person in people)
            {
                peopleLookup.Add(count, person);
                Console.WriteLine(person);
                count++;
            }
            while (!personHasBeenFound)
            {
                try
                {
                    var validInput = int.TryParse(Console.ReadLine(), out int personChoice);
                    if (validInput)
                    {
                        var foundPerson = peopleLookup.TryGetValue(personChoice - 1, out personToReturn);
                        if (foundPerson)
                        {
                            personHasBeenFound = true;
                        }
                        else
                        {
                            Console.WriteLine("Input not recognized. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Could not recognize input, please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input: " + ex.Message);
                }
            }
            return personToReturn;
        }

        private bool UpdatePersonInfo(Person person)
        {
            return true;
        }
    }
}
