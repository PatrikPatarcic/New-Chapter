class Resistance
{
    float physical;
    float magical;

    public Resistance(float physical, float magical)
    {
        this.physical = 1 - (float)Math.Clamp(physical, 0.0, 1.0);
        this.magical = 1 - (float)Math.Clamp(magical, 0.0, 1.0);
    }

    public float Physical
    {
        get { return this.physical; }
        set { physical = value; }
    }

    public float Magical
    {
        get { return this.magical; }
        set { magical = value; }
    }
}