using Learning_the_ropes_again.Oop.Av1;

/** <summary> Create a class TempreatureCalculator with two static methods:  
 * 1.Average(Temperature t1, Temperature t2): Returns the average of two Temperature objects.
 * 2. Average(Temperature[] temps): Returns the average of an array of Temperature objects.</summary> 
    */
public class TempreatureCalculator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TempreatureCalculator"/> class.
    /// </summary>
    public TempreatureCalculator()
    {
    }

    /// <summary>
    /// Calculates the average temperature from two given temperature values.
    /// </summary>
    /// <param name="t1">The first temperature to include in the average calculation.</param>
    /// <param name="t2">The second temperature to include in the average calculation.</param>
    /// <returns>A <see cref="Temperature"/> object representing the average of the two input temperatures.</returns>
    public static Temperature Average(Temperature t1, Temperature t2)
    {
        return new Temperature((t1.Celsius + t2.Celsius) / 2);
    }

    /// <summary>
    /// Calculates the average temperature from an array of temperatures.
    /// </summary>
    /// <param name="temps">An array of <see cref="Temperature"/> objects representing the temperatures to average. Cannot be null or empty.</param>
    /// <returns>A <see cref="Temperature"/> object representing the average temperature of the input array.</returns>
    public static Temperature Average(Temperature[] temps)
    {
        float sum = 0;
        foreach (Temperature temp in temps)
        {
            sum += temp.Celsius;
        }
        return new Temperature(sum / temps.Length);
    }

    /// <summary>
    /// Serves as the entry point for the application, demonstrating the calculation of average temperatures.
    /// </summary>
    /// <remarks>This method creates instances of the <see cref="Temperature"/> class and uses the <see
    /// cref="TempreatureCalculator.Average"/> method to compute the average temperature of two <see
    /// cref="Temperature"/> objects and an array of <see cref="Temperature"/> objects. The results are printed to the
    /// console.</remarks>
    public static void RunDemo()
    {
        Temperature t1 = new Temperature(10);
        Temperature t2 = new Temperature(20);
        Temperature avgTwo = TempreatureCalculator.Average(t1, t2);
        System.Console.WriteLine($"Average of {t1.Celsius} and {t2.Celsius} is {avgTwo.Celsius}");
        Temperature[] temps = new Temperature[] { new Temperature(10), new Temperature(20), new Temperature(30) };
        Temperature avgArray = TempreatureCalculator.Average(temps);
        System.Console.WriteLine($"Average of array is {avgArray.Celsius}");
    }
}
