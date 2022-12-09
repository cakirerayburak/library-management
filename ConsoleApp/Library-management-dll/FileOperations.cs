using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MainMenu
{
    public class FileOperations
    {

        public static byte[] ReadBlock(int count, int blocksize, string path)
        {

            byte[] buffer = new byte[blocksize];

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                fileStream.Seek((count - 1) * blocksize, SeekOrigin.Begin);
                fileStream.Read(buffer, 0, buffer.Length);
            }

            return buffer;
        }
        public static bool AppendBlockCounter(byte[] data, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Seek(0, SeekOrigin.End);
                fileStream.Write(data, 0, data.Length);
            }

            return true;
        }
        public static bool AppendBlock(byte[] data, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Seek(0, SeekOrigin.End);
                fileStream.Write(data, 0, data.Length);
            }
            Console.Write("Yazma başarılı");
            return true;
        }




        public static bool UpdateBlock(byte[] data, int count, int blocksize, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Seek((count - 1) * blocksize, SeekOrigin.Begin);
                fileStream.Write(data, 0, data.Length);
            }

            return true;
        }



        public static bool DeleteBlock(int count, int blocksize, string path)
        {
            byte[] data = new byte[blocksize];

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Seek((count - 1) * blocksize, SeekOrigin.Begin);
                fileStream.Write(data, 0, data.Length);
            }

            return true;
        }


        public static bool DeleteBlock2(int blocksize, int offset, string path)
        {
            byte[] data = new byte[blocksize];

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
                fileStream.Write(data, 0, data.Length);
            }

            return true;
        }

        public static bool DeleteFile(string path)
        {
            if (File.Exists(path)) { File.Delete(path); }

            return true;
        }
        /*
        public byte[] ReadBlock(int v1, int bOOK_DATA_BLOCK_SIZE, string v2)
        {
            throw new NotImplementedException();
        }
        */
    }
}
