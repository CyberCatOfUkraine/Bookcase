using DataAccessLevel.Exceptions;
using DataAccessLevel.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace DataAccessLevel.Repository
{
    public class BookFileRepository : IBookRepository<Book>
    {
        private List<Book> _books;
        private const string BooksListFileName= ".list";
        private string BookDataDirPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Globals.AppName);

        public void InitializeRepository()
        {
            if (!Directory.Exists(BookDataDirPath))
            {
                Directory.CreateDirectory(BookDataDirPath);
                _books = new List<Book>();
            }
            else
                _books = GetBooksFromFile();

        }
        public void Add(Book book)
        {
            _books.Add(book);
            SaveToFile(_books);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetByName(string name)
        {
            if (GetByName(name) == null)
                throw new BookNotFoundException(GetByName(name));

            return _books.First(x => x.Name == name);
        }

        public void Remove(Book entity)
        {
            _books.Remove(entity);
         
            UpdateBooksList();
        }

        public void Upadate(string name, Book newBook)
        {
            if (GetByName(name) == null)
                throw new BookNotFoundException(GetByName(name));

            int bookPosition = _books.IndexOf(GetByName(name));

            #region Оновлення характеристик книги
            _books[bookPosition].Author = newBook.Author;
            _books[bookPosition].Description = newBook.Description;
            _books[bookPosition].PathToBook = newBook.PathToBook;
            _books[bookPosition].PathToTitleImage = newBook.PathToTitleImage;
            #endregion

            UpdateBooksList();
        }
        private void UpdateBooksList()
        {
            SaveToFile(_books);
            _books = GetBooksFromFile();
        }

        private void SaveToFile(List<Book> books)
        {
            File.WriteAllText(Path.Combine(BookDataDirPath, BooksListFileName), JsonConvert.SerializeObject(books,Formatting.Indented));

        }
        private List<Book> GetBooksFromFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(Path.Combine(BookDataDirPath, BooksListFileName)));
        }
        public void Dispose()
        {
            _books=null;
            _books = new List<Book>();
            DisposeFile();
        }
        private void DisposeFile()
        {
            File.WriteAllText(Path.Combine(BookDataDirPath,BooksListFileName), string.Empty);
        }

        public int CountOfBooks
        {
            get
            {
                return _books.Count;
            }
        }
    }
}
