using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    public class BookFeature
    {

        #region Book Constants
        public const int ID_LENGTH = 4;

        public const int TITLE_MAX_LENGTH = 100;

        public const int DESCRIPTION_MAX_LENGTH = 100;


        public const int AUTHORS_NAME_MAX_LENGTH = 100;


        public const int CATEGORY_NAME_MAX_LENGTH = 100;

        public const int BOOK_DATA_BLOCK_SIZE = ID_LENGTH + DESCRIPTION_MAX_LENGTH + AUTHORS_NAME_MAX_LENGTH + TITLE_MAX_LENGTH + CATEGORY_NAME_MAX_LENGTH;

        #endregion

        #region
        public const int Name_Lenght = 30;

        public const int Return_Date_Lenght = 20;

        public const int Date_Lenght = 30;

        public const int Borrow_Data_Block_Size = Name_Lenght + Return_Date_Lenght + Date_Lenght + ID_LENGTH;

        #endregion

        //TITLE_MAX_LENGTH +
        #region Private Fields
        private int _id;
        private string _title;
        private string _description;
        private string _authors;
        private string _categories;

        #endregion

        #region
        private string _name;
        private string _return_date;
        private string _date;
        #endregion




        #region Public Properties
        public int Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Authors { get { return _authors; } set { _authors = value; } }
        public string Categories { get { return _categories; } set { _categories = value; } }
        #endregion

        #region
        public string Name { get { return _name; } set { _name = value; } }
        public string ReturnDate { get { return _return_date; } set { _return_date = value; } }
        public string Date { get { return _date; } set { _date = value; } }

        #endregion

        #region Constructors

  
        #endregion
        #region Utility Methods

        public static byte[] BookToByteArrayBlockBorrow(BookFeature book)
        {

            int index = 0;

            byte[] dataBuffer = new byte[Borrow_Data_Block_Size];

            #region copy book id
            byte[] idBytes = DataOperations.IntegerToByteArray(book.Id);
            Array.Copy(idBytes, 0, dataBuffer, index, idBytes.Length);
            index += BookFeature.ID_LENGTH;
            #endregion

            #region copy persons name

            byte[] nameBytes = DataOperations.StringToByteArray(book.Name);
            Array.Copy(nameBytes, 0, dataBuffer, index, nameBytes.Length);
            index += BookFeature.Name_Lenght;
            #endregion

            #region copy return date

            byte[] returnDateBytes = DataOperations.StringToByteArray(book.ReturnDate);
            Array.Copy(returnDateBytes, 0, dataBuffer, index, returnDateBytes.Length);
            index += BookFeature.Return_Date_Lenght;
            #endregion

            #region copy date

            byte[] DateBytes = DataOperations.StringToByteArray(book.Date);
            Array.Copy(DateBytes, 0, dataBuffer, index, DateBytes.Length);
            index += BookFeature.Date_Lenght;
            #endregion

            if (index != dataBuffer.Length)
            {

                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;

        }

        public static BookFeature ByteArrayBlockToBorrow(byte[] byteArray)
        {
            BookFeature book = new BookFeature();

            if (byteArray.Length != Borrow_Data_Block_Size)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }


            int index = 0;

            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = new byte[BookFeature.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            book.Id = DataOperations.ByteArrayToInteger(idBytes);
            index += BookFeature.ID_LENGTH;
            #endregion

            #region copy book name
            byte[] nameBytes = new byte[BookFeature.Name_Lenght];
            Array.Copy(byteArray, index, nameBytes, 0, nameBytes.Length);
            book.Name = DataOperations.ByteArrayToString(nameBytes);
            index += BookFeature.Name_Lenght;
            #endregion

            #region copy book return date
            byte[] returnDateBytes = new byte[BookFeature.Return_Date_Lenght];
            Array.Copy(byteArray, index, returnDateBytes, 0, returnDateBytes.Length);
            book.ReturnDate = DataOperations.ByteArrayToString(returnDateBytes);
            index += BookFeature.Return_Date_Lenght;
            #endregion

            #region copy date
            byte[] dateBytes = new byte[BookFeature.Date_Lenght];
            Array.Copy(byteArray, index, dateBytes, 0, dateBytes.Length);
            book.Date = DataOperations.ByteArrayToString(dateBytes);
            index += BookFeature.Date_Lenght;
            #endregion


            if (index != byteArray.Length)
            {

                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (book.Id == 0)
            {
                return null;
            }
            else
            {
                return book;
            }

        }
        public static byte[] BookToByteArrayBlock(BookFeature book)
        {
            int index = 0;

            byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = DataOperations.IntegerToByteArray(book.Id);
            Array.Copy(idBytes, 0, dataBuffer, index, idBytes.Length);
            index += BookFeature.ID_LENGTH;
            #endregion


            #region copy book title

            byte[] titleBytes = DataOperations.StringToByteArray(book.Title);
            Array.Copy(titleBytes, 0, dataBuffer, index, titleBytes.Length);
            index += BookFeature.TITLE_MAX_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = DataOperations.StringToByteArray(book.Description);
            Array.Copy(descBytes, 0, dataBuffer, index, descBytes.Length);
            index += BookFeature.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book authors
            byte[] authorBytes = DataOperations.StringToByteArray(book.Authors);
            Array.Copy(authorBytes, 0, dataBuffer, index, authorBytes.Length);
            index += BookFeature.AUTHORS_NAME_MAX_LENGTH;
            #endregion


            #region copy book categories
            byte[] categoryBytes = DataOperations.StringToByteArray(book.Categories);
            Array.Copy(categoryBytes, 0, dataBuffer, index, categoryBytes.Length);
            index += BookFeature.CATEGORY_NAME_MAX_LENGTH;
            #endregion



            if (index != dataBuffer.Length)
            {

                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }
        public static BookFeature ByteArrayBlockToBookCounter(byte[] byteArray)
        {

            BookFeature book = new BookFeature();

            if (byteArray.Length != ID_LENGTH)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }


            int index = 0;
            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = new byte[BookFeature.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            book.Id = DataOperations.ByteArrayToInteger(idBytes);
            index += BookFeature.ID_LENGTH;
            //Console.WriteLine(book.Id);
            book.Id = book.Id + 1;
            //Console.WriteLine(book.Id);
            idBytes = DataOperations.IntegerToByteArray(book.Id);
            FileOperations.DeleteBlock(1, 5, "C:\\Users\\samet\\OneDrive\\Masaüstü\\ce103-hw-erayy-vurak-cakirr\\ConsoleApp\\Borrow.dat");
            FileOperations.AppendBlockCounter(idBytes, "C:\\Users\\samet\\OneDrive\\Masaüstü\\ce103-hw-erayy-vurak-cakirr\\ConsoleApp\\Borrow.dat");

            Console.ReadKey();

            #endregion


            return book;
        }
        public static BookFeature ByteArrayBlockToBook(byte[] byteArray)
        {

            BookFeature book = new BookFeature();

            if (byteArray.Length != BOOK_DATA_BLOCK_SIZE)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = new byte[BookFeature.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            book.Id = DataOperations.ByteArrayToInteger(idBytes);

            index += BookFeature.ID_LENGTH;
            #endregion

            #region copy book title
            byte[] titleBytes = new byte[BookFeature.TITLE_MAX_LENGTH];
            Array.Copy(byteArray, index, titleBytes, 0, titleBytes.Length);
            book.Title = DataOperations.ByteArrayToString(titleBytes);

            index += BookFeature.TITLE_MAX_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = new byte[BookFeature.DESCRIPTION_MAX_LENGTH];
            Array.Copy(byteArray, index, descBytes, 0, descBytes.Length);
            book.Description = DataOperations.ByteArrayToString(descBytes);

            index += BookFeature.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book authors

            byte[] authorBytes = new byte[BookFeature.AUTHORS_NAME_MAX_LENGTH];
            Array.Copy(byteArray, index, authorBytes, 0, authorBytes.Length);
            book.Authors = DataOperations.ByteArrayToString(authorBytes);

            index += BookFeature.AUTHORS_NAME_MAX_LENGTH;
            #endregion


            #region copy book categories
            byte[] categoryBytes = new byte[BookFeature.CATEGORY_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, categoryBytes, 0, categoryBytes.Length);

            book.Categories = DataOperations.ByteArrayToString(categoryBytes);

            index += BookFeature.CATEGORY_NAME_MAX_LENGTH;

            //Console.ForegroundColor = ConsoleColor.Red;

            #endregion


            if (index != byteArray.Length)
            {

                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (book.Id == 0)
            {
                return null;
            }
            else
            {
                return book;
            }


        }
        #endregion




    }
}
