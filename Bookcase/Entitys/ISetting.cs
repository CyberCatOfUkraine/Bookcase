using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsSaver
{
    public interface ISetting
    {
        public string BooksPath { get; set; }
        public List<ISimpleBook> Books {get;set;}
        public List<IUser> Users { get; set; }
    }
}
