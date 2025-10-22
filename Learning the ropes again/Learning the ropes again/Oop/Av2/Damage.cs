class Damage
{
    int physical;
    int magical;
    int core;

    public Damage(int physical, int magical, int core)
    {
        this.physical = physical;
        this.magical = magical;
        this.core = core;
    }

    public int Physical
    {
        get { return this.physical; } set { physical = value; }
    }

    public int Magical
    {
        get { return this.magical; } set { magical = value; }
    }

    public int Core
    {
        get { return this.core; } set { core = value; }
    }


    public string GetAsString()
    {
        return $"{physical}/{magical}/{core}";
    }
}