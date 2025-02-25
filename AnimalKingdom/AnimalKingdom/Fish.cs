using System;


public class Fish : Animal
{
    public Fish(string name, int age) : base(name, age)
    {
    }

    public override void MakeSound()
    {
        //fish dont make a sound gang
        Console.WriteLine($"{Name} bubbles. ");
    }
}