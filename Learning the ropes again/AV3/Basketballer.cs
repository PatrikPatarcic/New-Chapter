namespace AV3;

class Basketballer : Athlete
{
    Random generator;
    double freeThrowChance;

    public Basketballer(string name, string surname, int age, double freeThrowChance) : base(name, surname, age)
    {
        this.freeThrowChance = freeThrowChance;
        this.generator = new Random();
    }
    public override bool WillScore()
    {
        return generator.NextDouble() < freeThrowChance;
    }

    public override void Train()
    {
        double gain = 0.01 + generator.NextDouble() * (0.05 - 0.01);
        this.freeThrowChance += gain;
    }
}

// Specifikacija i generalizacija
// First solve the problem, then code it
// is-a and has
// 
// Primjer polimorfizma
/*
 * Charachter[] fellowship = new[] {
 *  .
 *  .
 *  .
 *  .
 * }
 * Balrog balrog = new Balrog();
 * foreach(Charachter c in fellowship){
 * balrog.TakeDamage(c.Attack());
 * }
 * 
 * */