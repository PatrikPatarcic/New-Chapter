public class Sort_n_Find
{
    private static void Gen_arr(float[] V, int n, int dg, int gg)
    {
        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            V[i] = (float)(rand.Next(dg, gg));
        }
    }

    private static void Print_arr(float[] V, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{V[i]:F2} ");
        }
        Console.WriteLine();
    }

    private static void Search_arr(float[] V, int n, float x)
    {
        for (int i = 0; i < n; i++)
        {
            if (V[i] == x)
            {
                Console.WriteLine($"Found {x:F2} at index {i}");
                return;
            }
        }
        Console.WriteLine($"{x:F2} not found in the array");
    }
    private static void Binary_search(float[] V, int n, float x)
    {
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (V[mid] == x)
            {
                Console.WriteLine($"Found {x:F2} at index {mid}");
                return;
            }
            if (V[mid] < x)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        Console.WriteLine($"{x:F2} not found in the array");
    }

    public static void Main3(string[] args)
    {
        int n = 20000000;
        float[] V = new float[n];
        int dg = 10;
        int gg = 100;

        Gen_arr(V, n, dg, gg);
        //Print_arr(V, n);
        float x = V[new Random().Next(0, n)]; // Randomly select an element to search for

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        Search_arr(V, n, x);

        stopwatch.Stop();
        Console.WriteLine($"Searching took {stopwatch.ElapsedMilliseconds} ms");

        stopwatch = System.Diagnostics.Stopwatch.StartNew();
        
        Array.Sort(V);

        stopwatch.Stop();
        Console.WriteLine($"Sorting took {stopwatch.ElapsedMilliseconds} ms");

        stopwatch = System.Diagnostics.Stopwatch.StartNew();

        Binary_search(V, n, x);

        stopwatch.Stop();
        Console.WriteLine($"Binary search took {stopwatch.ElapsedMilliseconds} ms");

    }
}