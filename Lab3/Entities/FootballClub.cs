using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Entities
{
    [Table("Football Clubs")]
    public class FootballClub
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }

        public FootballClub(int id, string name) 
        {
            Id = id;
            Name = name;
        }
        public FootballClub() { }
    }
}
