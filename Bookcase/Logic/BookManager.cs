using Entitys;
using Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class BookManager
    {
        private List<ISimpleBook> _Books;
        public BookManager()
        {
            _Books = new();
        }
        public BookManager(List<ISimpleBook> books)
        {
            _Books = books;
        }
        public void Save(ISimpleBook book)
        {
            _Books.Add(book);
        }
        public ISimpleBook GetByName(string name)
        {
            return _Books.First(x => x.Name == name);
        }

        public List<ISimpleBook> GetBooks() => _Books;

        public void Remove(ISimpleBook book)
        {
            if (!_Books.Contains(book))
            {
                throw new BookManagerException("Відсутня книга",nameof(Remove));
            }
            _Books.Remove(book);

        }
        public void Update(ISimpleBook book)
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
