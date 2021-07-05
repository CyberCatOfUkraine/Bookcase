using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public interface IUser
    {
        public string Name { get; set; }
        public List<IBookmark> Bookmarks { get; set; }
        public List<Pair<ISimpleBook,BookState>> Books { get; set; }
    }
}
