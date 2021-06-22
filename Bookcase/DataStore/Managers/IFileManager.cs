using Entitys;
using System.Collections.Generic;

namespace DataStore.Managers
{
    public interface IFileManager
    {
        void Create(string path);
        void Write(string path,byte[] content);
        void Append(string path,byte[] content);
        void Empty(string path);
        byte[] Read(string path);
        void Delete(string path);
        bool IsExist(string path);
    }
}
