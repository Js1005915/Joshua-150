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

namespace phonecontactmanager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ListView Contacts;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            .TextProperty
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = e.ToString();
        }
    }
    public class Contact
    {
        public string Name;

        public string PhoneNumber;
    }

    public class ContactViewModel
    {
        public ObservableCollection<Contact> 
    }
}
