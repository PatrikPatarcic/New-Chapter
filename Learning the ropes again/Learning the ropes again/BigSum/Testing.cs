namespace BigSum;

public class Testing
{
    public static void Main2(string[] args)
    {
        long i = 0;
        long numberr = 720000L;
        long result = 0L;

        for (i = 1L; i < numberr; i++)
        {
            result += i * i % 2 == 1 ? i * i : 0;
            // System.Console.WriteLine(i * i % 2 == 1 ? i * i : 0);
        }

        //System.Console.WriteLine(numberr);

        //System.Console.WriteLine(result);


        // Multiples of 3 or 5 below 1000

        long SumOfMultiples = 0;

        for (int j = 1; j < 1000; j++)
        {
            if (j % 3 == 0 || j % 5 == 0)
            {
                SumOfMultiples += j;
            }
        }

        //System.Console.WriteLine(SumOfMultiples);

        // Even Fibonacci numbers below 4 million

        Testing T = new Testing();

        long EvenFiboSum = 0;

        long a = 0;

        long b = 1;

        while (b <= 4000000)
        {
            long next = a + b;
            a = b;
            b = next;
            if (a % 2 == 0)
            {
                EvenFiboSum += a;
            }
        }
        //System.Console.WriteLine(EvenFiboSum);

        // Largest prime factor of 600851475143

        long number = 600851475143;

        for (int j = 2; j <= number; j++)
        {
            if (number % j == 0)
            {
                number /= j;
                Console.WriteLine(number);
                Console.WriteLine(j);
            }
        }

    }
}