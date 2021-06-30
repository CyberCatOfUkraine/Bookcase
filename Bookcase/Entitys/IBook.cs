using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public interface IBook:SimpleBook
    {
        Tuple<Type,object> Document { get; set; }
    }
}
