using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Core.Entities
{
    public class AdvertisementStatus : IEntity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AdvertisementForSales> AdvertisementsForSales { get; set; } = new HashSet<AdvertisementForSales>();
    }
}
