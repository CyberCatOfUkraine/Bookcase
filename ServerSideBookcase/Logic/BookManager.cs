using Entitys;
using Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class BookManager
    {
        private List<Book> _Books;
        public BookManager()
        {
            _Books = new List<Book>();
        }
        public void Save(Book book)
        {
            _Books.Add(book);
        }
        public Book GetByName(string name)
        {
            return _Books.First(x => x.Name == name);
        }

        public List<Book> GetBooks() => _Books;

        public void Remove(Book book)
        {
            if (!_Books.Contains(book))
            {
                throw new BookManagerException("Відсутня книга",nameof(Remove));
            }
            _Books.Remove(book);

        }
        public void Update(Book book)
        {
            if (GetByName(book.Name)==null)
            {
                throw new BookManagerException("Відсутня книга", nameof(Update));
            }
            var oldBook = GetByName(book.Name);
            int position = _Books.IndexOf(oldBook);
            _Books.Remove(oldBook);
            _Books.Insert(position, book);
        }
    }
}
