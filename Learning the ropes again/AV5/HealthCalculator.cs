namespace First;

//class Complex { }

class HealthCalculator
{
    public double CalculateBMI(double heightM, double weightKg) => weightKg / (heightM * heightM);
}
