using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
