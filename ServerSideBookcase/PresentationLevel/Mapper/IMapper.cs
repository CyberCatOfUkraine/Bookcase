using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLevel.Mapper
{
    interface IMapper<S,D> where S:class where D:class
    {
        S Map(D destinationObject);
        D Map(S sourceObject);
    }
}
