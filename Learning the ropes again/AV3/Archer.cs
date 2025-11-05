namespace AV3;

public class Archer : Charachter
{
    bool isHidden;
    public Archer() : base()
    {
        isHidden = false;
        Console.WriteLine("Default ctor Archer");
    }

    public Archer(string name, int hp, bool isHidden) : base(name, hp)
    {
        this.isHidden = isHidden;
    }

    public void Hide()
    {
        isHidden = true;
        Heal(10);
    }

    public override int Attack() => isHidden ? 2 * base.Attack() : base.Attack();
}