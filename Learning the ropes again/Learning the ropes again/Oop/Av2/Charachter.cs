class Charachter
{
    string name;
    Damage damage;
    Resistance resistance;

    public Charachter(string name, Damage damage, Resistance resistance)
    {
        this.name = name;
        this.damage = damage;
        this.resistance = resistance;
    }

    public Damage TakeDamage(Damage dealt)
    {

        Damage takenDamage = new Damage((int)(dealt.Physical * resistance.Physical), (int)(dealt.Magical * resistance.Magical), dealt.Core);
        return takenDamage;
    }
}