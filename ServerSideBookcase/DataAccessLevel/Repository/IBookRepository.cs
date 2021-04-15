using DataAccessLevel.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.Repository
{
    interface IBookRepository<T> where T :Book
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
