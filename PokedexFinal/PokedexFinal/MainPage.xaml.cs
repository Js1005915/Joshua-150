using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokedexFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<PokemonClass> PokeList = new ObservableCollection<PokemonClass>();

        public MainPage()
        {
            this.InitializeComponent();

            MainListView.ItemsSource = PokeList;
            
            

            // instantiate client
            PokeApiClient pokeClient = new PokeApiClient();

            // get a resource by name
            //Pokemon hoOh = await pokeClient.GetResourceAsync<Pokemon>("ho-oh");

            PokeList.Add(new PokemonClass { id = 01, name = "Bulbasaur", height = 12, weight = 12, color = "Green", gender = "Male" });

            Pokemon fpoke = PokemonClass.Getpoke(1);

            PokeList.Add(new PokemonClass { id = fpoke.Id });


        }
    }



    public class PokemonClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string color { get; set; }
        public string gender { get; set; }




        public static async Task<Pokemon> Getpoke(int id)
        {
            PokeApiClient pokeClient = new PokeApiClient();

            Pokemon aa =  await pokeClient.GetResourceAsync<Pokemon>(id);

            return aa;
        }
    }




}



