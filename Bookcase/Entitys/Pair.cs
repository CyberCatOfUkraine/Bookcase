using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public struct Pair<T,Y>
    {
        public T Value1 { get; set; }
        public Y Value2 { get; set; }
        public Pair(T value1,Y value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public void UpdateValue2(Y value)
        {
            Value2 = value;
        }
    }
}
