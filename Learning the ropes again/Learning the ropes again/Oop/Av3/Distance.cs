using System.ComponentModel;

namespace Learning_the_ropes_again.Oop.Av3;

/// <summary>
/// A little bit of unnecessary overkill, but a good exercise in static classes and methods.
/// Represents various distance metrics between two points in n-dimensional space.
/// </summary>
/// Reference: https://en.wikipedia.org/wiki/Distance
/// see also https://en.wikipedia.org/wiki/Metric_(mathematics)
/// keywords: Euklidean, Manhattan, Chebyshev, Minkowski, Hamming, Canberra, Bray-Curtis, Sorensen-Dice, Jaccard, Cosine, Pearson
/// note: All methods return -1 if the two input arrays are of different lengths.
/// and all methods assume the input arrays are non-null.
/// and all methods assume the input arrays contain integer values.
/// all methods assume the input arrays represent points in n-dimensional space.
/// some methods return int, some return double for more precision.
/// quick demo method included at the bottom.
public static class Distance
{
    public static int Euklidean(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        
        int distance = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            distance = (int)Math.Sqrt(Math.Pow(secondDot[i] - firstDot[i], 2));
        }
        return distance;
    }

    public static int Manhattan(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        int distance = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            distance += Math.Abs(secondDot[i] - firstDot[i]);
        }
        return distance;
    }

    public static int Chebyshev(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        int maxDistance = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            int currentDistance = Math.Abs(secondDot[i] - firstDot[i]);
            if (currentDistance > maxDistance)
                maxDistance = currentDistance;
        }
        return maxDistance;
    }

    public static double Minkowski(int[] firstDot, int[] secondDot, int p)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        double sum = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            sum += Math.Pow(Math.Abs(secondDot[i] - firstDot[i]), p);
        }
        return Math.Pow(sum, 1.0 / p);
    }

    public static double Hamming(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        int distance = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            if (firstDot[i] != secondDot[i])
                distance++;
        }
        return distance;
    }

    public static double Canberra(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        double distance = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            distance += Math.Abs(firstDot[i] - secondDot[i]) / (Math.Abs(firstDot[i]) + Math.Abs(secondDot[i]));
        }
        return distance;
    }

    public static double BrayCurtis(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        double sumNumerator = 0;
        double sumDenominator = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            sumNumerator += Math.Abs(firstDot[i] - secondDot[i]);
            sumDenominator += Math.Abs(firstDot[i] + secondDot[i]);
        }
        return (sumNumerator / sumDenominator);
    }

    public static double SorensenDice(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        double intersection = 0;
        double sum = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            intersection += Math.Min(firstDot[i], secondDot[i]);
            sum += firstDot[i] + secondDot[i];
        }
        return (1 - (2 * intersection / sum));
    }

    public static double Jaccard(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        double intersection = 0;
        double union = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            intersection += Math.Min(firstDot[i], secondDot[i]);
            union += Math.Max(firstDot[i], secondDot[i]);
        }
        return (1 - (intersection / union));
    }

    public static double Cosine(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        double dotProduct = 0;
        double magnitudeA = 0;
        double magnitudeB = 0;
        for (int i = 0; i < firstDot.Length; i++)
        {
            dotProduct += firstDot[i] * secondDot[i];
            magnitudeA += Math.Pow(firstDot[i], 2);
            magnitudeB += Math.Pow(secondDot[i], 2);
        }
        return (1 - (dotProduct / (Math.Sqrt(magnitudeA) * Math.Sqrt(magnitudeB))));
    }

    public static double Pearson(int[] firstDot, int[] secondDot)
    {
        if (firstDot.Length != secondDot.Length)
            return -1;
        double sumA = 0;
        double sumB = 0;
        double sumAB = 0;
        double sumASq = 0;
        double sumBSq = 0;
        int n = firstDot.Length;
        for (int i = 0; i < n; i++)
        {
            sumA += firstDot[i];
            sumB += secondDot[i];
            sumAB += firstDot[i] * secondDot[i];
            sumASq += Math.Pow(firstDot[i], 2);
            sumBSq += Math.Pow(secondDot[i], 2);
        }
        double numerator = n * sumAB - sumA * sumB;
        double denominator = Math.Sqrt((n * sumASq - Math.Pow(sumA, 2)) * (n * sumBSq - Math.Pow(sumB, 2)));
        if (denominator == 0)
            return 0;
        return 1 - (numerator / denominator);
    }

    public static void RunSimpleDemo()
    {
        int[] dotA = { 1, 2, 3 };
        int[] dotB = { 4, 5, 6 };

        int[] dotA2 = { 1, 0, 1, 0 };
        int[] dotB2 = { 0, 1, 0, 1 };

        int[] dotA3 = { 1, 2, 3, 4, 5, 6};
        int[] dotB3 = { 6, 5, 4, 3, 2, 1};

        int[] three = { 3, 3, 3, 3 };
        int[] four = { 4, 4, 4, 4 };

        Helper.Print($"-- Next -- ({Helper.Format(dotA)}, {Helper.Format(dotB)})", ConsoleColor.Yellow);
        Printer(dotA, dotB);
        Helper.Print($"-- Next -- ({Helper.Format(dotA2)}, {Helper.Format(dotB2)})", ConsoleColor.Yellow);
        Printer(dotA2, dotB2);
        Helper.Print($"-- Next -- ({Helper.Format(dotA3)}, {Helper.Format(dotB3)})", ConsoleColor.Yellow);
        Printer(dotA3, dotB3);
        Helper.Print($"-- Next -- ({Helper.Format(three)}, {Helper.Format(four)})", ConsoleColor.Yellow);
        Printer(three, four);
    }

    private static void Printer(int[] a, int[] b)
    {
        Helper.Print($"Euklidean Distance: {Euklidean(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Manhattan Distance: {Manhattan(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Chebyshev Distance: {Chebyshev(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Minkowski Distance (p=3): {Minkowski(a, b, 3)}", ConsoleColor.Cyan);
        Helper.Print($"Hamming Distance: {Hamming(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Canberra Distance: {Canberra(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Bray-Curtis Distance: {BrayCurtis(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Sorensen-Dice Distance: {SorensenDice(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Jaccard Distance: {Jaccard(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Cosine Distance: {Cosine(a, b)}", ConsoleColor.Cyan);
        Helper.Print($"Pearson Distance: {Pearson(a, b)}", ConsoleColor.Cyan);
    }
}
