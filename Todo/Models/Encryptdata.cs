using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Models
{
    public class Encryptdata
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Info { get; set; }
    }
}
