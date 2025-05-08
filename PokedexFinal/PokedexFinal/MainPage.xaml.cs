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
using System.Collections;
using System.Security.Claims;
using Windows.Media.Protection.PlayReady;
using Windows.UI.Xaml.Documents;
using Windows.UI.Text;
using System.Numerics;
using System.ComponentModel.Design;
using System.Linq.Expressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokedexFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static ObservableCollection<PokemonClass> PokeList = new ObservableCollection<PokemonClass>();
        public static ObservableCollection<PokemonClass> SearchList = new ObservableCollection<PokemonClass>();
        public bool listchangeable = true;

        public PokemonClass selectedPokemon { get; set; }
        public MainPage()
        {
            this.InitializeComponent();

            var WindowsHeight = Window.Current.Bounds.Height;
            var WindowsWidth = Window.Current.Bounds.Width;
            EVOPopup.Width = WindowsWidth / 2;
            EVOPopup.Height = WindowsHeight / 2;

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
                
                PokeList.Add(new PokemonClass { id = fpoke.id, name = fpoke.name, height = fpoke.height, weight = fpoke.weight, color = fpoke.color, gender = fpoke.gender, sprite = fpoke.sprite, listsprite = fpoke.listsprite, EvoChain = fpoke.EvoChain, type = fpoke.type });

                if (listchangeable == true)
                {
                    SearchList.Add(new PokemonClass { id = fpoke.id, name = fpoke.name, height = fpoke.height, weight = fpoke.weight, color = fpoke.color, gender = fpoke.gender, sprite = fpoke.sprite, listsprite = fpoke.listsprite, EvoChain = fpoke.EvoChain, type = fpoke.type });
                }

            }


        }

        private void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is PokemonClass clickedPokemon)
            {

                selectedPokemon = clickedPokemon;

                string types = "";

                for (int i = 0; i < selectedPokemon.type.Count; i++)
                {
                    types = string.Join(", ", selectedPokemon.type);
                }

                HInfoBox.Text = $"Type(s) {types} \nHeight: {selectedPokemon.height} cm \nWeight: {(selectedPokemon.weight) / 100} gram(s) \nColor: {selectedPokemon.color} \nGender: {selectedPokemon.gender}";
                if (selectedPokemon.name != null)
                {
                    NameBox.Text = selectedPokemon.name.ToUpper();
                }
                

                var uri = new Uri(selectedPokemon.sprite);
                var bitmap = new BitmapImage(uri);

                ImageBrush imgBrush = new ImageBrush
                {
                    ImageSource = bitmap
                };

                ImageWBorder.Background = imgBrush;

                

                foreach (var x in selectedPokemon.EvoChain)
                {
                    EvolutionTXBX.Text = x;
                    if (x == null)
                    {
                        EvolutionTXBX.Text = "Failed to load, sorry.";
                    }
                    
                }

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
                var big = "null";
                if (poke.type.Count == 2)
                {
                    big = poke.type[1];
                }
                else
                {
                    big = "null";
                }

                string pokename = null;
                int pokeid = 0;
                string pokecolor = null;
                string pokegender = null;
                string poketype = null;

                try
                {
                    pokename = poke.name;
                    pokeid = poke.id;
                    pokecolor = poke.color;
                    pokegender = poke.gender;
                    poketype = poke.type[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }


                try
                {
                    if (pokename != null & pokename.ToLower().Contains(query) || (pokeid != 0 & pokeid.ToString().Contains(query)) || (pokecolor != null & pokecolor.ToLower().Contains(query)) || (pokegender != null & pokegender.ToLower().Contains(query)) || (poketype != null & poketype.ToLower().Contains(query)) || big != null & (big.ToLower().Contains(query)))
                    {
                        SearchList.Add(poke);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EVOPopup.IsOpen = true;



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            var maxcount = PokeList.Count - 1;
            int ransearch = rnd.Next(1, maxcount);
            SearchTextBox.Text = ransearch.ToString();
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
        public List<string> type { get; set; }

        public string sprite { get; set; }

        public string listsprite { get; set; }

        public List<string> EvoChain { get; set; }





        public static async Task<PokemonClass> Getpoke(int id)
        {
            PokeApiClient pokeClient = new PokeApiClient();

            PokeApiNet.Pokemon aa = null;
            PokeApiNet.PokemonSpecies ac = null;

            var evolutionPaths = new List<string>();


            int Pid = 0;

            string pname = null;

            int Pheight = 0;

            int Pweight = 0;
            
            string pokecolor = null;
            
            string genderdesc = null;
            
            List<string> Ptypes = new List<string>();

            string Front_Image = null;

            string SpriteListFront = null;




            try
            {
                aa = await pokeClient.GetResourceAsync<Pokemon>(id);

                ac = await pokeClient.GetResourceAsync<PokemonSpecies>(id);

                pname = char.ToUpper(aa.Name[0]) + aa.Name.Substring(1);

                Pid = aa.Id;
                Pheight = aa.Height;
                Pweight = aa.Weight;

                Front_Image = aa.Sprites.Other.OfficialArtwork.FrontDefault;
                SpriteListFront = aa.Sprites.FrontDefault;



                int genderRate = ac.GenderRate;
                
                pokecolor = ac.Color.Name;
                if (genderRate == -1)
                    genderdesc = "Genderless";
                else
                    genderdesc = $"F {genderRate * 12.5}% / M {(8 - genderRate) * 12.5}%";



                ;


                


                for (int i = 0; i < aa.Types.Count; i++)
                {
                    Ptypes.Add(aa.Types[i].Type.Name);
                }





                var evurl = ac.EvolutionChain.Url;
                
                var chainId = int.Parse(evurl.TrimEnd('/').Split('/').Last());
                
                var plswork = await pokeClient.GetResourceAsync<EvolutionChain>(chainId);
                
                
                
                BuildEvolutionPaths(plswork.Chain, new List<string>(), evolutionPaths);
            }

            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }

            var imglist = new List<string>();


            

            

            

       

            
            


            



            return new PokemonClass { id = Pid, name = pname, height = Pheight, weight = Pweight, color = pokecolor, gender = genderdesc, sprite = Front_Image, listsprite = SpriteListFront, EvoChain = evolutionPaths, type = Ptypes};
        }


        static void BuildEvolutionPaths(ChainLink node, List<string> currentPath, List<string> resultPaths)
        {
            string pname = char.ToUpper(node.Species.Name[0]) + node.Species.Name.Substring(1);
            currentPath.Add(pname);

            if (node.EvolvesTo == null || node.EvolvesTo.Count == 0)
            {
                resultPaths.Add(string.Join(" -> ", currentPath));
            }
            else
            {
                foreach (var child in node.EvolvesTo)
                {

                    BuildEvolutionPaths(child, new List<string>(currentPath), resultPaths);
                }
            }
        }


    }








    
    // csv time, why must i hate myself, please god let this be good enough for extra credit and missed work im dying

    public class CsvWrite 
    {
        




        public async Task WriteCSVAsync()
        {
            var headers = new string[] { "id", "name", "height", "weight", "color", "gender", "type", "sprite", "listsprite", "evolution chain" };
            var CSVLIST = new ObservableCollection<PokemonClass>();

            for (int i = 0; i < 1025; i++)
            {
                var rows = new List<string[]>
                {
                    new string[] { MainPage.PokeList[i].id.ToString(), CSVLIST[i].name.ToString(), CSVLIST[i].height.ToString(), CSVLIST[i].weight.ToString(), CSVLIST[i].color.ToString(), CSVLIST[i].gender.ToString(), CSVLIST[i].type.ToString(), CSVLIST[i].sprite.ToString(), CSVLIST[i].listsprite.ToString(), CSVLIST[i].EvoChain.ToString() }
                };
            }



            
        }
    }










}



