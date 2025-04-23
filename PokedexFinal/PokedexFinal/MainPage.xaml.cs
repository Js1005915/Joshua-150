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
using System.Diagnostics;
using System.Net;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokedexFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<PokemonClass> PokeList = new ObservableCollection<PokemonClass>();
        public ObservableCollection<PokemonClass> SearchList = new ObservableCollection<PokemonClass>();
        public bool listchangeable = true;

        public PokemonClass selectedPokemon { get; set; }
        public MainPage()
        {
            this.InitializeComponent();

            MainListView.ItemsSource = SearchList;


            this.Loaded += MainPage_Loaded;



        }
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await Main();
        }

        public async Task Main()
        {

            for (int i = 1; i < 1026; i++)
            {
                var fpoke = await PokemonClass.Getpoke(i);
                
                PokeList.Add(new PokemonClass { id = fpoke.id, name = fpoke.name, height = fpoke.height, weight = fpoke.weight, color = fpoke.color, gender = fpoke.gender, sprite = fpoke.sprite });

                if (listchangeable == true)
                {
                    SearchList.Add(new PokemonClass { id = fpoke.id, name = fpoke.name, height = fpoke.height, weight = fpoke.weight, color = fpoke.color, gender = fpoke.gender, sprite = fpoke.sprite });
                }

            }


        }

        private void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is PokemonClass clickedPokemon)
            {

                selectedPokemon = clickedPokemon;

                HInfoBox.Text = $"Height: {selectedPokemon.height} cm \nWeight: {(selectedPokemon.weight) / 100} gram(s) \nColor: {selectedPokemon.color} \nGender: {selectedPokemon.gender}";
                NameBox.Text = selectedPokemon.name.ToUpper();

                var uri = new Uri(selectedPokemon.sprite);
                var bitmap = new BitmapImage(uri);

                ImageBrush imgBrush = new ImageBrush
                {
                    ImageSource = bitmap
                };

                ImageWBorder.Background = imgBrush;

            }




        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string query = SearchTextBox.Text.ToLower();

            SearchList.Clear();

            if (query == "")
            {
                listchangeable = true;
            }
            else
            {
                listchangeable = false;
            }
            

            foreach ( var poke in PokeList )
            {
                if (poke.name.ToLower().Contains(query) || (poke.id.ToString().Contains(query)))
                {
                    SearchList.Add(poke);
                }
            }
        }
    }





    public class PokemonClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public float weight { get; set; }
        public string color { get; set; }
        public string gender { get; set; }

        public string sprite { get; set; }




        public static async Task<PokemonClass> Getpoke(int id)
        {
            PokeApiClient pokeClient = new PokeApiClient();

            var aa =  await pokeClient.GetResourceAsync<Pokemon>(id);
            var ac = await pokeClient.GetResourceAsync<PokemonSpecies>(id);

            

            string pname = char.ToUpper(aa.Name[0]) + aa.Name.Substring(1);

            int genderRate = ac.GenderRate;
            string genderdesc;
            var pokecolor = ac.Color.Name;
            if (genderRate == -1)
                genderdesc = "Genderless";
            else
                genderdesc = $"F {genderRate * 12.5}% / M {(8 - genderRate) * 12.5}%";


            return new PokemonClass { id = aa.Id, name = pname, height = aa.Height, weight = aa.Weight, color = pokecolor, gender = genderdesc, sprite = aa.Sprites.Other.OfficialArtwork.FrontDefault};
        }
    }




}



