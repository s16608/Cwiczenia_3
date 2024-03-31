namespace Containers;

public class Program
{
    public static void Main(string[] args)
    {
        
        Container liquidContainer = new LiquidContainer(ContainerType.Liquid,0, 200, 500, 500, 10000,false);
        Container gasContainer = new GasContainer(ContainerType.Gas, 0, 300, 600, 700, 15000, 10);
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(ContainerType.Cool, 0, 600, 300, 600, 5000, "Bananas", 13.3);

        liquidContainer.LoadCargo(8000);
        gasContainer.LoadCargo(12000);
        refrigeratedContainer.LoadCargo(4000, "Bananas", 13.3);

        List<Container> containersList = new List<Container>();
        
        containersList.Add(liquidContainer);
        containersList.Add(gasContainer);
        containersList.Add(refrigeratedContainer);
        
        ContainerShip ship = new ContainerShip(20, 10, 200);

        ContainerShip ship2 = new ContainerShip(20, 10, 200);

        ship.AddContainers(containersList);
        
        ship.PrintShipInfo();

        ship.RemoveContainer("KON-L-1");
        
        Console.WriteLine("-----");
        
        ship.PrintShipInfo();

        refrigeratedContainer.UnloadCargo();

        RefrigeratedContainer refrigeratedContainer2 = new RefrigeratedContainer(ContainerType.Cool, 0, 600, 300, 600, 5000, "Cocolate", 18);

        Console.WriteLine("-----");
        
        Console.WriteLine(refrigeratedContainer2.ToString());
        
        ship.ReplaceContainer("KON-C-3", refrigeratedContainer2);
        
        Console.WriteLine("-----");
        Console.WriteLine("Aktualna lista kontenerów na statky");
        ship.PrintShipInfo();
        
        ContainerShip.TransferContainer(ship, ship2, "KON-C-4");
        
        Console.WriteLine("Aktualna lista kontenerów na statkach po transferze");
        ship.PrintShipInfo();
        Console.WriteLine("Drugi statek");
        ship2.PrintShipInfo();
    }
}