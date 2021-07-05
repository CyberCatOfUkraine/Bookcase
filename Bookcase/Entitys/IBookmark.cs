using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public interface IBookmark
    {
        public Tuple<ISimpleBook, int> Bookmark { get; set; }
    }
}
