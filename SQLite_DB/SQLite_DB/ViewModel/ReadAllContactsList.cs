using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using SQLite_DB.Model;

namespace SQLite_DB.ViewModel
{
    class ReadAllContactsList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<Contacts> GetAllContacts()
        {
            return Db_Helper.ReadAllContacts();
        }
    }
}
