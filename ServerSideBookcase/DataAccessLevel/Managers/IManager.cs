using DataAccessLevel.POCO;
using System.Collections.Generic;

namespace DataAccessLevel.Managers
{
    interface IManager
    {
        void Add(Book book);

        void Remove(Book book);

        void GetByName(string name);
        List<Book> GetAll();
        void Upadate(string name, Book newBook);
    }
}
