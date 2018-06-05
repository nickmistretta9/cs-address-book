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
            //addressBook.AddPerson(new Person("Nick", "Mistretta", "307 Cassa Loop", "Holtsville", "NY", 11742, "6313353056"));
            addressBook.ReadFromFile();
            addressBook.AddPerson(new Person("Nick", "three", "asd", "asd", "NY", 12324, "asdas"));
            //addressBook.ReadFromFile();
            addressBook.RemovePerson();
        }
    }
}
