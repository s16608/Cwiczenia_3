namespace Containers;

using System;
using System.Collections.Generic;

public class ContainerShip
{
    public List<Container> Containers { get; private set; }
    public int MaxSpeed { get; private set; }
    public int MaxContainerCapacity { get; private set; }
    public double MaxWeight { get; private set; } // Maksymalna waga w tonach

    public ContainerShip(int maxSpeed, int maxContainerCapacity, double maxWeight)
    {
        Containers = new List<Container>();
        MaxSpeed = maxSpeed;
        MaxContainerCapacity = maxContainerCapacity;
        MaxWeight = maxWeight;
    }

    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCapacity)
        {
            throw new InvalidOperationException("Cannot add more containers: capacity reached.");
        }
        
        if (GetCurrentTotalWeight() + container.CargoMass + container.OwnWeight > MaxWeight * 1000)
        {
            throw new InvalidOperationException("Cannot add container: weight limit exceeded.");
        }
        
        Containers.Add(container);
    }

    public void AddContainers(List<Container> containersToAdd)
    {
        if (Containers.Count + containersToAdd.Count > MaxContainerCapacity)
        {
            throw new InvalidOperationException("Cannot add more containers: capacity reached.");
        }
    
        double totalWeightToAdd = containersToAdd.Sum(container => container.CargoMass + container.OwnWeight);
        if (GetCurrentTotalWeight() + totalWeightToAdd > MaxWeight * 1000)
        {
            throw new InvalidOperationException("Cannot add containers: weight limit exceeded.");
        }
        
        foreach (var container in containersToAdd)
        {
            Containers.Add(container);
        }
    }


    public bool RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        
        if (container != null)
        {
            return Containers.Remove(container);
        }
        return false;
    }

    private double GetCurrentTotalWeight()
    {
        return Containers.Sum(c => c.CargoMass + c.OwnWeight); // kg
    }
    
    public void LoadContainers(List<Container> containersToLoad)
    {
        foreach (var container in containersToLoad)
        {
            AddContainer(container);
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var containerToReplace = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (containerToReplace != null)
        {
            Containers.Remove(containerToReplace);
            AddContainer(newContainer);
        }
        else
        {
            throw new InvalidOperationException("Container with the given serial number does not exist.");
        }
    }

    
    public static void TransferContainer(ContainerShip fromShip, ContainerShip toShip, string serialNumber)
    {
        var container = fromShip.Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        
        if (container != null)
        {
            fromShip.RemoveContainer(serialNumber);
            toShip.AddContainer(container);
        }
        else
        {
            throw new InvalidOperationException("Container with the given serial number does not exist on the source ship.");
        }
    }

    public void PrintContainerInfo(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Console.WriteLine(container);
        }
        else
        {
            Console.WriteLine("Container not found.");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship max speed: {MaxSpeed} knots, max capacity: {MaxContainerCapacity} containers, current load: {GetCurrentTotalWeight() / 1000} tons.");
        foreach (var container in Containers)
        {
            Console.WriteLine(container);
        }
    }
}