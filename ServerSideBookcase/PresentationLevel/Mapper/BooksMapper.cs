

using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PresentationLevel.Mapper
{
    public class BooksMapper : IBookMapper
    {
        public POCO.Book Map(DataAccessLevel.POCO.Book book)
        {
            var img = new BitmapImage(new Uri(book.PathToTitleImage));
            return new POCO.Book { Name = book.Name, Author = book.Author, Description = book.Description, PathToBook = book.PathToBook, TitleImage = img };
        }

        public DataAccessLevel.POCO.Book Map(POCO.Book book)
        {
            return new DataAccessLevel.POCO.Book {Name=book.Name, Author=book.Author,Description=book.Description,PathToBook=book.PathToBook,PathToTitleImage=book.TitleImage.UriSource.AbsolutePath };
        }
    }
}
