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

using SQLite.Net.Platform.WinRT;
using SQLite.Net.Interop;
using SQLite.Net;
using Windows.Storage;

namespace SQLite_DB
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            testDB();
        }

        void testDB()
        {
            string pathLocal = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "database.sqlite");
            ISQLitePlatform sqlitePlatform = new SQLitePlatformWinRT();

            Person person = null;

            var db = new SQLiteConnection(sqlitePlatform ,pathLocal);

            db.CreateTable<Person>();
            person = new Person { Name = "Minwoo" };
            db.Insert(person);

            var resulte = db.Query<Person>("SELECT * FROM PERSON WHERE (name = 'Minwoo');");
            foreach(var tt in resulte)
            {
                TextTest.Text = string.Format("Person {0} {1}", tt.Id, tt.Name);
            }
        }
    }
}
