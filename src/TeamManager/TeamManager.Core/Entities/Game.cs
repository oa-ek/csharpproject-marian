using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Core.Entities
{
    public class Game : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime ReleasedDate { get; set; } = DateTime.Now;
        public virtual ICollection<GameAccount> GameAccounts { get; set; } = new HashSet<GameAccount>();
        public string GamePhoto { get; set; }
    }
}
