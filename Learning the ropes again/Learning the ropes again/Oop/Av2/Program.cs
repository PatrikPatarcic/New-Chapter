namespace Learning_the_ropes_again.Oop.Av2
{
    class Program
    {
        internal static void main()
        {
            Damage fireball = new Damage(0, 50, 0);
            Resistance magicArmor = new Resistance(0.1f, 0.6f);
            Charachter Wizard = new Charachter("Harry", fireball, magicArmor);

            Damage magicStorm = new Damage(20, 80, 0);
            Damage dealt = Wizard.TakeDamage(magicStorm);

            
            Console.WriteLine(magicStorm.GetAsString());
            Console.WriteLine(dealt.GetAsString());

            Army plantsForHire = Army.Hire(10000);

            Army pantsOnFire = Army.Recruit(10000);
        }
    }
}