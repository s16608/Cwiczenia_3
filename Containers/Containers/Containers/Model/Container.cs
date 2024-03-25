namespace Containers;

public abstract class Container
{
    private static int count = 1;

    public String Type { get; set; }

    public double CargoMass { get; set; }
    public int Height { get; set; }
    public double OwnWeight { get; set; }
    public int Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoad { get; set; }

    public Container(string type, double cargoMass, int height, double ownWeight, int depth, double maxLoad)
    {
        Type = type;
        CargoMass = cargoMass;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxLoad = maxLoad;
        SerialNumber = GenerateSerialNumber(type);
    }

    private string GenerateSerialNumber(String type)
    {
        return "KON-" + type + "-" + count++;
    }

    public void LoadCargo(double mass)
    {
        if (mass > MaxLoad)
        {
            throw new OverfillException("Cargo exceeds max load.");
        }
        CargoMass = mass;
        
        
    }

    public abstract void UnloadCargo();
    
    public override string ToString()
    {
        return $"Container Type: {this.GetType().Name}\n" +
               $"Serial Number: {SerialNumber}\n" +
               $"Cargo Mass (kg): {CargoMass}\n" +
               $"Own Weight (kg): {OwnWeight}\n" +
               $"Height (cm): {Height}\n" +
               $"Depth (cm): {Depth}\n" +
               $"Max Load (kg): {MaxLoad}";
    }
}