using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.Exceptions
{
    public class BooksListRetrieveError : Exception
    {
        public BooksListRetrieveError(string message):base("Не вдалося отримати список книг: "+Environment.NewLine+message)
        {

        }
        public BooksListRetrieveError():this("Не вдалося отримати список книг")
        {
            
        }
    }
}
