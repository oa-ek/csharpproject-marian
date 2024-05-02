using Microsoft.AspNetCore.Identity;

namespace TeamManager.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public string? FullName { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; } = new HashSet<UserGroup>();
        public virtual ICollection<AdvertisementToFind> AdvertisementsToFind{ get; set; } = new HashSet<AdvertisementToFind>();
        public virtual ICollection<GameAccount> GameAccounts { get; set; } = new HashSet<GameAccount>();
    }
}
