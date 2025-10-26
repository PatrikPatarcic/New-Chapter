class Damage
{
    string castName;
    int physical;
    int magical;
    int core;

    public Damage(string castName, int physical, int magical, int core)
    {
        this.castName = castName;
        this.physical = physical;
        this.magical = magical;
        this.core = core;
    }

    public Damage(int physical, int magical, int core)
    {
        castName = "N/A";
        this.physical = physical;
        this.magical = magical;
        this.core = core;
    }
    public string CastName
    {
        get { return this.castName; }
        set { castName = value; }
    }

    public int Physical
    {
        get { return this.physical; }
        set { physical = value; }
    }

    public int Magical
    {
        get { return this.magical; }
        set { magical = value; }
    }

    public int Core
    {
        get { return this.core; }
        set { core = value; }
    }


    public string GetAsString()
    {
        return $"{physical}/{magical}/{core}";
    }

    public void FancyPrint()
    {
        Helper.PrintWord($"{castName} Damage -> ", ConsoleColor.Magenta);
        Helper.PrintWord($"Physical: {physical}, ", ConsoleColor.Red);
        Helper.PrintWord($"Magical: {magical}, ", ConsoleColor.Blue);
        Helper.Print($"Core: {core}", ConsoleColor.DarkYellow);
    }
}