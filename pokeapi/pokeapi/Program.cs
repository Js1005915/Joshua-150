using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class pokeansw
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
}

public class poke
{
    public static List<string> pokemonlist = new List<string>();
    public static async Task MakePokeApiCallAsync(string name)
    {
        
        using (HttpClient client = new HttpClient())
        {
            try
            {
                
                string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{name}/"; 

                
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                
                if (response.IsSuccessStatusCode)
                {
                    
                    string responseBody = await response.Content.ReadAsStringAsync();

                   
                    pokeansw pokeresponse = JsonConvert.DeserializeObject<pokeansw>(responseBody);

                   
                    Console.WriteLine($"Name: {pokeresponse.Name}");
                    Console.WriteLine($"Weight: {pokeresponse.Weight}");
                    Console.WriteLine($"Height: {pokeresponse.Height}");
                    pokemonlist.Add( pokeresponse.Name );
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                    Console.WriteLine("Please instert a valid entry: ");
                    name = Console.ReadLine();
                    await MakePokeApiCallAsync(name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
            }
        }
    }

    public static async Task Main()
    {
        bool state = true;
        
        while (state == true)
        {
            Console.WriteLine("1. Search Pokemon | 2. History | 3. Exit");
            string option = Console.ReadLine();
            switch(option)
            {
                case "1":
                    Console.Write("Enter a pokemons name or id to display information about it: ");
                    string name = Console.ReadLine();
                    await MakePokeApiCallAsync(name);
                    break;
                case "2":
                    Console.WriteLine("Pokemon searched ");
                    foreach (string i in pokemonlist)
                    {
                        Console.WriteLine(i);
                        Console.WriteLine();
                    }
                    break;
                case "3":
                    state = false;
                    break;
            }

                

        }
    }

}