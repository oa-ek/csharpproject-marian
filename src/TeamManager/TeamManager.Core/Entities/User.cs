using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public virtual ICollection<UserGroup> UserGroups { get; set; } = new HashSet<UserGroup>();
        public virtual ICollection<AdvertisementToFind> AdvertisementsToFind{ get; set; } = new HashSet<AdvertisementToFind>();
        public virtual ICollection<GameAccount> GameAccounts { get; set; } = new HashSet<GameAccount>();
    }
}
