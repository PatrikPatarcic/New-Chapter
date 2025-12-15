namespace First;
using Second;
using Second.Third; // moramo i ugnježđeni namespace specificirati da bi koristili što je unutra
using System.ComponentModel;
using System.Xml;

// 

// Imenici, iznimke, generički tipovi
internal class Program
{
    static void Main(string[] args)
    {
        //Complex complex = new Complex(); // dolazi iz First
        //Second.Complex complex2 = new Second.Complex(); // dolazi iz Second

        Complex complex = new Complex(); // dolazi iz Second

        Sub sub = new Sub(); // dolazi iz Second.Third, moramo specificirati using Third da bi radilo

        // Iznimke

        // zaseban mehanizam koji govori o pogreškama u programu
        // odvojen je od strukture podataka

        // primjer izračuna BMI s hvatanjem iznimki, korisnik unosi visinu i težinu
        // ako korisnik unese neispravan format broja, baca se iznimka FormatException
        /*
        while (true)
        {

            try
            {
                Console.WriteLine("Unesite visinu u metrima: ");
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("Unesite težinu u kilogramima: ");
                double weight = double.Parse(Console.ReadLine());
                HealthCalculator calculator = new HealthCalculator();
                double bmi = calculator.CalculateBMI(height, weight);
                Console.WriteLine($"Vaš BMI je: {bmi}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Neispravan format broja za visinu.");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo je do pogreške: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Još netko?\n");
            }
        */
        //Console.WriteLine("Kraj programa.");


        // Koristiti catch blokove za hvatanje iznimki i rukovanje njima u mainu, nećemo u funkcijama
        // jer da ne bi morali svaki put hvatati iznimke kad pozivamo funkciju, već samo na jednom mjestu - u mainu
        // side note: uglavnom se u dokumentaciji navodi koje iznimke funkcija može baciti, ako koristimo 
        // neku sustavsku funkciju ili biblioteku, trebamo znati koje iznimke može baciti da bi ih mogli hvatati
        /*
        try
        {
            Stack<int> stack = new Stack<int>(5); // generic stack
            Stack<string> stackOfWords = new Stack<string>(5);
            for (int i = 0; i < 6; i++)
            {
                stack.Push(i);
            }
            for (int i = 0; i < 10; i++)
            {
                stack.Pop();
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (StackUnderflowException ex)  // naša prilagođena iznimka
        {
            Console.WriteLine(ex.Message);
        }
        */
        int[] data = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine(string.Join(", ", data));
        Utilites.Reverse(data);  // iako je reverse generička funkcija, on sam zaključuje tip T iz tipa argumenta koji prosljeđujemo
        Console.WriteLine(string.Join(", ", data));

        string[] words= new string[] { "jedan", "dva", "tri", "dav"};
        Console.WriteLine(string.Join(", ", data));
        Utilites.Reverse(data);
        Console.WriteLine(string.Join(", ", data));

        Console.WriteLine("Min je (data): " + Utilites.FindMin(data));  // ista stvar kao i kod reverse, T se zaključuje iz tipa argumenta
        Console.WriteLine("Min je (words): " + Utilites.FindMin(words));


        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.Add(10);
        linkedList.Add(20);
        linkedList.Add(30);
        linkedList.PrintAll();

        linkedList.AddAtEnd(5);
        linkedList.AddAtPosition(2, 15);
        Console.WriteLine("\n\n");
        linkedList.PrintAll();
    }
}



internal class LinkedList<T> where T : IComparable<T>
{
    private Node<T>? head;
    public LinkedList(Node<T>? head)
    {
        this.head = head;
    }

    public LinkedList() : this(null) { }

    public void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);
        newNode.Next = this.head;
        this.head = newNode;
    }
    public void AddAtEnd(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if(head == null) 
        {
            head = newNode;
            return;
        }
        Node<T> current = head;
        while(current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }
    public void AddAtPosition(int position, T value)
    {
        if(head == null)
        {
            head = new Node<T>(value);
            return;
        }
        if (position <= 0)
        {
            Add(value);
            return;
        } else if(position >= Size())
        {
            AddAtEnd(value);
            return;
        }
        Node<T>? current = head;
        Node<T>? previous = null;
        int count = 1;
        while(count < position)
        {
            previous = current;
            current = current.Next;
            count++;
        }
        Node<T> newNode = new Node<T>(value);
        newNode.Next = current;
        previous.Next = newNode;
    }
    public void PrintAll()
    {
        Node<T>? current = head;
        while (current != null)
        {
            Console.WriteLine(string.Format("{0}", current.Data));
            current = current.Next;
        }
    }
    public Node<T>? Find(T data)
    {
        Node<T>? current = head;
        while (current != null)
        {
            if (current.Data == null ? data == null : current.Data.Equals(data))
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }
    public Node<T>? Remove(T data)
    {
        Node<T>? current = head;
        Node<T>? previous = null;
        while (current != null)
        {
            if (current.Data == null ? data == null : current.Data.Equals(data))
            {
                if (previous == null)
                {
                    head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                return current;
            }
            previous = current;
            current = current.Next;
        }
        return null;
    }
    public int Size()
    {
        int count = 0;
        Node<T>? current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public bool IsEmpty() => head == null;
    public void Clear() => head = null;

    public class Node<K>(K data, Node<K>? next)
    {
        public K Data { get; set; } = data;
        public Node<K>? Next { get; set; } = next;

        public Node(K data) : this(data, null) { }
    }
}