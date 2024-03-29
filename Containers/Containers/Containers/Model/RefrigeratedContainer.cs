namespace Containers;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; private set; }
    public double MaintainedTemperature { get; private set; }

    public RefrigeratedContainer(ContainerType type, double cargoMass, int height, double ownWeight, int depth, double maxLoad, string productType, double maintainedTemperature)
        : base(type,cargoMass, height, ownWeight, depth, maxLoad)
    {
        ProductType = productType;
        MaintainedTemperature = maintainedTemperature;
    }

    public void LoadCargo(double mass, string productType, double temperature)
    {
        if (productType != ProductType)
        {
            throw new InvalidOperationException("Cannot load a different product type into this container.");
        }

        if (temperature > MaintainedTemperature)
        {
            throw new InvalidOperationException("The temperature for the product is too low for this container.");
        }

        base.LoadCargo(mass);
    }

    public override void UnloadCargo()
    {
        CargoMass = 0;
    }
}
