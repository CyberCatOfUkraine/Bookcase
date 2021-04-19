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

        public List<Models.DisplayedBook> GetBooks()
        {
            var books = new List<Models.DisplayedBook>();

            if (_manager.CountOfBooks == 0)
                return books;

            foreach(var book in _manager.GetAll())
            {
                books.Add(new Mapper.BooksMapper().Map(book));
            }
            return books;
        }
    }
}
