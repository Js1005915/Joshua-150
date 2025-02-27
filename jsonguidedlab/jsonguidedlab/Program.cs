using Newtonsoft.Json;
using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person
        {
            Name = "John Doe",
            Age = 30,
            Email = "obama.@gmail.com",
            isStudent = false
        };

        //Creating the JSON, serializing a person to it, printing the json, Deserializing the person object and printing out its information
        string json = JsonConvert.SerializeObject(person);
        Console.WriteLine("Serialized JSON: " + json);
        Person deserializedPerson = JsonConvert.DeserializeObject<Person>(json);
        Console.WriteLine("Deserialized Person: Name - " + deserializedPerson.Name + ", Age - " + deserializedPerson.Age);

        //creation of 3 person objects

        Person person1 = new Person
        {
            Name = "Juan Dale",
            Age = 15,
            Email = "sigma.@gmail.com",
            isStudent = false
        };
        Person person2 = new Person
        {
            Name = "Josh Locke",
            Age = 21,
            Email = "reign.@gmail.com",
            isStudent = false
        };
        Person person3 = new Person
        {
            Name = "Preton Mendal",
            Age = 28,
            Email = "pretonmendal.@gmail.com",
            isStudent = false
        };
        
        //creating the personlist and adding people 1-3 to it

        List<Person> personlist = new List<Person>();
        personlist.Add(person1);
        personlist.Add(person2);
        personlist.Add(person3);
       
        //making a deserializedPersons list to use for the serializing/deserialzing

        List<Person> deserializedPersons = new List<Person>();
        json = JsonConvert.SerializeObject(personlist);
        //printing out the json
        Console.WriteLine("Serialized JSON: " + json);

        //for loop to the amount of persons in personlist and deserializing the deserializedPersons list, using i as the index for the list to print out specific info and having 2 try catch statements for null and generalexception handling.
        for (int i = 0; i < personlist.Count(); i++)
        {
            try
            {
                deserializedPersons = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            try {
                Console.WriteLine("Deserialized Person: Name - " + deserializedPersons[i].Name + ", Age - " + deserializedPersons[i].Age + ", Email - " + deserializedPersons[i].Email + ", Is Student: " + deserializedPersons[i].isStudent);
                }
            catch(Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
        }
    }
}



// person class, assigning it the name, age, email and isstudent attributes
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public string Email { get; set; }

    public bool isStudent { get; set; }
}
