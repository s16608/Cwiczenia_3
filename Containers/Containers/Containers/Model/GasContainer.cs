namespace Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; } // Ciśnienie w atmosferach

    public GasContainer(ContainerType type, double cargoMass, int height, double ownWeight, int depth, double maxLoad, double preassure)
        : base(type,cargoMass, height, ownWeight, depth, maxLoad)
    {
        Pressure = preassure;
    }

    public void LoadCargo(int mass)
    {
        if (mass > MaxLoad)
        {
            SendHazardNotification($"Attempt to overload with {mass}kg in a {ContainerType.Liquid} container.");
            throw new OverfillException("Cargo exceeds max load.");
        }

        base.LoadCargo(mass);
    }

    public override void UnloadCargo()
    {
        
        CargoMass *= 0.05;
    }

    public void SendHazardNotification(string message)
    {
        Console.WriteLine($"Hazard Notification for container {SerialNumber}: {message}");
    }

}
