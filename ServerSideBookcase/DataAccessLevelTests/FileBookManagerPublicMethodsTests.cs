using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLevel.DTO;
using DataAccessLevel.Managers;
using System;

namespace DataAccessLevelTests
{
    [TestClass]
    public class FileBookManagerPublicMethodsTests
    {
        [TestMethod]
        public void AddAndRemoveTestMethod()
        {
            try
            {
                var manager = new FileBookManager();
                manager.InitializeManager();
                var testBook = new Book { Name = "Book", Author = "Author", Description = "Description", PathToBook = "PathToBook", PathToTitleImage = "PathToTitleImage" };
                manager.Add(testBook);
                manager.Remove(testBook);
                manager.Dispose();
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [TestMethod]
        public void GetByNameTestMethod()
        {
            var manager = new FileBookManager();
            manager.InitializeManager();
            string name = "Book", description = "Description";
            var testBook = new Book { Name = name, Author = "Author",Description=description, PathToBook = "PathToBook", PathToTitleImage = "PathToTitleImage" };
            manager.Add(testBook);

            var condition= description==manager.GetByName(name).Description;
            manager.Dispose();
            Assert.IsTrue(condition);
        }
        [TestMethod]
        public void UpdateTestMethod()
        {
            var manager = new FileBookManager();
            manager.InitializeManager();
            var testBook1 = new Book { Name = "Book", Author = "Author", Description = "Description", PathToBook = "PathToBook", PathToTitleImage = "PathToTitleImage" };
            var testBook2 = new Book { Name=testBook1.Name,Author=testBook1.Author,Description=testBook1.Description, PathToBook=testBook1.PathToBook,PathToTitleImage=testBook1.PathToTitleImage };

            testBook2.Author = "◊Û‚‡‡Í";

            manager.Add(testBook1);
            manager.Upadate(testBook1.Name, testBook2);
            var condition = (manager.GetByName(testBook1.Name) == testBook2);
            manager.Dispose();
            Assert.IsFalse(condition);
        }
        [TestMethod]
        public void GetCountOfBooksTestMethod()
        {
            var manager = new FileBookManager();
            manager.InitializeManager();
            string name = "Book", description = "Description";
            var testBook = new Book { Name = name, Author = "Author", Description = description, PathToBook = "PathToBook", PathToTitleImage = "PathToTitleImage" };
            manager.Add(testBook);

            int countOfBooks = manager.CountOfBooks;
            manager.Dispose();
            Assert.AreEqual<int>(countOfBooks, 1);
        }
    }
}
