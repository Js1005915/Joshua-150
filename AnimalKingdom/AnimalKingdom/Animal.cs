namespace AnimalKingdom
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;

        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} makes a sound");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bird parrot = new Bird("Parrot", 5);
            Fish goldfish = new Fish("Goldfish", 1);

            // Although MakeSound is overridden, the property Name is inherited from Animal
            parrot.MakeSound(); // Outputs: Parrot chirps.
            goldfish.MakeSound(); // Outputs: Goldfish bubbles.

            // Accessing inherited properties
            Console.WriteLine(parrot.Name); // Outputs: Parrot
            Console.WriteLine(goldfish.Age); // Outputs: 1
        }
    }
}

