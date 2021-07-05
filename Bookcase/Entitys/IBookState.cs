using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public interface IBookState
    {
        public enum BookState { Open, Processing, Finish };
    }
}
