using System;
using System.Collections.Generic;

namespace PROJECT_OOP
{
    public class Member : INotification
    {
        public int MemberID { get; set; }
        public string Name { get; set; } = string.Empty; // Initialize with default value
        public string Email { get; set; } = string.Empty; // Initialize with default value
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public Member(int memberID, string name, string email)
        {
            MemberID = memberID;
            Name = name;
            Email = email;
        }

        public virtual string BorrowBook(Book book)
        {
            if (book.IsBorrowed)
            {
                return "Book is already borrowed.";
            }
            book.IsBorrowed = true;
            BorrowedBooks.Add(book);
            SendNotification($"You have borrowed '{book.Title}'.");
            return $"You have borrowed '{book.Title}'.";
        }

        public virtual string ReturnBook(Book book)
        {
            if (!BorrowedBooks.Contains(book))
            {
                return "You haven't borrowed this book.";
            }
            book.IsBorrowed = false;
            BorrowedBooks.Remove(book);
            SendNotification($"You have returned '{book.Title}'.");
            return $"You have returned '{book.Title}'.";
        }

        public void SendNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }

}
