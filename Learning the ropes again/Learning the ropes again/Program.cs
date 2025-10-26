using Jamb;


internal class Program
{
    static void Main(string[] args)
    {
        Experimenting();
    
        
    }
    public static void Experimenting()
    {
        //Human H = new Human("001");

        //Testing.Main2(args);

        //Sort_n_Find.Main3(args);

        // Learning_the_ropes_again.Oop.Av2.Program.main();

        //BigSum.Day3.testing(args);

        //Dice.RunDemo();

        //RunExperiment(new Dice(6, 1), 100, 4);

        Learning_the_ropes_again.Oop.Av2.Program.main();
    }
    public static void RunExperiment(Dice dice, int numberOfMatchedValue, int desiredValue)
    {
        if (desiredValue < 1 || desiredValue > dice.Sides)
        {
            if (desiredValue < 1)
                Helper.Print("Out of bounds, desired value cannot be less than 1", ConsoleColor.Red);
            else
                Helper.Print($"Out of bounds, dice only has {dice.Sides} sides", ConsoleColor.Red);
            return;
        }
        int match = 0, i;
        for (i = 0; match < numberOfMatchedValue; i++)
        {
            dice.Roll();
            //Helper.Print($"Rolled {dice.Value} on a {dice.Sides} sided dice", ConsoleColor.Yellow);
            if (dice.Value == desiredValue)
            {
                match++;
            }
        }

        Helper.Print($"Experiment details: {100 * (float)match / i:F2}% of rolls landed " +
            $"on desired value ({desiredValue})\nTotal rolls: {i}", ConsoleColor.Green);
    }
}
