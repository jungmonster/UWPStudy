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

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234238에 나와 있습니다.
using SQLite_DB.Model;
using SQLite_DB.ViewModel;


namespace SQLite_DB.View
{
    public sealed partial class DetailsPage : Page
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        Contacts currentStudent = new Contacts();
        public DetailsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            currentStudent = e.Parameter as Contacts;
            NametxtBx.Text = currentStudent.Name;
            PhonetxtBx.Text = currentStudent.PhoneNumber;
        }

        private void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            currentStudent.Name = NametxtBx.Text;
            currentStudent.PhoneNumber = PhonetxtBx.Text;
            Db_Helper.UpdateDetails(currentStudent);//Update selected DB contact Id
            Frame.Navigate(typeof(HomePage));
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Db_Helper.DeleteContact(currentStudent.Id);//Delete selected DB contact Id.
            Frame.Navigate(typeof(HomePage));
        }
    }
}
