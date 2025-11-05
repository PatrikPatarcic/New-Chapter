using System.Runtime.CompilerServices;

namespace AV3;

class Footballer : Athlete
{
    Random generator;
    double scoreChance;

    public Footballer(string name, string surname, int age, double scoreChange)
        : base(name, surname, age)
    {
        this.scoreChance = scoreChange;
        generator = new Random();
    }

    public override bool WillScore() => generator.NextDouble() < scoreChance;

    public override void Train()
    {
        scoreChance += 0.01;
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