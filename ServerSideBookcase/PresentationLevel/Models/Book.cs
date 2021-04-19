using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PresentationLevel.Models
{
    public class DisplayedBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PathToBook { get; set; }
        public BitmapImage TitleImage { get; set; }
    }
}
