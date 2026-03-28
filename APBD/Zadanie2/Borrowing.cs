namespace APBD.Zadanie2;

public class Borrowing
{
    public User User { get; set; }
    public Hardware Hardware { get; set; }
    
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public bool IsReturned => ReturnDate != null;

    public Borrowing(User user, Hardware hardware, DateTime borrowDate, DateTime dueDate)
    {
        User = user;
        Hardware = hardware;
        BorrowDate = borrowDate;
        DueDate = dueDate;
    }
}