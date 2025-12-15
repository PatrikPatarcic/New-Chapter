namespace LV4;

class Dog
{
    public string Name { get; private set; }
    public Breed Breed { get; private set; }
    public Dog(string name, Breed breed)
    {
        Name = name;
        Breed = breed;
    }
    public override string ToString() => $"Woof! I am {Name} and am a {Breed}";
public static void RunSimpleDemo()
    {
        // Writing to a file, the file will be located next to
        // the executable file:
        Dog[]
        dogs = new Dog[]
    {
        new Dog("Rex", Breed.Akita),
 new Dog("Tex", Breed.Labrador),
 new Dog("Mex", Breed.Frenchie),
    }
       ;
        Console.WriteLine(string.Join<Dog>(Environment.NewLine, dogs));
        string fileName = @"data.txt";
        bool append = true;
        using (StreamWriter writer = new StreamWriter(fileName, append))
        {
            foreach (Dog dog in dogs)
            {
                writer.Write(dog.Name);
                writer.Write(',');
                writer.Write(dog.Breed);
                writer.Write(Environment.NewLine);
            }
        }

        // Reading from the file, line by line, until the
        // end of the file:
        List<Dog> dogsFromFile = new List<Dog>();
        char splitToken = ',';
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)

            {
                string[] dogParts = line.Split(splitToken);
                string name = dogParts[0];
                Breed breed = (Breed)Enum.Parse(typeof(Breed), dogParts[1]);
                dogsFromFile.Add(new Dog(name, breed));
            }
        }
        Console.WriteLine(string.Join<Dog>(Environment.NewLine, dogsFromFile));
    }
}