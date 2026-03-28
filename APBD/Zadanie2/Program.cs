namespace APBD.Zadanie2;

public class Program
{
    static void Main(string[] args)
    {
        var service = new RentalService();
        //Przykładowe dane
        service.AddHardware(new Laptop("Dell", 16, "Intel"));
        service.AddHardware(new Laptop("IBM", 4, "Intel"));
        service.AddHardware(new Projektor("Wambo", 800, true));
        service.AddHardware(new Projektor("Epson", 1000, false));
        service.AddHardware(new Camera("Sony",10,true));        
        
        service.AddUser(new Employee("Przemek","Molenda"));
        service.AddUser(new Student("Jan", "Kowalski"));
        
        
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Dodaj użytkownika");
            Console.WriteLine("2. Dodaj sprzęt");
            Console.WriteLine("3. Wypożycz sprzęt");
            Console.WriteLine("4. Zwróć sprzęt");
            Console.WriteLine("5. Pokaż raport");
            Console.WriteLine("6. Pokaż użytkowników");
            Console.WriteLine("7. Pokaż sprzęt");
            Console.WriteLine("0. Wyjście");

            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddUser(service);
                    break;
                case "2":
                    AddHardware(service);
                    break;
                case "3":
                    BorrowHardware(service);
                    break;
                case "4":
                    ReturnHardware(service);
                    break;
                case "5":
                    service.PrintReport();
                    break;
                case "6":
                    ShowUsers(service);
                    break;
                case "7":
                    ShowHardware(service);
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Niepoprawna opcja");
                    break;
            }
        }
    }

    static void AddUser(RentalService service)
    {
        Console.Write("Typ (1-Student, 2-Employee): ");
        var type = Console.ReadLine();

        Console.Write("Imię: ");
        var firstName = Console.ReadLine();

        Console.Write("Nazwisko: ");
        var lastName = Console.ReadLine();

        User user;

        if (type == "1")
            user = new Student(firstName, lastName);
        else
            user = new Employee(firstName, lastName);

        service.AddUser(user);

        Console.WriteLine($"Dodano użytkownika (ID: {user.Id})");
    }

    static void AddHardware(RentalService service)
    {
        Console.WriteLine("Typ (1-Laptop, 2-Projektor, 3-Kamera): ");
        var type = Console.ReadLine();

        Console.Write("Nazwa: ");
        var name = Console.ReadLine();

        Hardware hardware;

        switch (type)
        {
            case "1":
                Console.Write("RAM: ");
                int ram = int.Parse(Console.ReadLine());

                Console.Write("Procesor: ");
                var cpu = Console.ReadLine();

                hardware = new Laptop(name, ram, cpu);
                break;

            case "2":
                Console.Write("Lumens: ");
                int lumens = int.Parse(Console.ReadLine());

                Console.Write("FullHD (true/false): ");
                bool isFullHd = bool.Parse(Console.ReadLine());

                hardware = new Projektor(name, lumens, isFullHd);
                break;

            default:
                Console.Write("Rozdzielczość MP: ");
                int mp = int.Parse(Console.ReadLine());

                Console.Write("Video (true/false): ");
                bool video = bool.Parse(Console.ReadLine());

                hardware = new Camera(name, mp, video);
                break;
        }

        service.AddHardware(hardware);

        Console.WriteLine($"Dodano sprzęt (ID: {hardware.Id})");
    }

    static void BorrowHardware(RentalService service)
    {
        try
        {
            ShowUsers(service);
            Console.Write("User ID: ");
            int userId = int.Parse(Console.ReadLine());

            ShowHardware(service);
            Console.Write("Hardware ID: ");
            int hardwareId = int.Parse(Console.ReadLine());

            Console.Write("Na ile dni: ");
            int days = int.Parse(Console.ReadLine());

            service.BorrowHardware(userId, hardwareId, days);

            Console.WriteLine("Wypożyczono sprzęt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }

    static void ReturnHardware(RentalService service)
    {
        try
        {
            ShowHardware(service);
            Console.Write("Hardware ID: ");
            int hardwareId = int.Parse(Console.ReadLine());

            service.ReturnHardware(hardwareId);

            Console.WriteLine("Zwrócono sprzęt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }

    static void ShowUsers(RentalService service)
    {
        Console.WriteLine("\n=== Użytkownicy ===");

        foreach (var u in service.GetUsers())
        {
            Console.WriteLine($"ID: {u.Id} | {u.FirstName} {u.LastName}");
        }
    }

    static void ShowHardware(RentalService service)
    {
        Console.WriteLine("\n=== Sprzęt ===");

        foreach (var h in service.GetHardware())
        {
            Console.WriteLine($"ID: {h.Id} | {h.Name} | {(h.IsAvailable ? "Dostępny" : "Zajęty")}");
        }
    }
}