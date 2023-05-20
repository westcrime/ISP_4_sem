using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Tolstoi.Domain.Entities
{
    public class Team : Entity
    {
        public int LeaguePoints { get; set; }

        public string Photo { get; set; }

        public List<Player> Players { get; set; }

        public Team()
        {
            base.Id = Guid.NewGuid().ToString();
            Players = new List<Player>();
        }
    }
}
