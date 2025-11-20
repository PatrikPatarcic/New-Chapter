using System.Runtime.InteropServices;

namespace AV4;

// go through example 2.4.

internal class Program
{
    static void Main(string[] args)
    {
        IFilter filter = new PositiveFilter();
        int[] numbers = [1, 2, 3, -4, 0, 5];
        Console.WriteLine(Statistics.CountValidValues(numbers, filter));

        filter = new PrimeFilter();
        Console.WriteLine(Statistics.CountValidValues(numbers, filter));

        MyPorgram(new ConsoleLogger());
        MyPorgram(new FileLogger("file.txt"));

        MyShopping();
    }

    static void MyPorgram(ILogger logger)
    {
        Console.WriteLine("Hello");
        logger.LogInfo("My program is running");
        logger.LogError("Error message");
    }

    static void MyShopping()
    {
        Cart cart = new Cart(new PercentageDiscount(0.10m));
        cart.Add(new Product("Mouse", 1, 100m));
        cart.Add(new Product("Usb drive", 1, 10m));
        ILogger logger = new ConsoleLogger();
        logger.LogInfo($"Shopping: {cart.CalculateTotal()}");
        cart.SetDiscount(new CouponDiscount(100));
        logger.LogInfo($"Shopping: {cart.CalculateTotal()}");
    }
}

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }


    public void Add() => Quantity++;

    public void Remove() => Math.Max(0, Quantity - 1);

    public decimal CalculateTotal() => Price * Quantity;
}

interface IDiscount
{
    decimal CalculateDiscountedPrice(decimal price);
}

class PercentageDiscount : IDiscount
{
    decimal percent;

    public PercentageDiscount(decimal percent)
    {
        this.percent = Math.Clamp(percent, 0.0m, 1.0m);
    }

    public decimal CalculateDiscountedPrice(decimal price) => price * (1 - percent);
}

class CouponDiscount : IDiscount
{
    public decimal Amount { get; private set; }
    public CouponDiscount(decimal amount)
    {
        Amount = amount;
    }
    public decimal CalculateDiscountedPrice(decimal price)
    {
        return Math.Max(0.0m, price - Amount);
    }
}

class Cart
{
    List<Product> products;
    IDiscount discount;

    public Cart(List<Product> products, IDiscount discount)
    {
        this.products = products;
        this.discount = discount;
    }
    public Cart(IDiscount discount) : this(new List<Product>(), discount){ }

    public void SetDiscount(IDiscount discount) => this.discount = discount;

    public void Add(Product product) => this.products.Add(product);
    public void Remove(Product product) => this.products.Remove(product);

    public decimal CalculateTotal()
    {
        decimal total = 0.0m;
        foreach(Product product in products)
        {
            total += product.CalculateTotal();
        }
        return discount.CalculateDiscountedPrice(total);
    }
}

class ConsoleLogger : ILogger
{
    private ConsoleColor errorColor = ConsoleColor.Red;
    private ConsoleColor infoColor = ConsoleColor.Green;
    public void LogError(string message) => Log(message, errorColor);

    public void LogInfo(string message) => Log(message, infoColor);

    private void Log(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

// SINGLE RESPONSIBILITY

class FileLogger : ILogger
{
    string filename;

    public FileLogger(string filename) => this.filename = filename;

    public void LogError(string message) => Log(message, "ERROR");

    public void LogInfo(string message) => Log(message, "INFO");
    
    private void Log(string message, string annotation)
    {
        using (System.IO.StreamWriter writer =
            new System.IO.StreamWriter(filename, true))
        {
            writer.WriteLine($"{annotation} {DateTime.Now} {message}");
        }
    }
}

interface ILogger
{
    void LogInfo(string message);
    void LogError(string message);
}





static class Statistics
{
    public static int CountValidValues(int[] numbers, IFilter filter)
    {
        int validCount = 0;

        foreach(int number in numbers)
        {
            if(filter.IsValid(number))
                validCount++;
        }

        return validCount;
    }
}

interface IFilter // sve unutar je javno i abstraktno, u pravilu samo 
{
    bool IsValid(int number);
}

class PositiveFilter : IFilter
{
    public bool IsValid(int number) => number > 0;
}

class PrimeFilter : IFilter
{
    public bool IsValid(int number)
    {

        if (number < 2) return false;
        for(int i = 2; i <= Math.Sqrt(number); i++)
        {
            if(number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}