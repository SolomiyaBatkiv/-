using System;
using System.Collections.Generic;
using System.Linq;

public interface ISwimmable
{
    void Swim();
}

public interface IFlyable
{
    int MaxHeight { get; }
    void Fly();
}

public interface IRunnable
{
    int MaxSpeed { get; }
    void Run();
}

public interface IAnimal
{
    int LifeDuration { get; }
    void Voice();
    void ShowInfo();
}

public class Cat : IAnimal, IRunnable
{
    public int MaxSpeed { get; } = 50; // example value
    public int LifeDuration { get; } = 15; // example value

    public void Run()
    {
        Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }

    public void Voice()
    {
        Console.WriteLine("Meow!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am a Cat and I live approximately {LifeDuration} years.");
    }
}

public class Eagle : IAnimal, IFlyable
{
    public int MaxHeight { get; } = 1000; // example value
    public int LifeDuration { get; } = 20; // example value

    public void Fly()
    {
        Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }

    public void Voice()
    {
        Console.WriteLine("No voice!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am an Eagle and I live approximately {LifeDuration} years.");
    }
}

public class Shark : IAnimal, ISwimmable
{
    public int LifeDuration { get; } = 25; // example value

    public void Swim()
    {
        Console.WriteLine("I can swim!");
    }

    public void Voice()
    {
        Console.WriteLine("No voice!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am a Shark and I live approximately {LifeDuration} years.");
    }
}

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

public class Program
{
    public static void Main()
    {
        var products = new List<Product>();
        products.Add(new Product { Name = "SmartTV", Price = 400, Category = "Electronics" });
        products.Add(new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" });
        products.Add(new Product { Name = "Iphone", Price = 700, Category = "Electronics" });
        products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
        products.Add(new Product { Name = "Banana", Price = 3, Category = "Fruits" });
        ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);
        TotalPrice(lookup);
        Console.ReadKey();
    }

    public static void TotalPrice(ILookup<string, Product> lookup)
    {
        foreach (var categoryGroup in lookup)
        {
            double totalPriceForCategory = categoryGroup.Sum(product => product.Price);
            Console.WriteLine($"{categoryGroup.Key} Total Price: {totalPriceForCategory}");
            foreach (var product in categoryGroup)

            {
                Console.WriteLine($"{product.Name} {product.Price}");
            }
            Console.WriteLine();
        }
    }
}