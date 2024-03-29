namespace Containers;

public abstract class Container
{
    private static int count = 1;

    ContainerType Type { get; set; }

    public double CargoMass { get; set; } // masa ładunku w kg
    public int Height { get; set; }
    public double OwnWeight { get; set; } // waga własna (waga samego kontenera, w kg)
    public int Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoad { get; set; } // maksymalna ładowność kontenera w kg

    public Container(ContainerType type, double cargoMass, int height, double ownWeight, int depth, double maxLoad)
    {
        Type = type;
        CargoMass = cargoMass;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxLoad = maxLoad;
        SerialNumber = GenerateSerialNumber(type);
    }

    private string GenerateSerialNumber(ContainerType type)
    {
        string containerTypeAsString = type.ToString();
        char firstLetterOfType = containerTypeAsString[0];
        return "KON-" + firstLetterOfType + "-" + count++;
    }

    public virtual void LoadCargo(double mass)
    {
        if (mass + CargoMass > MaxLoad)
        {
            throw new OverfillException("Cargo exceeds max load.");
        }

        CargoMass += mass;
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