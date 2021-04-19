﻿using DataAccessLevel.DTO;
using DataAccessLevel.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccessLevel.Managers
{
    public class FileBookManager:IBookManager<Book>
    {
        private List<Book> _books;
        private const string BooksListFileName = ".list";
        private string BookDataDirPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Globals.AppName);

        public void InitializeManager()
        {
            if (!Directory.Exists(BookDataDirPath))
            {
                Directory.CreateDirectory(BookDataDirPath);
                File.WriteAllText(Path.Combine(BookDataDirPath, BooksListFileName), string.Empty);
                _books = new List<Book>();
            }
            else
            {
                _books=File.Exists(Path.Combine(BookDataDirPath, BooksListFileName))?GetBooksFromFile():new List<Book>();
            }

        }
        public void Add(Book book)
        {
            _books.Add(book);
            SaveBooksToFile(_books);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetByName(string name)
        {
            var book = _books.First(x => x.Name == name);
            if (book == null)
                throw new BookNotFoundException(book);
            return book;
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
            SaveBooksToFile(_books);
            _books = GetBooksFromFile();
        }

        private void SaveBooksToFile(List<Book> books)
        {
            File.WriteAllText(Path.Combine(BookDataDirPath, BooksListFileName), JsonConvert.SerializeObject(books, Formatting.Indented));

        }
        private List<Book> GetBooksFromFile()
        {

            return JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(Path.Combine(BookDataDirPath, BooksListFileName)));
        }
        public void Dispose()
        {
            _books = null;
            _books = new List<Book>();
            DeleteFile();
            DeleteDirectory();
        }
        private void DeleteDirectory()
        {
            Directory.Delete(BookDataDirPath);
        }
        private void DeleteFile()
        {
            File.Delete(Path.Combine(BookDataDirPath, BooksListFileName));
        }

        public int CountOfBooks
        {
            get
            {
                return _books==null?0:_books.Count;///Якщо книг нема то й відправляється 0
            }
        }

    }
}
