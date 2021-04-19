

using System;
using DataAccessLevel;
using System.Windows.Media.Imaging;
using PresentationLevel.Models;
using DataAccessLevel.DTO;

namespace PresentationLevel.Mapper
{
    public class BooksMapper : IMapper<Book, DisplayedBook>
    {

        public DisplayedBook Map(Book sourceObject)
        {
            var img = new BitmapImage(new Uri(sourceObject.PathToTitleImage));
            return new DisplayedBook { Name = sourceObject.Name, Author = sourceObject.Author, Description = sourceObject.Description, PathToBook = sourceObject.PathToBook, TitleImage = img };
        }

        public Book Map(DisplayedBook destinationObject)
        {
            return new Book { Name = destinationObject.Name, Author = destinationObject.Author, Description = destinationObject.Description, PathToBook = destinationObject.PathToBook, PathToTitleImage = destinationObject.TitleImage.UriSource.AbsolutePath };
        }
    }
}
