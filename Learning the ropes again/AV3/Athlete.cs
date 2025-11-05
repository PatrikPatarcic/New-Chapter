namespace AV3;

public abstract class Athlete
{
    string name;
    string surname;
    int age;

    public Athlete(string name, string surname, int age)
    {
        this.name = name;
        this.surname = surname;
        this.age = age;
    }
    public void SetAge(int age) { this.age = age; }
    public int GetAge() { return age; }
    public override string ToString() => $"Name: {name}, surname: {surname}, age: {age}";

    public abstract void Train();

    public abstract bool WillScore();

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