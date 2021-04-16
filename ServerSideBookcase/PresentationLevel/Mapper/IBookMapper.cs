using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLevel.Mapper
{
    interface IBookMapper
    {
        POCO.Book Map(DataAccessLevel.POCO.Book book);
        DataAccessLevel.POCO.Book Map(POCO.Book book);
    }
}
