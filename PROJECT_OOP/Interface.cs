using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJECT_OOP
{
    public class Interface
    {
        private Library library = new Library();

        public void AdminMode()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Admin Mode:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. View Books");
                Console.WriteLine("4. View Members");
                Console.WriteLine("5. Search Book");
                Console.WriteLine("6. Search Member");
                Console.WriteLine("7. Delete Book");
                Console.WriteLine("8. Delete Member");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;

                    case "2":
                        AddMember();
                        break;

                    case "3":
                        ViewBooks();
                        break;

                    case "4":
                        ViewMembers();
                        break;

                    case "5":
                        SearchBook();
                        break;

                    case "6":
                        SearchMember();
                        break;

                    case "7":
                        DeleteBook();
                        break;

                    case "8":
                        DeleteMember();
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.WriteLine("Enter Book Details:");
            Console.Write("Title: ");
            var title = Console.ReadLine() ?? string.Empty;
            Console.Write("Author: ");
            var author = Console.ReadLine() ?? string.Empty;
            Console.Write("ISBN: ");
            var isbn = Console.ReadLine() ?? string.Empty;

            int bookID = library.Books.Count + 1;
            var book = new Book(bookID, title, author, isbn);
            library.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }

        private void AddMember()
        {
            Console.WriteLine("Enter Member Details:");
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Email: ");
            var email = Console.ReadLine() ?? string.Empty;

            Console.Write("Is Premium Member? (yes/no): ");
            var isPremium = Console.ReadLine()?.Trim().ToLower() == "yes";

            Member member;

            if (isPremium)
            {
                Console.Write("Monthly Fee: ");
                decimal monthlyFee = ReadDecimalFromConsole();
                Console.Write("Discount Rate: ");
                double discountRate = ReadDoubleFromConsole();

                member = new PremiumMember(library.Members.Count + 1, name, email, monthlyFee, discountRate);
            }
            else
            {
                member = new Member(library.Members.Count + 1, name, email);
            }

            library.AddMember(member);
            Console.WriteLine("Member added successfully!");
        }

        private void ViewBooks()
        {
            Console.WriteLine("Books in the Library:");
            foreach (var book in library.Books)
            {
                Console.WriteLine($"ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Borrowed: {book.IsBorrowed}");
            }
        }

        private void ViewMembers()
        {
            Console.WriteLine("Members in the Library:");
            foreach (var member in library.Members)
            {
                string type = member is PremiumMember ? "Premium" : "Regular";
                Console.WriteLine($"ID: {member.MemberID}, Name: {member.Name}, Email: {member.Email}, Type: {type}");
            }
        }

        private void SearchBook()
        {
            Console.Write("Enter Book ID to search: ");
            int bookID = ReadIntFromConsole();
            var book = library.Books.FirstOrDefault(b => b.BookID == bookID);
            if (book != null)
            {
                Console.WriteLine($"Found Book - ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Borrowed: {book.IsBorrowed}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private void SearchMember()
        {
            Console.Write("Enter Member ID to search: ");
            int memberID = ReadIntFromConsole();
            var member = library.Members.FirstOrDefault(m => m.MemberID == memberID);
            if (member != null)
            {
                string type = member is PremiumMember ? "Premium" : "Regular";
                Console.WriteLine($"Found Member - ID: {member.MemberID}, Name: {member.Name}, Email: {member.Email}, Type: {type}");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        private void DeleteBook()
        {
            Console.Write("Enter Book ID to delete: ");
            int bookID = ReadIntFromConsole();
            var book = library.Books.FirstOrDefault(b => b.BookID == bookID);
            if (book != null)
            {
                library.Books.Remove(book);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private void DeleteMember()
        {
            Console.Write("Enter Member ID to delete: ");
            int memberID = ReadIntFromConsole();
            var member = library.Members.FirstOrDefault(m => m.MemberID == memberID);
            if (member != null)
            {
                library.Members.Remove(member);
                Console.WriteLine("Member deleted successfully.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        private int ReadIntFromConsole()
        {
            string? input = Console.ReadLine();
            return int.TryParse(input, out int result) ? result : 0;
        }

        private decimal ReadDecimalFromConsole()
        {
            string? input = Console.ReadLine();
            return decimal.TryParse(input, out decimal result) ? result : 0.0m;
        }

        private double ReadDoubleFromConsole()
        {
            string? input = Console.ReadLine();
            return double.TryParse(input, out double result) ? result : 0.0;
        }
    }
}
