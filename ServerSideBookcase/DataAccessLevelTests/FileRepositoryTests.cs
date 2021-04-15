using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLevel.Repository;
using DataAccessLevel.POCO;

namespace DataAccessLevelTests
{
    [TestClass]
    public class FileRepositoryTests
    {
        [TestMethod]
        public void AddAndRemoveTestMethod()
        {
            var repository = new BookFileRepository();
            repository.InitializeRepository();
            var testBook = new Book{Name="Book", Author= "Author", Description= "Description", PathToBook= "PathToBook", PathToTitleImage= "PathToTitleImage" };

            repository.Add(testBook);
            repository.Remove(testBook);
            Assert.IsTrue(repository.CountOfBooks == 0);    
        }
    }
}
