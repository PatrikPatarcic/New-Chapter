public static class Helper
{
    public static void PrintWord(string word, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(word);
        Console.ResetColor();
    }

    public static void Print(string message, ConsoleColor color)
    {
        PrintWord(message, color);
        Console.WriteLine();
    }

    public static void Print(string message)
    {
        Console.WriteLine(message);
    }

    public static string Format(int[] array)
    {
        return "[" + string.Join(", ", array) + "]";
    }
    public static string Format(int[] array, int num)
    {
        return "[" + string.Join(", ", array.Take(num)) + "]";
    }
}