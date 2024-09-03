using PROJECT_OOP;
public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Member> Members { get; set; } = new List<Member>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void AddMember(Member member)
    {
        Members.Add(member);
    }

    public string BorrowBook(int memberId, int bookId)
    {
        var member = Members.SingleOrDefault(m => m.MemberID == memberId);
        var book = Books.SingleOrDefault(b => b.BookID == bookId);

        if (member == null || book == null)
            return "Invalid member ID or book ID.";

        return member.BorrowBook(book);
    }

    public string ReturnBook(int memberId, int bookId)
    {
        var member = Members.SingleOrDefault(m => m.MemberID == memberId);
        var book = Books.SingleOrDefault(b => b.BookID == bookId);

        if (member == null || book == null)
            return "Invalid member ID or book ID.";

        return member.ReturnBook(book);
    }
}
