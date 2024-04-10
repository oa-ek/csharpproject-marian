using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Core.Entities
{
    public class GameAccount : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User? User { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? userId { get; set; }
        public string Name { get; set; } = string.Empty;
        public AccountPlatform accountPlatform { get; set; }

        [ForeignKey(nameof(accountPlatform))]

        public Guid? accountPlatformId { get; set; }
        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();

        public string MainImage { get; set; } = $"img\\noPhoto.jpg";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
