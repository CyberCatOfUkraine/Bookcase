using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public class UserManagerException:Exception
    {
        public UserManagerException(string method,string message):base($"Метод {method}: {message}")
        {

        }
    }
}
