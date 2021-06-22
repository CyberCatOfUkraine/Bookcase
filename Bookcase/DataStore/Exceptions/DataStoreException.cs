using System;
using System.Runtime.Serialization;

namespace DataStore.Managers
{
    internal class DataStoreException : Exception
    {
        public DataStoreException(string methodName,string message) : base($"{methodName}:{message}")
        {
        }
    }
}