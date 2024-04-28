using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Core.Entities
{
    public class AdvertisementToFind : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? userId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();

    }
}
