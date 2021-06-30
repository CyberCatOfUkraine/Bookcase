using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class IBookmark
    {
        private readonly ISimpleBook _book;
        private readonly int _page;
        public IBookmark(ISimpleBook book,int page)
        {
            _book = book;
            _page = page;
        }
        public Tuple<ISimpleBook, int> GetBookmark => new(_book, _page);

    }
}
