using System.Numerics;

namespace Learning_the_ropes_again.Oop.Av3;

public class Sentance
{
    string[] words;

    public Sentance(string sentance)
    {
        words = sentance.Split(' ');
    }

    public string this[int wordIndex]
    {
        get { return words[wordIndex]; }
        set { words[wordIndex] = value; }
    }

    public override string ToString()
    {
        return string.Join(' ', words);
    }

    public static void RunSimpleDemo()
    {
        Sentance sentance = new Sentance("Hello from the other side");
        Helper.Print($"Original sentance: {sentance}", ConsoleColor.Yellow);
        Helper.Print($"Word at index 2: {sentance[2]}", ConsoleColor.Cyan);
        sentance[2] = "another";
        Helper.Print($"Modified sentance: {sentance}", ConsoleColor.Yellow);
    }
}
