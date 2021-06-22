using Entitys;
using Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class BookManager
    {
        private List<SimpleBook> _Books;
        public BookManager()
        {
            _Books = new();
        }
        public BookManager(List<SimpleBook> books)
        {
            _Books = books;
        }
        public void Save(SimpleBook book)
        {
            _Books.Add(book);
        }
        public SimpleBook GetByName(string name)
        {
            return _Books.First(x => x.Name == name);
        }

        public List<SimpleBook> GetBooks() => _Books;

        public void Remove(SimpleBook book)
        {
            if (!_Books.Contains(book))
            {
                throw new BookManagerException("Відсутня книга",nameof(Remove));
            }
            _Books.Remove(book);

        }
        public void Update(SimpleBook book)
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
