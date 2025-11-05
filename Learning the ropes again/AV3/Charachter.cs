namespace AV3;



public class Charachter
{
    string name;
    int hp;
    int xp;

    public Charachter() : this("Hero", 100) // this zove parametarski konstruktor
    {
        Console.WriteLine("Default ctor Character");
    }
    public Charachter(string name, int hp)
    {
        this.name = name;
        this.hp = hp;
        this.xp = 0;
        Console.WriteLine("Parametric ctor Character");
    }

    public void SolveQuest()
    {
        this.xp += 100;
    }

    public virtual int Attack() // Virtual jer ce nasljeđene klase overridat ovu metodu
    {
        Heal(10);
        return 10;
    }

    protected void Heal(int hp)
    {
        this.hp = Math.Min(100, this.hp + hp);
    }

    public string GetAsString => $"{name}, {hp}hp, {xp}xp";
}

public class Enemy
{
    int hp = 1000;
    public void GetAttacked(Charachter charachter)
    {
        this.hp = Math.Max(0, this.hp - charachter.Attack());
    }

    public string GetAsString() => $"{hp}";
}