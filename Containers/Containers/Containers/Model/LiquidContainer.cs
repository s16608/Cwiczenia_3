namespace Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(ContainerType type, double cargoMass, int height, double ownWeight, int depth,
        double maxLoad, bool isHazardous)
        : base(type, cargoMass, height, ownWeight, depth, maxLoad)
    {
        IsHazardous = isHazardous;
    }


    public override void LoadCargo(double mass)
    {
        double allowedLoad = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (mass + CargoMass > allowedLoad)
        {
            SendHazardNotification("Attempt to exceed the maximum capacity of the container.");
            throw new OverfillException(
                $"Cannot load more than {(IsHazardous ? "50%" : "90%")} of max load for {(IsHazardous ? "hazardous" : "non-hazardous")} cargo.");
        }
        base.LoadCargo(mass);
    }

    public override void UnloadCargo()
    {
        CargoMass = 0;
    }

    public void SendHazardNotification(string message)
    {
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}