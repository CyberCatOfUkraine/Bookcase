using Entitys;
using Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserManager
    {
        List<User> _Users;
        public UserManager()
        {
            _Users = new();
        }
        public bool Login(string name,string password)
        {
            return _Users.First(x => x.Name == name && x.Password == password) != null;
        }
        public void Register(string name, string password)
        {
            _Users.Add(new User() {Name=name,Password=password,Role=Role.User });
        }
        public User GetByName(string name) => _Users.First(x => x.Name == name);
        private int GetUserPositionInList(User user, string methodName)
        {
            int position;
            try
            {
                position = _Users.IndexOf(user);
            }
            catch (Exception e)
            {
                throw new UserManagerException(methodName, e.Message);
            }
            return position;
        }
        public void SetBookMark(User user, Book book, int page)
        {
            int position = GetUserPositionInList(user, nameof(SetBookMark));
            if (_Users.ElementAt(position).Bookmarks == null)
                _Users.ElementAt(position).Bookmarks = new();
            _Users.ElementAt(position).Bookmarks.Add(new Bookmark() { Book = book, Page = page });
        }
        public void RemoveBookMark(User user,Book book)
        {
            int position = GetUserPositionInList(user, nameof(RemoveBookMark));
            if (_Users.ElementAt(position).Bookmarks == null)
                return;
            var bookmark = _Users.ElementAt(position).Bookmarks.First(x => x.Book.Name == book.Name && x.Book.Path == book.Path);
            if (bookmark != null)
                _Users.ElementAt(position).Bookmarks.Remove(bookmark);
            else
                throw new UserManagerException(nameof(RemoveBookMark), $"Закладку \"{book.Name}\" не знайдено серед переліку книг");
        }
        public void AddBook(User user,Book book)
        {
            int position = GetUserPositionInList(user, nameof(AddBook));
            if (_Users.ElementAt(position).BookStates==null)
                    _Users.ElementAt(position).BookStates = new();
            _Users.ElementAt(position).BookStates.Add(book, BookState.Added);


        }
       
        public void RemoveBook(User user,Book book)
        {
            int position = GetUserPositionInList(user, nameof(RemoveBook));
            if (_Users.ElementAt(position).BookStates == null)
                _Users.ElementAt(position).BookStates = new();
            _Users.ElementAt(position).BookStates.Add(book, BookState.Added);

        }
    }
}
