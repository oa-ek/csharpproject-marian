using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamManager.Core.Entities;

namespace TeamManager.Core.Contrext
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var (adminRoleId, finderRoleId, sellerRoleId) = SeedRoles(builder);

            var usersId = SeedUsers(builder, finderRoleId, adminRoleId);

            SeedGenres(builder);
            SeedLanguages(builder);
            SeedPlatforms(builder);
            SeedDevelopers(builder);
            SeedAdvertisementStatuses(builder);
        }

        private static (Guid, Guid, Guid) SeedRoles(ModelBuilder builder)
        {
            var adminRoleId = Guid.NewGuid();
            var finderRoleId = Guid.NewGuid();
            var sellerRoleId = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>()
               .HasData(
                   new IdentityRole<Guid>
                   {
                       Id = adminRoleId,
                       Name = "Admin",
                       NormalizedName = "ADMIN",
                       ConcurrencyStamp = adminRoleId.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = finderRoleId,
                       Name = "Finder",
                       NormalizedName = "FINDER",
                       ConcurrencyStamp = finderRoleId.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = sellerRoleId,
                       Name = "Seller",
                       NormalizedName = "SELLER",
                       ConcurrencyStamp = sellerRoleId.ToString()
                   }
               );

            return (adminRoleId, finderRoleId, sellerRoleId);
        }

        private static Guid SeedUsers(ModelBuilder builder, Guid finderRoleId, Guid adminRoleId)
        {
            var adminId = Guid.NewGuid();
            var finderId = Guid.NewGuid();

            var admin = new User
            {
                Id = adminId,
                UserName = "admin@example",
                EmailConfirmed = true,
                NormalizedUserName = "admin@example".ToUpper(),
                Email = "admin@example",
                NormalizedEmail = "admin@example".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Jack Rell"
            };

            var finder = new User
            {
                Id = finderId,
                UserName = "finder@example",
                EmailConfirmed = true,
                NormalizedUserName = "finder@example".ToUpper(),
                Email = "finder@example",
                NormalizedEmail = "finder@example".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Tom Morgan"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            finder.PasswordHash = passwordHasher.HashPassword(finder, "Pr0#et1n1t");
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Pr0#et1n1t");

            builder.Entity<User>()
                .HasData(admin,finder);

            builder.Entity<IdentityUserRole<Guid>>()
            .HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = finderRoleId,
                    UserId = finderId
                }
            );

            return finderId;
        }

        private static void SeedGenres(ModelBuilder builder)
        {
            var genres = new List<Genre>
            {
                new Genre { Id = Guid.NewGuid(), Name = "Action" },
                new Genre { Id = Guid.NewGuid(), Name = "Adventure" },
                new Genre { Id = Guid.NewGuid(), Name = "Role-playing" },
                new Genre { Id = Guid.NewGuid(), Name = "Strategy" },
                new Genre { Id = Guid.NewGuid(), Name = "Simulation" },
                new Genre { Id = Guid.NewGuid(), Name = "Sports" },
                new Genre { Id = Guid.NewGuid(), Name = "Racing" },
                new Genre { Id = Guid.NewGuid(), Name = "Puzzle" },
                new Genre { Id = Guid.NewGuid(), Name = "Fighting" },
                new Genre { Id = Guid.NewGuid(), Name = "Horror" }
            };

            builder.Entity<Genre>().HasData(genres);
        }

        private static void SeedLanguages(ModelBuilder builder)
        {
            var languages = new List<Language>
            {
                new Language { Id = Guid.NewGuid(), Name = "English" },
                new Language { Id = Guid.NewGuid(), Name = "Spanish" },
                new Language { Id = Guid.NewGuid(), Name = "French" },
                new Language { Id = Guid.NewGuid(), Name = "German" },
                new Language { Id = Guid.NewGuid(), Name = "Japanese" },
                new Language { Id = Guid.NewGuid(), Name = "Chinese" },
                new Language { Id = Guid.NewGuid(), Name = "Russian" },
                new Language { Id = Guid.NewGuid(), Name = "Italian" },
                new Language { Id = Guid.NewGuid(), Name = "Korean" },
                new Language { Id = Guid.NewGuid(), Name = "Portuguese" }
            };

            builder.Entity<Language>().HasData(languages);
        }

        private static void SeedPlatforms(ModelBuilder builder)
        {
            var platforms = new List<Platform>
            {
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation 5" },
                new Platform { Id = Guid.NewGuid(), Name = "Xbox Series X" },
                new Platform { Id = Guid.NewGuid(), Name = "Nintendo Switch" },
                new Platform { Id = Guid.NewGuid(), Name = "PC" },
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation 4" },
                new Platform { Id = Guid.NewGuid(), Name = "Xbox One" },
                new Platform { Id = Guid.NewGuid(), Name = "Mobile" },
                new Platform { Id = Guid.NewGuid(), Name = "Google Stadia" },
                new Platform { Id = Guid.NewGuid(), Name = "VR" },
                new Platform { Id = Guid.NewGuid(), Name = "Mac" }
            };

            builder.Entity<Platform>().HasData(platforms);
        }

        private static void SeedDevelopers(ModelBuilder builder)
        {
            var developers = new List<Developer>
            {
                new Developer { Id = Guid.NewGuid(), Name = "Rockstar Games" },
                new Developer { Id = Guid.NewGuid(), Name = "Ubisoft" },
                new Developer { Id = Guid.NewGuid(), Name = "Electronic Arts" },
                new Developer { Id = Guid.NewGuid(), Name = "Square Enix" },
                new Developer { Id = Guid.NewGuid(), Name = "CD Projekt" },
                new Developer { Id = Guid.NewGuid(), Name = "Nintendo" },
                new Developer { Id = Guid.NewGuid(), Name = "Naughty Dog" },
                new Developer { Id = Guid.NewGuid(), Name = "Valve Corporation" },
                new Developer { Id = Guid.NewGuid(), Name = "Epic Games" },
                new Developer { Id = Guid.NewGuid(), Name = "Activision Blizzard" }
            };

            builder.Entity<Developer>().HasData(developers);
        }

        private static void SeedAdvertisementStatuses(ModelBuilder builder)
        {
            var advertisementStatuses = new[]
            {
                new AdvertisementStatus { Id = Guid.NewGuid(), Name = "For Rent" },
                new AdvertisementStatus { Id = Guid.NewGuid(), Name = "For Sale" }
            };

            builder.Entity<AdvertisementStatus>().HasData(advertisementStatuses);
        }
    }
}
