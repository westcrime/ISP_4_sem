using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Tolstoi.Domain.Entities
{
    public class Player : Entity
    {
        public int ScoredGoalsCount { get; set; }

        public int Age { get; set; }

        public string TeamId { get; set; }

        public string Photo { get; set; }

        public Player()
        {
            base.Id = Guid.NewGuid().ToString();
        }
    }
}
