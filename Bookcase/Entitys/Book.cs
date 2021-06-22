using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Book:SimpleBook
    {
        Tuple<Type,object> Document { get; set; }
    }
}
