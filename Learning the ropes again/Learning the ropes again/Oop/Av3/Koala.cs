namespace Learning_the_ropes_again.Oop.Av3;

public class Koala
{
    public static int TotalKoalasBorn = 0;
    public static readonly int EndangeredCount = 50;

    private int SerialNo;

    public Koala()
    {
        SerialNo = TotalKoalasBorn;
        TotalKoalasBorn++;
    }

    public int SerialNunmber => SerialNo;

    public static void RunSimpleDemo()
    {
        Koala koala = new Koala();
        System.Console.WriteLine($"Koala Serial Number: {koala.SerialNunmber}");
        System.Console.WriteLine($"Koala endangered count: {EndangeredCount}");
        Koala babyKoala = new Koala();
        System.Console.WriteLine($"Baby koala serial number: {babyKoala.SerialNunmber}");
    }
}