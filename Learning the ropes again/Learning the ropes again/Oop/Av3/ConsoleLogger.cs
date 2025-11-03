namespace Learning_the_ropes_again.Oop.Av3;

public static class ConsoleLogger
{
    public static void Log(string message)
    {
        Helper.Print($"[{DateTime.Now.ToString()}]: {message}");
    }
    public static void Log(string message, ConsoleColor color)
    {
        Helper.Print($"[{DateTime.Now.ToString()}]: {message}", color);
    }

    public static void ErrorLog(string message)
    {
        Log(message, ConsoleColor.Red);
    }

    public static void WarningLog(string message)
    {
        Log(message, ConsoleColor.Yellow);
    }

    public static void RunSimpleDemo()
    {
        Log("This is a standard log message.");
        WarningLog("This is a warning message.");
        ErrorLog("This is an error message.");
        Log("This is a colored log message in green.", ConsoleColor.Green);
    }
}
