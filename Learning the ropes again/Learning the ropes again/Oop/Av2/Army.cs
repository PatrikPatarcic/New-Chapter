class Army
{
    static int AmryCount = 0;
    const int CostPerSoldier = 10;

    int soldiers;
    private Army(int soldiers)
    {
        AmryCount++;
        this.soldiers = soldiers;

        Console.WriteLine("An army has been created.");
        Console.WriteLine(GetArmyInfo());
    }

    public static Army Hire(int goldCoins)
    {
        Army army = new Army(goldCoins / CostPerSoldier);
        return army;
    }

    public static Army Recruit(int population)
    {
        Army army = new Army(population / 2);
        return army;
    }

    public string GetArmyInfo()
    {
        return $"Army count: {AmryCount}, Soldiers: {soldiers}";
    }
}