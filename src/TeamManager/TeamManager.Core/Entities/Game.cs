using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string MainImage { get; set; } = $"img\\noPhoto.jpg";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; } = new HashSet<Platform>();
        public virtual ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
        public virtual ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
        public virtual ICollection<Language> Languages { get; set; } = new HashSet<Language>();
    }
}
