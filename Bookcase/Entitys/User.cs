using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class IUser
    {
        public string Name { get; set; }
        public List<IBookmark> Bookmarks { get; set; }
        public List<ISimpleBook> Books { get; set; }
    }
}
