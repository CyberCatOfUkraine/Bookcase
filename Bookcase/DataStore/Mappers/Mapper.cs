using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Mappers
{
    public static class Mapper<T> where T:class
    {
        public static byte[] Map(T value)
        {
           return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value));
        }
        public static T Map(byte[] value)
        {
            if (value.Length==0)
            {
                return null;
            }
            T result = null;
            try
            {
                result =JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value));
            }
            catch (Exception)
            {

                //ignored;
            }
            return result;
        }
    }
}
