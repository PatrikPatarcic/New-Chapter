namespace Jamb;

public class Dice
{
    int sides;
    int value;
    Random random;

    public Dice(int sides, int value, Random random)
    {
        this.sides = sides;
        this.value = Math.Clamp(value, 1, sides);
        this.random = random;
    }
    public Dice(int sides, int value)
    {
        this.sides = sides;
        this.value = Math.Clamp(value, 1, sides);
        random = new Random();
    }
    public Dice()
    {
        this.sides = 6;
        value = 1;
        random = new Random();
    }

    public int GetSidesCount()
    {
            return sides;

    }
    public int GetRolledNumber()
    {
        return value;
    }
    public void SetRolledNumber(int value)
    {
        this.value = Math.Clamp(value, 1, sides);
    }
    public int Roll()
    {
        value = random.Next(1, sides +1);
        return value;
    }

    public static void RunExperiment(Dice dice, int numberOfExperiments, int x)
    {
        if (x < 1 || x > dice.GetSidesCount())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Out of bounds, dice only has {dice.GetSidesCount()} sides");
            Console.ResetColor();
            return;
        }
        int count = 0;
        for(int i = 0; i < numberOfExperiments; i++)
        {
            if (dice.Roll() == x)
            {
                count++;
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Rolled {x} a total of {count} times in {numberOfExperiments} rolls.");
        Console.WriteLine($"Experimental probability: {100*(double)count / numberOfExperiments:F2}%");
        Console.ResetColor();
    }
    public static void RunDemo()
    {
        Dice one = new Dice();
        Dice two = new Dice(10, 22);

        Console.WriteLine($"First dice: {one.GetSidesCount()}, rolled {one.GetRolledNumber()}");
        Console.WriteLine($"Second dice: {two.GetSidesCount()}, rolled {two.GetRolledNumber()}");

        Console.WriteLine($"First dice rolled: {one.Roll()}");
        Console.WriteLine($"Second dice rolled: {two.Roll()}");
        Console.WriteLine($"First dice: {one.GetSidesCount()}, rolled {one.GetRolledNumber()}");
        Console.WriteLine($"Second dice: {two.GetSidesCount()}, rolled {two.GetRolledNumber()}");
    }
}