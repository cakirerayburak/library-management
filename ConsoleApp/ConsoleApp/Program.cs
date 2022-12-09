using System;
using UserInterface1;
using MainMenu;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.IO;


namespace ConsoleApp1
{

    internal class Program
    {




        static ConsoleKeyInfo cki = new ConsoleKeyInfo();
        public static int i;
        private static int c;
        private protected static string logname;
        private protected static string logpassword;
        #region
        private protected static string username = "";
        private protected static string userpass = "";
        #endregion

        #region
        public static int ID;
        public static string ID_Control;
        public static string Title;
        public static string Describe;
        public static string Author;
        public static string Category;
        public static int searchId;
        public static string searchTitle;
        public static int bookCount;
        public static string date;
        public static string time;
        public static int borrowId;
        public static string borrowName;
        public static string borrowReturnDate;
        public static int day;
        public static int month;
        public static int year;
        public static int dayNow;
        public static int monthNow;
        public static int yearNow;
        public static int deleteId;
        public static string deleteName;
        #endregion
        #region
        private static readonly bool logloop = true;
        #endregion
        public static void Main()
        {

        loop:

            logname = string.Empty;
            logpassword = string.Empty;


            Console.SetWindowSize(300, 250);


            GUI.userint(40, 90, 2, 27);

            Console.SetCursorPosition(40, 8);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("--------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;


            Console.SetCursorPosition(45, 5);
            Console.WriteLine("*Kütüphane Yönetim Sistemine Hoşgeldiniz*");


            Console.SetCursorPosition(44, 14);
            Console.WriteLine("Kullanıcı Adınızı Giriniz: ");

            Console.SetCursorPosition(44, 16);
            Console.WriteLine("Şifrenizi Giriniz: ");

            Console.SetCursorPosition(70, 14);
            logname = Console.ReadLine();
            Console.SetCursorPosition(62, 16);




            //logpassword = Console.ReadLine();

            i = 63;


            do
            {
                cki = Console.ReadKey(true);
                if (cki.Key != ConsoleKey.Backspace && cki.Key != ConsoleKey.Enter)
                {


                    logpassword += cki.KeyChar;

                    //logpassword = Console.ReadLine();
                    Console.SetCursorPosition(i, 16);
                    Console.Write(cki.KeyChar);
                    System.Threading.Thread.Sleep(100);
                    Console.SetCursorPosition(i, 16);
                    Console.Write("*");
                    Console.SetCursorPosition(i + 1, 16);
                    i++;

                }
            } while (!(cki.Key == ConsoleKey.Enter));

            logname = logname.ToLower();
            //logpassword = "";logpassword.ToLower();






            System.Threading.Thread.Sleep(1000);
            if ((logpassword.Equals(userpass)) && (logname.Equals(username)))
            {
                Console.Clear();
                Console.SetWindowSize(300, 250);

                GUI.userint(35, 95, 2, 27);

                Console.SetCursorPosition(55, 10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("***Giriş Başarılı***");
                Console.SetCursorPosition(42, 13);
                Console.Write("***Kütüphane Yönetim Sistemine Hoş Geldiniz***");
                Console.SetCursorPosition(42, 14);
                System.Threading.Thread.Sleep(1000);


            }
            else
            {

                Console.Clear();

                GUI.userint(40, 90, 2, 27);
                Console.SetCursorPosition(50, 10);
                Console.Write("Kullanıcı Adı veya Şifre Yanlış");
                Console.SetCursorPosition(53, 12);
                Console.Write("Lütfen Tekrar Deneyiniz");
                System.Threading.Thread.Sleep(2000);
                goto loop;

            }


        menu2loop:
            Console.ForegroundColor = ConsoleColor.Gray;

            MainScreen a = new MainScreen();






            #region

            GUI.userint(40, 90, 2, 27);
            GUI.userint(40, 90, 2, 27);

            Console.SetCursorPosition(45, 7);
            Console.Write("*Add Book");
            Console.SetCursorPosition(45, 8);
            Console.Write("*Delete");
            Console.SetCursorPosition(45, 9);
            Console.Write("*List");
            Console.SetCursorPosition(45, 10);
            Console.Write("*Search");
            Console.SetCursorPosition(45, 11);
            Console.Write("*Borrow");
            Console.SetCursorPosition(45, 12);
            Console.Write("*Exit");
            #endregion

            Console.SetCursorPosition(55, 7);



            //Console.ReadKey();
            cki = Console.ReadKey(true);



            do
            {

                Console.ForegroundColor = ConsoleColor.Cyan;


                if (cki.Key == ConsoleKey.DownArrow)
                {
                    goto Found8;
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    goto Found12;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    goto Found7;
                }


            Found7: //Add book function
                Console.SetCursorPosition(55, 7);
                //Console.ReadKey();
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    goto Found8;
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    goto Found12;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {

                ıdloop:

                    Console.Clear();

                    GUI.userint(40, 90, 2, 27);
                    GUI.userint(40, 90, 2, 27);



                    Console.SetCursorPosition(44, 5);
                    Console.Write("*Kitap ID'sini Giriniz:");
                    try
                    {
                        Console.SetCursorPosition(73, 5);
                        ID_Control = Console.ReadLine();
                        ID = Convert.ToInt32(ID_Control);
                    }
                    catch (FormatException)
                    {

                        Console.SetCursorPosition(65, 6);
                        Console.Write("Id must be Number");
                        System.Threading.Thread.Sleep(1000);
                        goto ıdloop;


                    }




                    Console.SetCursorPosition(44, 7);
                    Console.Write("*Kitap İsmini Giriniz:");
                    Console.SetCursorPosition(73, 7);
                    Title = Console.ReadLine();


                    Console.SetCursorPosition(44, 9);
                    Console.Write("*Kitap Tanımını Giriniz:");
                    Console.SetCursorPosition(73, 9);
                    Describe = Console.ReadLine();



                    Console.SetCursorPosition(44, 11);
                    Console.Write("*Kitap Yazarını Giriniz:");
                    Console.SetCursorPosition(73, 11);
                    Author = Console.ReadLine();

                    Console.SetCursorPosition(44, 13);
                    Console.Write("*Kitap Kategorisini Giriniz:");
                    Console.SetCursorPosition(73, 13);
                    Category = Console.ReadLine();


                    a.AddBook(ID, Title, Describe, Author, Category, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
                    a.IncreaseBook(1);
                    goto menu2loop;
                    //a.PullBook();
                }

            Found8://Delete function
                Console.SetCursorPosition(55, 8);
                //Console.ReadKey();
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    goto Found9;
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    goto Found7;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    GUI.userint(40, 90, 2, 27);
                    GUI.userint(40, 90, 2, 27);

                    Console.SetCursorPosition(50, 7);
                    Console.Write("*Delete By ID ");
                    Console.SetCursorPosition(50, 9);
                    Console.Write("*Delete By Book Name ");
                    Console.SetCursorPosition(50, 11);
                    Console.Write("Exit ");
                    Console.SetCursorPosition(65, 7);
                    Console.ReadKey();
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.DownArrow)
                    {
                        goto Found19;
                    }
                    else if (cki.Key == ConsoleKey.UpArrow)
                    {
                        goto Found20;
                    }


                Found18://delete by ıd
                    Console.SetCursorPosition(55, 9);
                    //Console.ReadKey();
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.DownArrow)
                    {
                        goto Found19;
                    }
                    else if (cki.Key == ConsoleKey.UpArrow)
                    {
                        goto Found20;
                    }
                    else if (cki.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        GUI.userint(40, 90, 2, 27);
                        GUI.userint(40, 90, 2, 27);

                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("Please Enter ID;");
                        Console.SetCursorPosition(66, 7);
                        deleteId = Convert.ToInt32(Console.ReadLine());

                        for (c = 1; c < 4; c++)
                        {



                            byte[] bookWrittenBytes = FileOperations.ReadBlock(c, BookFeature.BOOK_DATA_BLOCK_SIZE, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
                            BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);

                            try
                            {
                                if (bookWrittenObject.Id == deleteId)
                                {

                                    Console.Clear();

                                    GUI.userint(40, 90, 2, 27);
                                    GUI.userint(40, 90, 2, 27);

                                    Console.SetCursorPosition(52, 5);
                                    Console.Write("Kitap ID'si:" + bookWrittenObject.Id);
                                    Console.SetCursorPosition(52, 6);
                                    Console.Write("Kitap İsmi:" + bookWrittenObject.Title);
                                    Console.SetCursorPosition(52, 7);
                                    Console.WriteLine("Kitap Tanımı:" + bookWrittenObject.Description);
                                    Console.SetCursorPosition(52, 8);
                                    Console.WriteLine("Kitap Yazarı:" + bookWrittenObject.Authors);
                                    Console.SetCursorPosition(52, 9);
                                    Console.WriteLine("Kitap Kategorisi:" + bookWrittenObject.Categories);



                                    Console.SetCursorPosition(45, 12);
                                    Console.WriteLine("Are you sure you want to delete??(Yes=Enter)(No=Space)");
                                    Console.SetCursorPosition(67, 13);
                                    cki = Console.ReadKey(true);

                                    if (cki.Key == ConsoleKey.Enter)
                                    {
                                        if (c == 1) { FileOperations.DeleteBlock2(404, 0, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat"); a.DecreaseBook(1); }
                                        if (c == 2) { FileOperations.DeleteBlock2(404, 404, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat"); a.DecreaseBook(1); }
                                        if (c == 3) { FileOperations.DeleteBlock2(404, 808, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat"); a.DecreaseBook(1); }
                                        if (c == 4) { FileOperations.DeleteBlock2(404, 1212, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat"); a.DecreaseBook(1); }
                                        if (c == 5) { FileOperations.DeleteBlock2(404, 1616, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat"); a.DecreaseBook(1); }
                                        if (c == 6) { FileOperations.DeleteBlock2(404, 2020, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat"); a.DecreaseBook(1); }
                                    }





                                    goto menu2loop;
                                }




                            }
                            catch (NullReferenceException) { continue; }







                        }



                    }

                Found19://delete by book name
                    Console.SetCursorPosition(55, 9);
                    //Console.ReadKey();
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.DownArrow)
                    {
                        goto Found20;
                    }
                    else if (cki.Key == ConsoleKey.UpArrow)
                    {
                        goto Found18;
                    }
                    else if (cki.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        GUI.userint(40, 90, 2, 27);
                        GUI.userint(40, 90, 2, 27);

                        Console.SetCursorPosition(72, 7);

                    }


                Found20://delete exit
                    Console.SetCursorPosition(55, 11);
                    //Console.ReadKey();
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.DownArrow)
                    {
                        goto Found19;
                    }
                    else if (cki.Key == ConsoleKey.UpArrow)
                    {
                        goto Found19;
                    }
                    else if (cki.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        GUI.userint(40, 90, 2, 27);
                        GUI.userint(40, 90, 2, 27);

                        Console.SetCursorPosition(72, 7);

                    }
                }



            Found9://List function
                Console.SetCursorPosition(55, 9);
                //Console.ReadKey();
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    goto Found10;
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    goto Found8;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    GUI.userint(20, 110, 2, 27);
                    GUI.userint(20, 110, 2, 27);

                    for (c = 1; c < 5; c++)
                    {


                        byte[] bookWrittenBytes = FileOperations.ReadBlock(c, BookFeature.BOOK_DATA_BLOCK_SIZE, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");

                        if (bookWrittenBytes != null)
                        {
                            BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);

                            int counter = 0;
                            int BOOKID;


                            //BOOKID = Convert.ToInt32(bookWrittenObject.Id);

                            try
                            {
                                

                                BOOKID = Convert.ToInt32(bookWrittenObject.Id);
                          

                                while (BOOKID > 0)
                                {
                                    BOOKID /= 10;
                                    counter++;
                                }

                                int x = 25;
                                if (counter == 4)
                                {




                                    Console.SetCursorPosition(x, 5);
                                    Console.Write("Kitap ID'si:" + bookWrittenObject.Id);
                                    Console.SetCursorPosition(x, 6);
                                    Console.Write("Kitap İsmi:" + bookWrittenObject.Title);
                                    Console.SetCursorPosition(x, 7);
                                    Console.Write("Kitap Tanımı:" + bookWrittenObject.Description);
                                    Console.SetCursorPosition(x, 8);
                                    Console.Write("Kitap Yazarı:" + bookWrittenObject.Authors);
                                    Console.SetCursorPosition(x, 9);
                                    Console.Write("Kitap Kategorisi:" + bookWrittenObject.Categories);
                                    Console.SetCursorPosition(30, 25);
                                    Console.Write("For Exit Press Enter");
                                    Console.ReadKey();
                                }
                            }
                            catch (NullReferenceException)
                            {
                                goto menu2loop;
                            }
                        }



                    }
                    Console.ReadKey();



                    goto menu2loop;
                }

            Found10://Search function
                Console.SetCursorPosition(55, 10);
                //Console.ReadKey();
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    goto Found11;
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    goto Found9;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {

                    Console.Clear();

                    GUI.userint(40, 90, 2, 27);
                    GUI.userint(40, 90, 2, 27);

                    Console.SetCursorPosition(50, 7);
                    Console.Write("*Search By ID ");
                    Console.SetCursorPosition(50, 9);
                    Console.Write("*Search By Book Name ");
                    Console.SetCursorPosition(50, 11);
                    Console.Write("Exit ");
                    Console.SetCursorPosition(65, 7);
                    Console.ReadKey();
                    cki = Console.ReadKey(true);
                    do
                    {

                        Console.SetCursorPosition(65, 7);

                        if (cki.Key == ConsoleKey.DownArrow)
                        {
                            goto Found14;
                        }
                        else if (cki.Key == ConsoleKey.UpArrow)
                        {
                            Console.SetCursorPosition(51, 7);
                            goto Found15;
                        }





                    Found13://Search by ıd
                        //Console.SetCursorPosition(55, 10);
                        Console.SetCursorPosition(65, 7);
                        //Console.ReadKey();
                        cki = Console.ReadKey(true);



                        if (cki.Key == ConsoleKey.DownArrow)
                        {
                            goto Found14;
                        }
                        else if (cki.Key == ConsoleKey.UpArrow)
                        {
                            goto Found15;
                        }
                        else if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();

                            GUI.userint(40, 90, 2, 27);
                            GUI.userint(40, 90, 2, 27);


                            Console.SetCursorPosition(57, 7);
                            Console.Write("Please Enter ID: ");
                            searchId = Convert.ToInt32(Console.ReadLine());

                            for (c = 1; c < 4; c++)
                            {



                                byte[] bookWrittenBytes = FileOperations.ReadBlock(c, BookFeature.BOOK_DATA_BLOCK_SIZE, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
                                BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);

                                if (bookWrittenObject.Id == searchId)
                                {

                                    Console.Clear();

                                    GUI.userint(40, 90, 2, 27);
                                    GUI.userint(40, 90, 2, 27);

                                    Console.SetCursorPosition(52, 5);
                                    Console.Write("Kitap ID'si:" + bookWrittenObject.Id);
                                    Console.SetCursorPosition(52, 6);
                                    Console.Write("Kitap İsmi:" + bookWrittenObject.Title);
                                    Console.SetCursorPosition(52, 7);
                                    Console.WriteLine("Kitap Tanımı:" + bookWrittenObject.Description);
                                    Console.SetCursorPosition(52, 8);
                                    Console.WriteLine("Kitap Yazarı:" + bookWrittenObject.Authors);
                                    Console.SetCursorPosition(52, 9);
                                    Console.WriteLine("Kitap Kategorisi:" + bookWrittenObject.Categories);
                                    Console.SetCursorPosition(45, 25);
                                    Console.WriteLine("For Exit Press Enter");


                                    Console.ReadKey();
                                    goto menu2loop;


                                }







                            }

                        }



                    Found14://Search by book name
                            //Console.SetCursorPosition(55, 10);

                        Console.SetCursorPosition(72, 9);
                        //Console.ReadKey();
                        cki = Console.ReadKey(true);

                        if (cki.Key == ConsoleKey.DownArrow)
                        {
                            goto Found15;
                        }
                        else if (cki.Key == ConsoleKey.UpArrow)
                        {
                            goto Found13;
                        }
                        else if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();

                            GUI.userint(40, 90, 2, 27);
                            GUI.userint(40, 90, 2, 27);
                            Console.Write("Please Enter Book Name:");
                            searchTitle = Console.ReadLine();
                            for (c = 1; c < 4; c++)
                            {

                                try
                                {
                                    byte[] bookWrittenBytes = FileOperations.ReadBlock(c, BookFeature.BOOK_DATA_BLOCK_SIZE, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
                                    BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
                                    if (bookWrittenObject.Title == null) { goto Found14; }
                                    if (bookWrittenObject.Title == searchTitle)
                                    {


                                        Console.Clear();

                                        GUI.userint(40, 90, 2, 27);
                                        GUI.userint(40, 90, 2, 27);

                                        Console.SetCursorPosition(52, 5);
                                        Console.Write("Kitap ID'si:" + bookWrittenObject.Id);
                                        Console.SetCursorPosition(52, 6);
                                        Console.Write("Kitap İsmi:" + bookWrittenObject.Title);
                                        Console.SetCursorPosition(52, 7);
                                        Console.Write("Kitap Tanımı:" + bookWrittenObject.Description);
                                        Console.SetCursorPosition(52, 8);
                                        Console.Write("Kitap Yazarı:" + bookWrittenObject.Authors);
                                        Console.SetCursorPosition(52, 9);
                                        Console.Write("Kitap Kategorisi:" + bookWrittenObject.Categories);
                                        Console.SetCursorPosition(45, 25);
                                        Console.Write("For Exit Press Enter");


                                        Console.ReadKey();
                                        goto menu2loop;
                                    }
                                }
                                catch(NullReferenceException)
                                {
                                    goto menu2loop;
                                }





                            }
                        }

                    Found15://Exit function

                        //Console.SetCursorPosition(57, 11);
                        Console.SetCursorPosition(55, 11);
                        //Console.ReadKey();
                        cki = Console.ReadKey(true);


                        if (cki.Key == ConsoleKey.DownArrow)
                        {

                            goto Found13;
                        }
                        else if (cki.Key == ConsoleKey.UpArrow)
                        {
                            goto Found14;
                        }
                        else if (cki.Key == ConsoleKey.Enter)
                        {
                            goto menu2loop;
                        }
                    }
                    while (true);
                }







            Found11://Borrow function
                Console.SetCursorPosition(55, 11);
                //Console.ReadKey();
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    goto Found12;
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    goto Found10;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    time = DateTime.Now.ToString();
                    date = DateTime.Now.ToLongDateString();
                Found17:
                    Console.Clear();

                    GUI.userint(40, 90, 2, 27);
                    GUI.userint(40, 90, 2, 27);

                    Console.SetCursorPosition(55, 24);
                    Console.WriteLine(time, date);


                    Console.SetCursorPosition(52, 7);
                    Console.WriteLine("Enter Book ID:");
                    Console.SetCursorPosition(67, 7);
                    borrowId = Convert.ToInt32(Console.ReadLine());

                    for (c = 1; c < 8; c++)
                    {



                        byte[] bookWrittenBytes = FileOperations.ReadBlock(c, BookFeature.BOOK_DATA_BLOCK_SIZE, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
                        BookFeature bookWrittenObject = BookFeature.ByteArrayBlockToBook(bookWrittenBytes);
                        try
                        {
                            if (bookWrittenObject.Id == borrowId)
                            {


                                Console.SetCursorPosition(52, 5);
                                Console.WriteLine("Kitap ID'si:" + bookWrittenObject.Id);
                                Console.SetCursorPosition(52, 6);
                                Console.WriteLine("Kitap İsmi:" + bookWrittenObject.Title);
                                Console.SetCursorPosition(52, 7);
                                Console.WriteLine("Kitap Tanımı:" + bookWrittenObject.Description);
                                Console.SetCursorPosition(52, 8);
                                Console.WriteLine("Kitap Yazarı:" + bookWrittenObject.Authors);
                                Console.SetCursorPosition(52, 9);
                                Console.WriteLine("Kitap Kategorisi:" + bookWrittenObject.Categories);





                                goto Found18;


                            }
                        }
                        catch
                        {
                            continue;
                        }


                    }

                    if (c == 8)
                    {

                        Console.SetCursorPosition(52, 8);
                        Console.WriteLine("!ID not Found in Database!");
                        System.Threading.Thread.Sleep(800);
                        Console.SetCursorPosition(51, 10);
                        Console.WriteLine("Press enter to enter ID again");
                        Console.SetCursorPosition(47, 11);
                        Console.WriteLine("Press space to return to the Main Menu");
                        Console.SetCursorPosition(65, 12);
                        cki = Console.ReadKey(true);

                        if (cki.Key == ConsoleKey.Enter) { goto Found17; }
                        if (cki.Key == ConsoleKey.Spacebar) { goto menu2loop; }
                        goto Found17;
                    }
                Found18:
                    Console.SetCursorPosition(52, 12);
                    Console.WriteLine("Enter the Person's Name: ");
                    Console.SetCursorPosition(77, 12);
                    borrowName = Console.ReadLine();
                Found16:
                    Console.SetCursorPosition(52, 14);
                    Console.WriteLine("Enter Return Date:");
                    Console.SetCursorPosition(73, 14);
                    try
                    {
                        day = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(75, 14);
                        Console.Write("/");
                        Console.SetCursorPosition(76, 14);
                        month = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(78, 14);
                        Console.Write("/");
                        Console.SetCursorPosition(79, 14);
                        year = Convert.ToInt32(Console.ReadLine());

                        if (yearNow > year && day < 31 && month < 12)
                        {
                            goto Found21;
                        }
                        else
                        {
                            Console.SetCursorPosition(44, 16);
                            Console.WriteLine("!Return Date Must be Sometime in The Future!");
                            Console.WriteLine("                                             ");

                            goto Found16;


                        }
                    }
                    catch (System.FormatException)
                    {
                        Console.Write("Date Must be number(Day/Month/Year)");
                        Console.Clear();
                        goto Found16;
                    }

                Found21:

                    Console.WriteLine(borrowId);
                    Console.WriteLine(borrowName);
                    Console.WriteLine(day + "/" + month + "/" + year);

                    borrowReturnDate = day + "/" + month + "/" + year;
                    Console.WriteLine(borrowReturnDate);


                    a.AddBorrow(borrowId, borrowName, borrowReturnDate, date, "C:\\Users\\ROG ZEPHYRUS\\Desktop\\Ödev\\ConsoleApp\\ConsoleApp\\Library.dat");
                    a.PullBorrow();
                    Console.ReadKey();

                }

            Found12://Exit function
                Console.SetCursorPosition(55, 12);
                //Console.ReadKey();
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    goto Found7;
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    goto Found11;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    goto loop;

                }















            }
            while (logloop);

        }




    }
}
