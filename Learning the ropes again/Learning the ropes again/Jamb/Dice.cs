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

    public int Sides { get  { return sides; }}
    public int Value{ get { return value; } }
    private void SetRolledNumber(int value)
    {
        this.value = Math.Clamp(value, 1, sides);
    }
    public void Roll()
    {
        SetRolledNumber(random.Next(1, sides +1));
    }

    
    public static void RunDemo()
    {
        Dice one = new Dice(); // Default 6 sided dice
        Dice two = new Dice(10, 22); // Value will be clamped to 10

        Helper.Print($"First dice with {one.Sides} sides rolled {one.Value}", ConsoleColor.Cyan);
        Helper.Print($"Second dice with {two.Sides} sides rolled {two.Value}", ConsoleColor.DarkGray);        
    }
}