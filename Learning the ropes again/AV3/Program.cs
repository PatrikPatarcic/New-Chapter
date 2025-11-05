using System.Reflection.PortableExecutable;

namespace AV3;

public class Program
{
    static void Main(string[] args)
    {
        Charachter hero = new Charachter();
        /*
        Console.WriteLine(hero.GetAsString);
        Console.WriteLine(hero.Attack());

        Archer archer = new Archer();
        Console.WriteLine(archer.GetAsString);
        Console.WriteLine(archer.Attack());

        archer.Hide();

        Console.WriteLine(archer.Attack());
        Console.WriteLine(hero.Attack());*/

        Charachter archer = new Archer("Archer", 100, true);
        Console.WriteLine(archer.Attack());

        Enemy balrog = new Enemy();
        balrog.GetAttacked(archer);
        Console.WriteLine(balrog.GetAsString());
        balrog.GetAttacked(hero);
        Console.WriteLine(balrog.GetAsString());

        Charachter pointerToArcher = archer; // Implicitna konverzija iz archera u charachter
        //Archer pointerToCharachter = hero; // !!
        Archer pointerToCharachter = (Archer)pointerToArcher; // Promijeni pokazivač na archer klasu
        pointerToCharachter.Hide();

        Athlete[] team = new Athlete[]
        {
            new Basketballer("a", "a", 1, 0.01),
            new Basketballer("b", "b", 1, 0.01),
            new Basketballer("c", "c", 1, 0.01),
            new Basketballer("d", "d", 1, 0.01),
            new Basketballer("e", "e", 1, 0.01),
        };

        int score = 0;

        foreach(Athlete athlete in team)
        {
            for(int i =  0; i < 100; i++)
            {
                if(athlete.WillScore()) score++;
            }
        }

        Console.WriteLine(score);
        score = 0;

        foreach (Athlete athlete in team)
        {
            for(int i = 0; i < 10; i++)
            {
                athlete.Train();
            }
        }

        foreach (Athlete athlete in team)
        {
            for (int i = 0; i < 100; i++)
            {
                if (athlete.WillScore()) score++;
            }
        }

        Console.WriteLine(score);
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