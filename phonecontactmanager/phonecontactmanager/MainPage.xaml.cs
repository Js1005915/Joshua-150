using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Contacts.Provider;
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
        ContactsViewModel contactsViewModel = new ContactsViewModel();
        

        public MainPage()
        {
            this.InitializeComponent();
            
            ListView.ItemsSource = contactsViewModel.ContactsList();
            
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            
            contactsViewModel.AddContact(NameBox.Text, PhoneBox.Text);
            NameBox.Text = "";
            PhoneBox.Text = "";

        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            contactsViewModel.Contacts.Clear();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NameBox.Text = sender.ToString();
        }
    }
    public class Contact
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class ContactsViewModel
    {
        public ObservableCollection<Contact> Contacts = new ObservableCollection<Contact>()
        {
            new Contact {Name = "Hiter", PhoneNumber = "4172111111"}
        };


        public void AddContact(string name, string phonenumber)
        {
            Contacts.Add(new Contact() { Name = name, PhoneNumber = phonenumber });
        }

        public ObservableCollection<Contact> ContactsList()
        {
            return Contacts;
        }
    }


}
