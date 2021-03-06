﻿namespace AddressBook
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }       
        public string PhoneNumber { get; set; }
        public int ID { get; set; }
        static int _count = 1;

        public Person(string firstName, string lastName, string streetAddress, string city, string state, string zip, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = streetAddress + ", " + city + ", " + state + " " + zip;
            PhoneNumber = phoneNumber;
            ID = _count;
            _count++;
        }
        public Person() {}

        public override string ToString()
        {
            return LastName + ", " + FirstName + " | " + Address + " | " + PhoneNumber;
        }
    }
}
