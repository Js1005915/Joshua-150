using AnimalKingdom;
using System;
using System.Xml.Linq;

namespace AnimalKingdom
{
    public class Fish : Animal
    {
        public Fish(string name, int age) : base(name, age)
        {
        }

        public
            override void MakeSound()
        {
            //fish dont make a sound gang
            Console.WriteLine($"{Name} bubbles. ");
        }
    }
}