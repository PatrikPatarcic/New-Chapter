using System;
using System.Security.Cryptography;
using Jamb;


internal class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!"); // Original line

        //Human H = new Human("001");

        //Testing.Main2(args);

        //Sort_n_Find.Main3(args);

        // Learning_the_ropes_again.Oop.Av2.Program.main();

        //BigSum.Day3.testing(args);

        Dice.RunDemo();

        Dice one = new Dice();

        Dice.RunExperiment(one, 100, 3);
    }
}

