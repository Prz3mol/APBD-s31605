namespace APBD.Zadanie2;

public abstract class User
{
    public static int idCounter = 1;
    public int Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxBorrowLimit { get; }

    protected User(string firstName, string lastName)
    {
        Id = idCounter++;
        FirstName = firstName;
        LastName = lastName;
    }


}

public class Student : User
{
    public Student(string firstName, string lastName) : base(firstName, lastName) { }
    public override int MaxBorrowLimit => 2; 
    
    
    
    
}

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName) { }
    public override int MaxBorrowLimit => 5; 
    
    
}