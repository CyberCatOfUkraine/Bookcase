using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class User
    {
        public string         Name      { get; set; }
        public string         Password  { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public Role           Role      { get; set; }
    }
}
