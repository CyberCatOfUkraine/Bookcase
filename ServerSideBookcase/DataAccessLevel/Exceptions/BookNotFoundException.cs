using DataAccessLevel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.Exceptions
{
    public class BookNotFoundException:Exception
    {
        public BookNotFoundException()
        {

        }
        public BookNotFoundException(string message):base(message)
        {

        }
        public BookNotFoundException(Book book) :this($"Книгу під назвою \"{book.Name}\" не знайдено!")
        {

        }
    }
}
