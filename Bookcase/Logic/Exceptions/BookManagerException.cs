using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public class BookManagerException:Exception
    {
        public BookManagerException(string message,string methodName):base($"Метод {methodName}: {message}")
        {

        }
    }
}
