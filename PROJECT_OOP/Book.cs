// Book.cs
using System;

namespace PROJECT_OOP
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; set; }

        public Book(int bookID, string title, string author, string isbn)
        {
            BookID = bookID;
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
        }
    }
}

