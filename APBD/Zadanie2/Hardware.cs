namespace APBD.Zadanie2;

public class Hardware
{
    private static int idCounter = 1;

    public int Id { get; private set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    protected Hardware(string name)
    {
        Id = idCounter++;
        Name = name;
    }
}

public class Laptop : Hardware
{
    public int RamSizeGb { get; set; }
    public string ProcessorType { get; set; }


    public Laptop(string name, int ramSizeGb, string processorType) : base(name)
    {
        RamSizeGb = ramSizeGb;
        ProcessorType = processorType;
    }
}

public class Projektor : Hardware
{
    public int Lumens { get; set; }
    public bool IsFullHd { get; set; }

    public Projektor(string name, int lumens, bool isFullHd) : base(name)
    {
        Lumens = lumens;
        IsFullHd = isFullHd;
    }
}

public class Camera : Hardware
{
    public int ResolutionMp { get; set; }
    public bool HasVideo { get; set; }

    public Camera(string name, int resolutionMp, bool hasVideo) : base(name)
    {
        ResolutionMp = resolutionMp;
        HasVideo = hasVideo;
    }
    
}