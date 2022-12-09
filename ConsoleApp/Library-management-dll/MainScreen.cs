using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UserInterface1;
using System.IO;
using MainMenu;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Reflection;

namespace MainMenu
{
    public class MainScreen
    {








        public void ControlFile(string path, string filename)
        {

            System.IO.FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            if (fileStream != null)
            {
                Console.Write("dosya açıldı");
            }

            fileStream.Close();

        }


        public void AddBorrow(int Id, string Name, string ReturnDate, string Date, string path)
        {
            BookFeature book = new BookFeature();


            book.Id = Id;
            book.Name = Name;
            book.ReturnDate = ReturnDate;
            book.Date = Date;


            byte[] bookByte = BookFeature.BookToByteArrayBlockBorrow(book);
            FileOperations.AppendBlock(bookByte, path);

            Console.SetCursorPosition(57, 8);
            Console.Write("**Yazma Başarılı**");

        }
        public void AddBook(int Id, string Title, string Description, string Authors, string Categories, string path)
        {
            BookFeature book1 = new BookFeature();


            book1.Id = Id;
            book1.Title = Title;
            book1.Description = Description;
            book1.Authors = Authors;
            book1.Categories = Categories;








            byte[] bookBytes1 = BookFeature.BookToByteArrayBlock(book1);
            FileOperations.AppendBlock(bookBytes1, path);
            //FileOperations.DeleteBlock();




            Console.Clear();
            GUI.userint(40, 90, 2, 27);
            GUI.userint(40, 90, 2, 27);


            Console.SetCursorPosition(50, 8);
            Console.Write("**Yazma Başarılı**");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Kitap Numarası:" + Id);
            Console.SetCursorPosition(50, 11);
            Console.WriteLine("Kitap İsmi:" + Title);
            Console.SetCursorPosition(50, 12);
            Console.WriteLine("Kitap Tanımı:" + Description);
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Kitap Yazarı:" + Authors);
            Console.SetCursorPosition(50, 14);
            Console.WriteLine("Kitap Kategorisi:" + Categories);

            System.Threading.Thread.Sleep(2000);

        }


        public int IncreaseBook(int amount)
        {
            //int Id, string path
            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, 4, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
            //BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBookCounter(bookWrittenBytes);
            BookFeature book = new BookFeature();

            //int index = 0;
            //byte[] idBytes = new byte[BookFeature.ID_LENGTH];
            //Array.Copy(bookWrittenBytes, index, idBytes, 0, idBytes.Length);
            book.Id = DataOperations.ByteArrayToInteger(bookWrittenBytes);
            //index += BookFeature.ID_LENGTH;
            //Console.WriteLine(book.Id);
            amount = book.Id + amount;
            //Console.WriteLine(book.Id);
            bookWrittenBytes = DataOperations.IntegerToByteArray(amount);
            FileOperations.DeleteBlock(1, 4, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Borrow.dat");
            FileOperations.UpdateBlock(bookWrittenBytes, 1, 4, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Borrow.dat");

            return amount;

  


        }
        public int DecreaseBook(int amount)
        {

            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, 4, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Borrow.dat");
            //BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBookCounter(bookWrittenBytes);
            BookFeature book = new BookFeature();

            //int index = 0;
            //byte[] idBytes = new byte[BookFeature.ID_LENGTH];
            //Array.Copy(bookWrittenBytes, index, idBytes, 0, idBytes.Length);
            book.Id = DataOperations.ByteArrayToInteger(bookWrittenBytes);
            //index += BookFeature.ID_LENGTH;
            if (book.Id == 0) { Console.Write("Kitap sayısı zaten 0"); return amount; }
            amount = book.Id - amount;
            //Console.WriteLine(book.Id);
            bookWrittenBytes = DataOperations.IntegerToByteArray(amount);
            FileOperations.DeleteBlock(1, 4, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Borrow.dat");
            FileOperations.UpdateBlock(bookWrittenBytes, 1, 4, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Borrow.dat");

            return amount;

        }
        public int BookCount()
        {
            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, 4, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Borrow.dat");
            BookFeature book = new BookFeature();

            book.Id = DataOperations.ByteArrayToInteger(bookWrittenBytes);
            Console.WriteLine(book.Id);
            return book.Id;
        }
 
        public void PullBorrow()
        {

            byte[] borrowWrittenBytes = FileOperations.ReadBlock(1, BookFeature.Borrow_Data_Block_Size, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\BookCount.dat");
            BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBorrow(borrowWrittenBytes);

            Console.WriteLine(bookWrittenObject);
        }
        public void PullBook()
        {

           

            byte[] bookWrittenBytes = FileOperations.ReadBlock(1, BookFeature.BOOK_DATA_BLOCK_SIZE, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
            BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
  


        }


      

    }
}
