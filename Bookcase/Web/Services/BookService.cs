using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public class BookService
    {
        private static BookManager _bookManager = new();
        public IEnumerable<string> GetBookNames()
        {
            var names = new List<string>();
            foreach (var book in _bookManager.GetBooks())
            {
                names.Add(book.Name);
            }
            return names;
        }
    }
}
