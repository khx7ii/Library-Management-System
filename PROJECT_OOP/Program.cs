using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJECT_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            // Initialize the Interface class with the library instance
            var appInterface = new Interface();

            // Example Books
            library.AddBook(new Book(1, "c++ Programming", "Kholod", "1234567890"));
            library.AddBook(new Book(2, "Python Programming", "Asem", "0987654321"));

            // Example Members
            library.AddMember(new Member(1, "Reham Fathy", "reham@example.com"));
            library.AddMember(new PremiumMember(2, "Yosif", "yosif@example.com", 20.0m, 0.1));

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Select mode (Admin/Buyer): ");
                var mode = Console.ReadLine()?.ToLower();

                if (mode == "admin")
                {
                    appInterface.AdminMode();
                }
                else if (mode == "buyer")
                {
                    Console.WriteLine("Buyer Mode:");
                    Console.WriteLine("1. View Books");
                    Console.WriteLine("2. Borrow Book");
                    Console.WriteLine("3. Return Book");
                    Console.WriteLine("0. Exit");
                    Console.Write("Enter your choice: ");

                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            ViewBooks(library);
                            break;

                        case "2":
                            BorrowBook(library);
                            break;

                        case "3":
                            ReturnBook(library);
                            break;

                        case "0":
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid mode.");
                }
            }
        }

        static void ViewBooks(Library library)
        {
            Console.WriteLine("Books in the Library:");
            foreach (var book in library.Books)
            {
                Console.WriteLine($"ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Borrowed: {book.IsBorrowed}");
            }
        }

        static void BorrowBook(Library library)
        {
            Console.Write("Enter Member ID: ");
            int memberId = ReadIntFromConsole();
            Console.Write("Enter Book ID: ");
            int bookId = ReadIntFromConsole();

            var result = library.BorrowBook(memberId, bookId);
            Console.WriteLine(result);
        }

        static void ReturnBook(Library library)
        {
            Console.Write("Enter Member ID: ");
            int memberId = ReadIntFromConsole();
            Console.Write("Enter Book ID: ");
            int bookId = ReadIntFromConsole();

            var result = library.ReturnBook(memberId, bookId);
            Console.WriteLine(result);
        }

        static int ReadIntFromConsole()
        {
            string? input = Console.ReadLine();
            return int.TryParse(input, out int result) ? result : 0;
        }

        static decimal ReadDecimalFromConsole()
        {
            string? input = Console.ReadLine();
            return decimal.TryParse(input, out decimal result) ? result : 0.0m;
        }

        static double ReadDoubleFromConsole()
        {
            string? input = Console.ReadLine();
            return double.TryParse(input, out double result) ? result : 0.0;
        }
    }
}
