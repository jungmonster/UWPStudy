using System;
using System.Collections.Generic;
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

using System.Collections.ObjectModel;
using SQLite_DB.Model;
using SQLite_DB.ViewModel;

namespace SQLite_DB.View
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        ObservableCollection<Contacts> DB_ContactList = new ObservableCollection<Contacts>();
        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += ReadContactList_Loaded;
        }
        private void ReadContactList_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllContactsList dbcontacts = new ReadAllContactsList();
            DB_ContactList = dbcontacts.GetAllContacts();//Get all DB contacts  
            if (DB_ContactList.Count > 0)
            {
                btnDelete.IsEnabled = true;
            }
            listBoxobj.ItemsSource = DB_ContactList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first.  
        }

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxobj.SelectedIndex != -1)
            {
                Contacts listitem = listBoxobj.SelectedItem as Contacts;//Get slected listbox item contact ID
                Frame.Navigate(typeof(DetailsPage), listitem);
            }
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass delete = new DatabaseHelperClass();
            delete.DeleteAllContact();//delete all DB contacts
            DB_ContactList.Clear();//Clear collections
            btnDelete.IsEnabled = false;
            listBoxobj.ItemsSource = DB_ContactList;
        }
        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPage));
        }
    }
}
