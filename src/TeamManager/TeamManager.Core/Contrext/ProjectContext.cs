using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamManager.Core.Entities;


namespace TeamManager.Core.Contrext
{
    public class ProjectContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }
        public DbSet<AccountPlatform> AccountPlatforms => Set<AccountPlatform>();
        public DbSet<AdvertisementForSales> AdvertisementsForSales => Set<AdvertisementForSales>();
        public DbSet<AdvertisementStatus> advertisementStatuses => Set<AdvertisementStatus>();
        public DbSet<AdvertisementToFind> AdvertisementsToFind => Set<AdvertisementToFind>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<GameAccount> UserAccounts => Set<GameAccount>();
        public DbSet<UserGroup> UserGroups => Set<UserGroup>();

    }
       
    
}
