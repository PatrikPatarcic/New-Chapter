using System.Numerics;
namespace BigSum;
public class Day2
{
    public static void Main1(string[] args)
    {
        //Console.WriteLine("Hi hi, how ya quacking?");
        List<int> list = new List<int>();

        for (int i = 999; i >= 100; i--) {
            for(int j = 999; j >= 100; j--)
            {
                int multiple = i * j;
                int digit1 = multiple % 10;
                int digit2 = multiple % 100 / 10;
                int digit3 = multiple % 1000 / 100;
                if ((multiple/1000) == (digit3 + digit2*10 + digit1*100))
                    list.Add(multiple);
                //Console.WriteLine($"{i} * {j} = {i * j}");
            }
        }
        list.Sort();
        //Console.WriteLine($"The largest palindrome made from the product of two 3-digit numbers is: {list[list.Count - 1]}");
    
        for(int i = 20; ; i++)
        {
            if (i % 20 != 0 || i % 18 != 0 || i % 16 != 0 || i % 14 != 0 || i % 15 != 0 || i%19 != 0 || i%17 != 0 || i%13!=0 || i%11!=0)
            {
                continue;
            }
           // Console.WriteLine($"20: {i%20},18: {i % 18},16: {i % 16},14: {i % 14},12: {i % 12},10: {i % 10},8: {i % 8},6: {i % 6},4: {i % 4},2: {i % 2}");
           // Console.WriteLine("Smallest number divisible by numbers from 1 to 20 is: " + i);
            break;
        }

        int[] sumThenSquare = new int[100];
        int[] SquareThenSum = new int[100];

        for(int i = 1; i <= 100; i++)
        {
            sumThenSquare.SetValue(i, i - 1);
            SquareThenSum.SetValue(i * i, i - 1);
        }
        int sum1 = 0;
        int sum2 = 0;

        for (int i = 0; i < sumThenSquare.Length; i++)
        {
            sum1 += (int)sumThenSquare.GetValue(i);
            sum2 += (int)SquareThenSum.GetValue(i);
        }
        sum1 = sum1 * sum1;
        //Console.WriteLine($"The difference between the sum of the squares and the square of the sums is: {sum1 - sum2}");
        
        int counter = 0;
        int F = 1;

        for (int i = 2; ; ++i)
        {
            for (int j = 2; j < i; ++j)
            {
                if (i % j == 0)
                {
                    F = 0;
                    break;
                }
                F = 1;
            }
            if (counter == 10001)
            {
                //Console.WriteLine(counter);
                Console.WriteLine($"The 10,001st prime number is: {i-1}");
                return;
            }
            if (F == 1)
            {
                F = 0;
                counter++;
            }
        }
        //Prime number calculation done



    }
}
