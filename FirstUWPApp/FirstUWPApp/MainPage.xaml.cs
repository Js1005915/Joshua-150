using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using System.Text;
using Windows.Networking;


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
            SaveCsvFileAsync();
        }

        public async Task SaveCsvFileAsync()
        {
            var savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;

            savePicker.FileTypeChoices.Add("CSV file", new List<string>() { ".csv" });
            savePicker.SuggestedFileName = "data";

            StorageFile file = await savePicker.PickSaveFileAsync();

            if (file != null)
            {
                // Prevent updates to the remote version of the file until updates are finalized with call to CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);

                var lines = Students.Select(s => s.ToString_CSV());
                await Windows.Storage.FileIO.WriteLinesAsync(file, lines);

                // Finalize write
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    var dialog = new ContentDialog
                    {
                        Title = "Success",
                        Content = "File saved successfully!",
                        CloseButtonText = "OK"
                    };
                    await dialog.ShowAsync();
                }
            }
        }


        public async Task<ObservableCollection<Student>> ReadCSV()
        {
            var picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".csv");

            StorageFile file = await picker.PickSingleFileAsync();

            if (file == null)
            {
                return null;
            }

            var lines = await FileIO.ReadLinesAsync(file);



            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');

                if (parts.Length >= 3)
                {
                    Students.Add(new Student
                    {
                        Id = int.TryParse(parts[0], out int id) ? id : 0,
                        FName = parts[1],
                        LName = parts[2],
                        Class = parts[3],
                        Grade = parts[4]
                    });
                }

            }
            return Students;
        }

        private void ReadFromFile(object sender, RoutedEventArgs e)
        {
            ReadCSV();
        }
    }


    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Class { get; set; }
        public string Grade { get; set; }

        public override string ToString()
        {
            return $"Student: ID:{Id}, First Name:{FName}, Last Name:{LName}, Course:{Class}, Course Grade:{Grade}.";

        }
        public string ToString_CSV()
        {
            return $"{Id},{FName},{LName},{Class},{Grade}";
        }

    }

    

}

