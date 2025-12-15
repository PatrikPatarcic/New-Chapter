namespace First;

public static class Utilites
{
    public static void Reverse<T>(T[] data)
    {
        for (int i = 0; i < data.Length / 2; i++)
        {
            T current = data[i];
            data[i] = data[data.Length - 1 - i];
            data[data.Length - 1 - i] = current;
        }
    }

    public static T FindMin<T>(T[] data) where T : IComparable<T> // ograničavamo T da mora implementirati IComparable<T>
    {
        T min = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            //if (data[i] < min) // ne radi jer ne zna da T podržava <
            // jer T može biti bilo koja klasa ili struktura (npr. Complex koja nema definirano < )
            if (data[i].CompareTo(min) < 0)
            {
                min = data[i];
            }

        }
        return min;
    }

    public static double CalculateMatchPercentage<T>(T[] a, T[] b) where T : IComparable<T>
    {
        double matchCount = 0;
        int lenght = Math.Min(a.Length, b.Length);
        for (int i = 0; i < lenght; i++)
        {
            if (a[i].CompareTo(b[i]) == 0)
            {
                matchCount++;
            }
        }
        return (matchCount / lenght) * 100;
    }
}

