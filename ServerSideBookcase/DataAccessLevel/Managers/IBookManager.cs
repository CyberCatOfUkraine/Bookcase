using DataAccessLevel.POCO;
using System.Collections.Generic;

namespace DataAccessLevel.Managers
{
    interface IBookManager<T> where T:Book
    {
        void Add(T enity);

        void Remove(T entity);

        Book GetByName(string name);
        List<Book> GetAll();
        void Upadate(string name, Book newBook);
        void Dispose();
        int CountOfBooks { get; }
    }
}
