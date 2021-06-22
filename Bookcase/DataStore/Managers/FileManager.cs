using Entitys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace DataStore.Managers
{
    public class FileManager:IFileManager
    {
        static List<string> _locker = new();//Використовується як список зайнятих файлів _locker 
        private static readonly int CHUNK_SIZE = 1024;

        
        public void Append(string path, byte[] content)
        {
            lock (_locker)
            {
                while (_locker.Contains(path))
                {

                }
                _locker.Add(path);
                Thread thread = new Thread(() =>
                {
                    using var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
                    using var writer = new BinaryWriter(fileStream);

                    var bytesLeft = content.Length;
                    var bytesWritten = 0;
                    while (bytesLeft > 0)
                    {
                        var chunkSize = Math.Min(64, bytesLeft);
                        writer.Write(content, bytesWritten, chunkSize);
                        bytesWritten += chunkSize;
                        bytesLeft -= chunkSize;
                    }

                    writer.Close();
                    fileStream.Close();
                    fileStream.Dispose();
                });
                thread.Start();
                while (thread.IsAlive)
                {

                }
                _locker.Remove(path);

            }
        }

        public void Create(string path)
        {
            lock (_locker)
            {
                while (_locker.Contains(path))
                {

                }
                _locker.Add(path);
                Thread thread = new Thread(() =>
                {
                    File.Create(path).Close();
                });
                thread.Start();
                while (thread.IsAlive)
                {

                }
                _locker.Remove(path);

            }
        }

        public void Delete(string path)
        {
            lock (_locker)
            {
                while (_locker.Contains(path))
                {

                }
                _locker.Add(path);
                Thread thread = new Thread(() =>
                {
                    File.Delete(path);
                });
                thread.Start();
                while (thread.IsAlive)
                {

                }
                _locker.Remove(path);

            }
        }

        public byte[] Read(string path)
        {
             lock (_locker)
            {
                while (_locker.Contains(path))
                {

                }
                _locker.Add(path);

                List<byte> byteList = new();
                Thread thread = new Thread(() =>
                {
                    using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read,FileShare.None);
                    using var binaryReader = new BinaryReader(fileStream);

                    if (!fileStream.CanRead)
                        throw new DataStoreException(nameof(Read),"Файл неможливо зчитати");
                    while (byteList.Count < fileStream.Length)
                    {
                        byteList.Add(binaryReader.ReadByte());
                    }
                    binaryReader.Close();
                    fileStream.Close();
                    fileStream.Dispose();
                });
                thread.Start();
                while (thread.IsAlive)
                {

                }
                _locker.Remove(path);
                
                return byteList.ToArray();

            }
        }

        public void Empty(string path)
        {
            lock (_locker)
            {
                while (_locker.Contains(path))
                {

                }
                _locker.Add(path);
                Thread thread = new Thread(() =>
                {
                    File.WriteAllText(path, string.Empty);
                });
                thread.Start();
                while (thread.IsAlive)
                {

                }
                _locker.Remove(path);

            }
        }

        public void Write(string path, byte[] content)
        {
            lock (_locker)
            {
                while (_locker.Contains(path))
                {

                }
                _locker.Add(path);
                Thread thread = new Thread(() =>
                {

                    using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None);
                    using var writer = new BinaryWriter(fileStream);

                    var bytesLeft = content.Length;
                    var bytesWritten = 0;
                    while (bytesLeft > 0)
                    {
                        var chunkSize = Math.Min(64, bytesLeft);
                        writer.Write(content, bytesWritten, chunkSize);
                        bytesWritten += chunkSize;
                        bytesLeft -= chunkSize;
                    }
                    writer.Close();
                    fileStream.Close();
                    fileStream.Dispose();
                });
                thread.Start();
                while (thread.IsAlive)
                {

                }
                _locker.Remove(path);

            }
        }

        public bool IsExist(string path) => File.Exists(path);
    }
}
