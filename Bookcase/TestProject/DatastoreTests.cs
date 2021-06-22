using DataStore.Managers;
using System;
using System.Text;
using Xunit;

namespace TestProject
{
    public class DatastoreTests
    {

        [Fact]
        public void CreateRemoveExistTest()
        {
            string path = "jaba1";
            IFileManager fileManager = new FileManager();
            fileManager.Create(path);
            bool fileIsCreated = fileManager.IsExist(path);
            fileManager.Delete(path);
            bool fileIsDeleted = !fileManager.IsExist(path);


            Assert.True(fileIsCreated&&fileIsDeleted);;

        }
        [Fact]
        public void CreateWriteReadEmptyTest()
        {
            string path = "jaba1";
            IFileManager fileManager = new FileManager();
            fileManager.Create(path);
            fileManager.Write(path, Encoding.UTF8.GetBytes(path));
            var data = Encoding.UTF8.GetString(fileManager.Read(path));
            fileManager.Empty(path);
            var fileIsEmpty=Encoding.UTF8.GetString(fileManager.Read(path));
            Assert.True(data==path&&fileIsEmpty.Length == 0);
            fileManager.Delete(path);
        }
        [Fact]
        public void CreateWriteAppendReadTest()
        {
            string path = "jaba1";
            IFileManager fileManager = new FileManager();
            fileManager.Create(path);
            fileManager.Write(path, Encoding.UTF8.GetBytes(path));
            fileManager.Append(path, Encoding.UTF8.GetBytes(path));
            var data = Encoding.UTF8.GetString(fileManager.Read(path));

            Assert.True(data==path+path);
            fileManager.Delete(path);
        }
       

    }
}
