using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public interface IBookmark
    {
        public Pair<ISimpleBook, int> Bookmark { get; set; }
    }
}
