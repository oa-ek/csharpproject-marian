using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Core.Entities
{
    public class Genre : IEntity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
