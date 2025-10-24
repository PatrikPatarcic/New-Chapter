using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BigSum;

public class Day3
{
    public static void testing(string[] args)
    {            
        long[] numbers = new long[1020];
        int i = 0;
        using (StreamReader reader = new StreamReader("VeryBigNumber.txt"))
        {
            while (!reader.EndOfStream)
            {
                int ch = reader.Read();

                if (ch >= '0' && ch <= '9')
                {
                    numbers[i] = numbers[i] + (ch - '0');
                    i++;
                }
            }
        }
        long newProduct = 1, maxProduct = 1;
        for (i = 0; i < 1000-13; i++)
        {
            for(long j = i; j < i+13; j++)
            {
                Console.Write($"{j} * ");
                newProduct *= numbers[j];
            }
            Console.Write($" = {newProduct}");
            Console.WriteLine();
            if (maxProduct < newProduct)
            {
                maxProduct = newProduct;
            }
            newProduct = 1;
        }
        Console.WriteLine();
        Console.WriteLine(maxProduct);
    }
}