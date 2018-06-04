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
            addressBook.AddPerson(new Person("Nick", "Mistretta", "307 Cassa Loop", "Holtsville", "NY", 11742, "6313353056"));
            addressBook.AddPerson(new Person("asjnd", "asd", "307 Cassa Loop", "Holtsville", "NY", 11742, "6313353056"));

            addressBook.ReadFromFile();
        }
    }
}
