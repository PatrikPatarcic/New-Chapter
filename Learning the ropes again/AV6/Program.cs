using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AV6;

internal class Program
{
    static void Main(string[] args)
    {
        //Demo();
        Demo2();
    }

    static void Demo()
    {
        // only unique names will be stored in the HashSet
        // for hashset, equals and gethashcode methods are used to determine uniqueness
        HashSet<string> names = new HashSet<string>()
        {
            "Bruno", "Ana", "Marija"
        };
        names.Add("Bruno");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("\n\n");
        HashSet<string> additionalNames = new HashSet<string>();
        additionalNames.Add("Luka");
        additionalNames.Add("Ana");
        names.IntersectWith(additionalNames); // Interesect only returns doesn't change original set


        foreach (var name in names) // var can be used in local variable declaration when the type is obvious from the right side
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n\nUnion:\n");
        var c = names.Union(additionalNames); // Union returns a new IEnumerable with all unique elements from both sets
        foreach (var name in c)
        {
            Console.WriteLine(name);
        }

        // Key needs to be unique; it needs to have equals and gethashcode methods implemented properly
        Dictionary<string, int> numbers = new Dictionary<string, int>()
        {
            {"Carobni", 42 },
            {"Greska", 404}
        };

        // numbers.Add("Greska", 400); // throws exception because key already exists
        numbers["Sto"] = 100;
        Console.WriteLine("\n\nNumbers:\n");
        foreach (var kvp in numbers)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }

        Dog dog = new Dog("Rex", 3, "German sherper");

        Shelter shelter = new Shelter();
        shelter.Add(dog);
        shelter.Add(new Dog("Luna", 2, "Labrador"));
        Console.WriteLine("\n\nShelter dogs:\n");
        Console.WriteLine(shelter);
    }
    static void Demo2()
    {
        //Transformer squareDelegate = Utilities.Square; // can add more functions to the delegate chain using +=
        Func<int, int> squareDelegate = Utilities.Square;
        Func<int, int> negativeDelegate = Utilities.Negative;
        Func<int, int> incrementDelegate = Utilities.Increment;

        Func<int, int> a = x => -x; // lambda expression, annonymous function

        Func<int, int> combinedDelegate = squareDelegate + negativeDelegate; // doesn't work with Func, works with custom delegates, but Func can be combined using other ways like in Transform method
        // when combined, only the last return value is returned
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        List<int> squaredNumbers = Utilities.Transform(numbers, a);
        Console.WriteLine(string.Join(", ", squaredNumbers));

        IEnumerable<int> squaredNumbers2 = numbers.Select(x => x * x); // using LINQ
        IGrouping<int, int> groupedNumbers = numbers.GroupBy(x => x % 2).First(); // grouping by even and odd
        IComparable<int> comparable = 5; // int implements IComparable<int>
    }
    static void Demo3()
    {

    }
}

class Shelter
{
    Dictionary<string, Dog> dogs;

    public Shelter()
    {
        dogs = new Dictionary<string, Dog>();
    }

    public void Add(Dog dog)
    {
        if(!dogs.ContainsKey(dog.Name))
        {
            dogs[dog.Name] = dog;
        }
    }

    public Dog Adopt(string name)
    {
        if(!dogs.ContainsKey(name))
        {
            throw new ArgumentException("No such dog");
        }
        Dog d = dogs[name];
        dogs.Remove(name);
        return d;
    }
    
    public override string ToString() => string.Join("\n", dogs.Values);
    
    public Shelter(Shelter other)
    {
        this.dogs = new Dictionary<string, Dog>();
        foreach (var item in dogs)
        {
            //this.dogs.Add(item.Key, item.Value); // shallow copy

            Dog dogCopy = new Dog(item.Value.Name, item.Value.Age, item.Value.Breed);
            this.dogs.Add(item.Key, dogCopy); // deep copy

            Dog dogCopy2 = new Dog(item.Value); // using copy constructor
            this.dogs.Add(item.Key, dogCopy2); // deep copy
        }
    }

    // Adopt random dog
    // IsEmpty
    // dogs.Keys, dogs.Values
    // Count
}
class Dog
{
    string name;
    int age;
    string breed;

    public Dog(string name, int age, string breed)
    {
        this.name = name;
        this.age = age;
        this.breed = breed;
    }

    public Dog(Dog other)
    {
        this.name = other.name;
        this.age = other.age;
        this.breed = other.breed;
    }

    public string Name { get { return name; } }
    public int Age { get { return age; } }
    public string Breed { get { return breed; } }

    public override string ToString()
    {
        return $"Dog(Name: {name}, Age: {age}, Breed: {breed})";
    }
}

// 1.2 task

//

delegate int Transformer(int input);

static class Utilities
{
    public static List<int> Transform(List<int> numbers,
        Func<int, int> transformer) // using Func delegate from System namespace, no need to define custom delegate
    {
        List<int> transformedNumbers = new List<int>();
        foreach(int number in numbers)
        {
            transformedNumbers.Add(transformer(number));
        }

        return transformedNumbers;
    }
    /*public static List<int> Transform(List<int> numbers,
        Transformer transformer)
    {
        List<int> transformedNumbers = new List<int>();
        foreach (int number in numbers)
        {
            transformedNumbers.Add(transformer(number));
        }

        return transformedNumbers;
    }*/
    public static int Square(int value) => value * value;
    public static int Negative(int value) => -value;
    public static int Increment(int value) => value + 1;
}

interface ITransformer
{
    int Transform(int input);
}

class SquareTransformer : ITransformer
{
    public int Transform(int input)
    {
        return input * input;
    }
}


class Beer : IEqualityComparer<Beer>
{
    public string Name { get; set; }
    public double AlcoholPercentage { get; set; }
    public bool Equals(Beer? x, Beer? y)
    {
        if (x == null || y == null)
            return false;
        return x.Name == y.Name && x.AlcoholPercentage == y.AlcoholPercentage;
    }
    public int GetHashCode(Beer obj)
    {
        return HashCode.Combine(obj.Name, obj.AlcoholPercentage);
    }
}