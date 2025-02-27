using System;
namespace AnimalKingdom
{
    public class Bird : Animal
    {
        public Bird(string name, int age) : base(name, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} chirps.");
        }
    }
}
