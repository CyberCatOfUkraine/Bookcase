using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Bookmark
    {
        private readonly SimpleBook _book;
        private readonly int _page;
        public Bookmark(SimpleBook book,int page)
        {
            _book = book;
            _page = page;
        }
        public Tuple<SimpleBook, int> GetBookmark => new(_book, _page);

    }
}
