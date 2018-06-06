using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var addressBook = new AddressBook();
            addressBook.ReadFromFile();
            addressBook.RemovePerson();
        }
    }
}
