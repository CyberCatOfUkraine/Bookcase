using System;

namespace DataAccessLevel.POCO
{
    [Serializable]
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PathToBook { get; set; }
        public string PathToTitleImage { get; set; }

    }
}
