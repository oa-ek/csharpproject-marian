using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Core.Entities
{
    public class GameAccount : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual User? User { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? userId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual Platform? accountPlatform { get; set; }

        [ForeignKey(nameof(accountPlatform))]

        public Guid? accountPlatformId { get; set; }
        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
        public virtual ICollection<AdvertisementForSales> AdvertisementForSales { get; set; } = new HashSet<AdvertisementForSales>();

        public string MainImage { get; set; } = $"img\\noPhoto.jpg";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
