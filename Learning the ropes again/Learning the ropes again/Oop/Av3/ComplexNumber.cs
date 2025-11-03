using System.Numerics;

namespace Learning_the_ropes_again.Oop.Av3;

public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }
    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }
    public double Magnitude()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }
    public static double Distance(ComplexNumber a, ComplexNumber b)
    {
        double realDiff = a.Real - b.Real;
        double imaginaryDiff = a.Imaginary - b.Imaginary;
        return Math.Sqrt(realDiff * realDiff + imaginaryDiff * imaginaryDiff);
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static ComplexNumber operator +(ComplexNumber a)
    {
        return new ComplexNumber(a.Real, a.Imaginary);
    }

    public static ComplexNumber operator -(ComplexNumber a)
    {
        return new ComplexNumber(-a.Real, -a.Imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
    {
        return a.Real == b.Real && a.Imaginary == b.Imaginary;
    }

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
    {
        return !(a == b);
    }
    // Override GetHashCode and Equals for proper comparison in collections
    public override int GetHashCode()
    {
        return HashCode.Combine(Real, Imaginary);
    }
    public override bool Equals(object? obj)
    {
        if (obj is ComplexNumber other)
        {
            return this == other;
        }
        return false;
    }

    public static ComplexNumber operator ++(ComplexNumber a)
    {
        return new ComplexNumber(a.Real + 1, a.Imaginary + 1);
    }

    public static ComplexNumber operator --(ComplexNumber a)
    {
        return new ComplexNumber(a.Real - 1, a.Imaginary - 1);
    }

    public static explicit operator int(ComplexNumber a)
    {
        return (int)a.Real;
    }
    public static explicit operator double(ComplexNumber a)
    {
        return a.Real;
    }
    public static implicit operator ComplexNumber(int a)
    {
        return new ComplexNumber(a, 0);
    }

    public static void RunSimpleDemo()
    {
        ComplexNumber num1 = new ComplexNumber(3, 4);
        ComplexNumber num2 = new ComplexNumber(1, 2);
        Helper.Print($"Number 1: {num1}", ConsoleColor.Yellow);
        Helper.Print($"Number 2: {num2}", ConsoleColor.Yellow);
        ComplexNumber sum = num1 + num2;
        Helper.Print($"Sum: {sum}", ConsoleColor.Cyan);
        ComplexNumber difference = num1 - num2;
        Helper.Print($"Difference: {difference}", ConsoleColor.Cyan);
        double distance = ComplexNumber.Distance(num1, num2);
        Helper.Print($"Distance between Number 1 and Number 2: {distance}", ConsoleColor.Cyan);

        ComplexNumber num3 = new ComplexNumber(3, 4);

        Helper.Print($"Number1: {num1} == Number3: {num3}: {num1 == num3}", ConsoleColor.Cyan);
        Helper.Print($"{num1} == {num3}: {num1.Equals(num3)}", ConsoleColor.Cyan);

        Helper.Print($"Hashcode number1 {num1.GetHashCode()} : Hascode number3 {num3.GetHashCode()}", ConsoleColor.Cyan);

        Helper.Print($"Incrementing Number 1: {++num1}", ConsoleColor.Cyan);
        Helper.Print($"Incrementing Number 1: {++num1}", ConsoleColor.Cyan);

        int realPartAsInt = (int)num2;
        Helper.Print($"Real part of Number 2 ({num2.ToString()}) as int: {realPartAsInt}", ConsoleColor.Cyan);
        ComplexNumber fromInt = 5;
        Helper.Print($"Complex number from int 5: {fromInt}", ConsoleColor.Cyan);
    }
}
