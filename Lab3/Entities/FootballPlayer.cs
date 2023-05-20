using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Entities
{
    [Table("Football Players")]
    public class FootballPlayer
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int PlayerId { get; set; }
        public string Name { get; set; }

        [Indexed]
        public int FootballClubId { get; set; }

        public FootballPlayer(int playerId, int clubId, string name)
        {
            FootballClubId = clubId;
            PlayerId = playerId;
            Name = name;
        }

        public FootballPlayer() { }
    }
}
