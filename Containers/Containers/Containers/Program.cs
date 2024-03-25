namespace Containers;

public class Program
{
    public static void Main(string[] args)
    {

        ContainerShip ship = new ContainerShip(20, 10, 200);

        Container liquidContainer = new LiquidContainer("L",250, 2000, 500, 700, 10000, false);
        Container gasContainer = new GasContainer("G", 300, 1500, 400, 700, 15000, 10);
        Container refrigeratedContainer = new RefrigeratedContainer("C", 200, 1000, 300, 700, 5000, "Bananas", 13.3);
        Console.WriteLine(refrigeratedContainer.SerialNumber);

        
        ship.AddContainer(liquidContainer);
        ship.AddContainer(gasContainer);
        ship.AddContainer(refrigeratedContainer);

      
        List<Container> additionalContainers = new List<Container>();
        ship.LoadContainers(additionalContainers);

       
        ship.PrintContainerInfo("KON-C-3");

        ship.PrintShipInfo();
        
        Container replacementContainer = new RefrigeratedContainer("C",250, 1500, 350, 700, 6000, "Fish", 2);
        ship.ReplaceContainer("KON-C-3", replacementContainer);

        ship.RemoveContainer(liquidContainer);

        refrigeratedContainer.UnloadCargo();
    }
}