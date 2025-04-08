using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Student> Students = new ObservableCollection<Student>();
        public MainPage()
        {
            this.InitializeComponent();
            Students.Add(new Student { Id = 12, FName = "Joe", LName = "Doe", Class="Merica", Grade = "A" });

            Mylistbox.ItemsSource = Students;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Students.Add(new Student { Id = Convert.ToInt32(IDbox.Text), FName = FNbox.Text, LName = LNbox.Text, Class = Cbox.Text, Grade = Gbox.Text });
            IDbox.Text = "";
            FNbox.Text = "";
            LNbox.Text = "";
            Cbox.Text = "";
            Gbox.Text = "";
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            SaveToCsv();
        }

        private async void SaveToCsv()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync("Students.csv", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            var stream = await file.OpenStreamForWriteAsync();
            using ( var writer = new StreamWriter(stream) )
            {
                writer.WriteLine("ID,First Name, Last Name, Class, Grade");

                foreach (var item in Students)
                {
                    writer.WriteLine($"{item.Id},{item.FName},{item.LName}, {item.Class},{item.Grade}");
                }
            }
        }
    }


    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Class { get; set; }
        public string Grade { get; set; }

        

    }

    

}

