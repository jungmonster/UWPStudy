using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace SQLite_DB
{

    [Table("Person")]
    class Person
    {
        [Column ("id")]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column ("name")]
        [NotNull]
        public string Name { get; set; }

        [Column ("age")]
        public int Age { get; set; }
    }

}
