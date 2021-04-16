using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLevel.Managers;
namespace PresentationLevel
{
    public class BooksListLoader
    {
        private readonly FileBookManager _manager;

        public BooksListLoader(FileBookManager manager)
        {
            _manager = manager;
        }

        public List<POCO.Book> GetBooks()
        {
            var books =new List<POCO.Book>();

            foreach(var book in _manager.GetAll())
            {
                books.Add(new Mapper.BooksMapper().Map(book));
            }
            return books;
        }
    }
}
