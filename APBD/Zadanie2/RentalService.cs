namespace APBD.Zadanie2;

public class RentalService
{
    private List<User> _users = new();
    private List<Hardware> _hardware = new();
    private List<Borrowing> _borrowings = new();
    
    public void AddUser(User user)
    {
        _users.Add(user);
    }
    
    public void AddHardware(Hardware hardware)
    {
        _hardware.Add(hardware);
    }

    public void BorrowHardware(int userId, int hardwareId, int days)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        var hardware = _hardware.FirstOrDefault(h => h.Id == hardwareId);

        if (user == null)
            throw new Exception("User not found");

        if (hardware == null)
            throw new Exception("Hardware not found");

        if (!hardware.IsAvailable)
            throw new Exception("Hardware is not available");

        var activeBorrowings = _borrowings
            .Where(b => b.User.Id == userId && !b.IsReturned)
            .Count();

        if (activeBorrowings >= user.MaxBorrowLimit)
            throw new Exception("User reached borrow limit");

        var borrowing = new Borrowing(
            user,
            hardware,
            DateTime.Now,
            DateTime.Now.AddDays(days)
        );

        _borrowings.Add(borrowing);
        hardware.IsAvailable = false;
    }

    public void ReturnHardware(int hardwareId)
    {
        var borrowing = _borrowings
            .FirstOrDefault(b => b.Hardware.Id == hardwareId && !b.IsReturned);
        
        if (borrowing == null)
            throw new Exception("Borrowing not found");
        
        borrowing.ReturnDate = DateTime.Now;
        borrowing.Hardware.IsAvailable = true;
    }

    public decimal CalculatePenalty(Borrowing borrowing)
    {
        if (!borrowing.IsReturned)
            return 0;

        if (borrowing.ReturnDate.Value <= borrowing.DueDate)
            return 0;
        
        var daysLate = (borrowing.ReturnDate.Value - borrowing.DueDate).Days;
        return daysLate * 10;
    }
    
    public void PrintReport()
    {
        Console.WriteLine("\n=== RAPORT ===");

        Console.WriteLine("\nSprzęt:");
        foreach (var h in _hardware)
        {
            Console.WriteLine($"ID: {h.Id} | {h.Name} - {(h.IsAvailable ? "Dostępny" : "Niedostępny")}");
        }

        Console.WriteLine("\nWypożyczenia:");
        foreach (var b in _borrowings)
        {
            Console.WriteLine($"User {b.User.Id} ({b.User.FirstName}) -> {b.Hardware.Name} | Returned: {b.IsReturned}");
        }
    }
    public List<User> GetUsers() => _users;
    public List<Hardware> GetHardware() => _hardware;
}