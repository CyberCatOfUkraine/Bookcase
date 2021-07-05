using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserManager
    {
        private List<IUser> _users;
        public UserManager()
        {
            _users = new();
        }
        public void Add(IUser user)
        {
            _users.Add(user);
        }
        public IUser GetByName(string name) => _users.First(x => x.Name==name);
        public List<IUser> GetUsers() => _users;
        public void Update(string name, List<IBookmark> bookmarks, List<Pair<ISimpleBook,BookState>> books)
        {
            _users.First(x => x.Name == name).Bookmarks=bookmarks;
            _users.First(x => x.Name == name).Books=books;
        }
        public void Remove(IUser user)
        {
            _users.Remove(user);
        }
        public void AddBookmark(string name,IBookmark bookmark)
        {
            _users.First(x => x.Name == name).Bookmarks.Add(bookmark);
        }
        public void RemoveBookmark(string name, IBookmark bookmark)
        {
            _users.First(x => x.Name == name).Bookmarks.Remove(bookmark);
        }
        public void AddBook(string name,ISimpleBook book)
        {
            _users.First(x => x.Name == name).Books.Add(new Pair<ISimpleBook, BookState>(book,BookState.Open));
        }
        public void RemoveBook(string name,ISimpleBook book)
        {
            var selectedBook = _users.First(x => x.Name == name).Books.First(x => x.Value1 == book);
            _users.First(x => x.Name == name).Books.Remove(selectedBook);
        }
        public void ChangeBookStateByName(string name,ISimpleBook book,BookState state)
        {
            _users.First(x => x.Name == name).Books.First(x => x.Value1== book).UpdateValue2(state);
        }
    }
}
