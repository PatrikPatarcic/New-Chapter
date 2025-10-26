public class MonthlyPrecipitation
{
    public int Days { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    private double[] precipications;

    public MonthlyPrecipitation(int year, int month, int days)
    {
        Year = year;
        Month = month;
        Days = days;
        precipications = new double[Days];
    }

    public MonthlyPrecipitation(int year, int month, double[] precipications) : this(year, month, precipications.Length)
    {
        Array.Copy(precipications, this.precipications, precipications.Length);
    }

    public void StorePrecipitationForDay(double precipication, int day)
    {
        precipications[day - 1] = precipication;
    }

    public double GetPrecipitationForDay(int day)
    {
        return precipications[day - 1];
    }

    public double GetAveragePrecipitation()
    {
        double totalPercipication = 0;
        foreach (double percipication in precipications)
        {
            totalPercipication += percipication;
        }
        return totalPercipication / precipications.Length;
    }

    public static void RunSimpleDemo()
    {
        double[] precipitations = new double[] { 13.02, 14.55, 6.88, 0.00, 9.44 };
        MonthlyPrecipitation january = new MonthlyPrecipitation(2020, 1, precipitations);
        MonthlyPrecipitation february = new MonthlyPrecipitation(2020, 2, 29);

        string description = $"{february.Year}/{february.Month}/{february.Days}";
        double averagePercipitation = january.GetAveragePrecipitation();
        february.StorePrecipitationForDay(13.13, 25);
        double percipitation = february.GetPrecipitationForDay(25);

        Console.WriteLine($"In {description}, the average percipication in January was {averagePercipitation:F2} mm.");
        Console.WriteLine($"On 25th February, the percipication was {percipitation:F2} mm.");
    }
}