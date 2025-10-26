public static class Helper
{
    public static void Print<T>(T message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void Print<T>(T message)
    {
        Console.WriteLine(message);
    }
}