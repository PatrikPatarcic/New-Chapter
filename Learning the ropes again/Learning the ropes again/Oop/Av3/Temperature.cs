namespace Learning_the_ropes_again.Oop.Av3;

public class Temperature
{
    private const double KelvinOffset = 273.15;
    private double degreesCelsius;

    public Temperature(double degreesCelsius)
    {
        this.degreesCelsius = degreesCelsius;
    }

    public double DegreesCelsius => degreesCelsius;

    public static Temperature FromKelvin(double kelvins)
    {
        return new Temperature(kelvins - KelvinOffset);
    }

    public static void RunSimpleDemo()
    {
        Temperature temp = new Temperature(22.5);
        Helper.Print($"Temperature in Celsius: {temp.DegreesCelsius:F2} °C", ConsoleColor.Cyan);
        Temperature absoluteZero = Temperature.FromKelvin(0);
        Helper.Print($"Absolute zero in Celsius: {absoluteZero.DegreesCelsius:F2} °C", ConsoleColor.Cyan);

    }
}
