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

        public void AddPerson()
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
                if(person.Equals(personToAdd))
                {
                    Console.WriteLine("Person already exists in your Address Book");
                    return;
                }
            }

            _people.Add(personToAdd);
        }

        public void WriteToFile()
        {
            foreach(var person in _people)
                System.IO.File.AppendAllText(fileURL, person.ToString() + Environment.NewLine);
        }

        public void RemovePerson()
        {
            var personToRemove = FindPerson();
            if (personToRemove != null)
            {
                _people.Remove(personToRemove);
            }
        }

        public void ReadFullBook()
        {
            foreach(var person in _people)
                Console.WriteLine(person);
        }

        public void UpdatePerson()
        {
            Person personToUpdate = FindPerson();
            var successful = UpdatePersonInfo(personToUpdate);
            if(successful)
                Console.WriteLine("Successfully updated {0} {1}", personToUpdate.FirstName, personToUpdate.LastName);
            else
                Console.WriteLine("Something went wrong updating {0} {1}. Please try again", personToUpdate.FirstName, personToUpdate.LastName);
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
            var done = false;
            while(!done)
            {
                List<string> options = new List<string>()
                {
                    "1) Update first name",
                    "2) Update last name",
                    "3) Update address",
                    "4) Update phone number"
                };
                Console.WriteLine("What would you like to update?");
                foreach(var option in options)
                    Console.WriteLine(option);
                string input = Console.ReadLine();
                switch(input)
                {
                    default:
                    case "1":
                        Console.Write("Enter the new first name: ");
                        string firstName = Console.ReadLine();
                        person.FirstName = firstName;
                        done = ToContinue("First name");
                        break;
                    case "2":
                        Console.Write("Enter the new last name: ");
                        string lastName = Console.ReadLine();
                        person.LastName = lastName;
                        Console.Write("Last name updated. Would you like to change any more information? (Y/N) ");
                        done = ToContinue("Last name");
                        break;
                    case "3":
                        Console.Write("Enter the new address: ");
                        string address = Console.ReadLine();
                        person.Address = address;
                        done = ToContinue("Address");
                        break;
                    case "4":
                        Console.Write("Enter the new phone number: ");
                        string phoneNumber = Console.ReadLine();
                        person.PhoneNumber = phoneNumber;
                        done = ToContinue("Phone number");
                        break;
                }
            }
            return true;
        }
        private bool ToContinue(string updateParameter)
        {
            bool done = false;
            Console.Write("{0} updated. Would you like to change any more information? (Y/N) ", updateParameter);
            string toContinue = Console.ReadLine().ToUpper();
            if (toContinue == "N")
                done = true;
            return done;
        }
    }
}
