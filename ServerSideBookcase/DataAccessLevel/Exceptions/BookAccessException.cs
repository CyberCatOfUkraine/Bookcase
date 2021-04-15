using DataAccessLevel.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.Exceptions
{
    public class BookAccessException : Exception
    {
        public BookAccessException()
        {
        }
        public BookAccessException(string message) : base(message)
        {
            
        }
        public BookAccessException(string message,Book book):this(message+$"{Environment.NewLine} Книга з назвою: {book.Name},та шляхом {book.PathToBook} не є доступною !")
        {
        }
    }
}
