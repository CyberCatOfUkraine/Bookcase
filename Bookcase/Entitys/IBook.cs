using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public interface IBook:ISimpleBook
    {
        Tuple<Type,object> Document { get; set; }
    }
}
