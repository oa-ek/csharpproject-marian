using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Core.Entities
{
    public class AdvertisementForSales : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? userId { get; set; }
        public virtual GameAccount? gameAccount  { get; set; }

        [ForeignKey(nameof(gameAccount))]
        public Guid? gameAccountId { get; set; }
        public virtual AdvertisementStatus? advertisementStatus { get; set; }

        [ForeignKey(nameof(advertisementStatus))]
        public Guid? advertisementStatusId { get; set; }
        public bool IsActive { get; set; }
        public string MainImage { get; set; } = $"img\\noPhoto.jpg";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
