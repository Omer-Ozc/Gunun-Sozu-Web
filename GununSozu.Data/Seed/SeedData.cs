using GununSozu.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace GununSozu.Data.Seed
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new GununSozuDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<GununSozuDbContext>>());

            // Id'leri önceden belirleyerek ilişkileri düzgün kur
            var languageTrId = Guid.NewGuid();
            var languageEnId = Guid.NewGuid();

            var categoryMotivationId = Guid.NewGuid();
            var categoryGeneralId = Guid.NewGuid();

            // DİLLER
            if (!context.SYS_Language.Any())
            {
                var languageTr = new SYS_Language { Id = languageTrId, Name = "Türkçe" };
                var languageEn = new SYS_Language { Id = languageEnId, Name = "English" };
                context.SYS_Language.AddRange(languageTr, languageEn);
            }

            // KATEGORİLER
            if (!context.QTE_Categories.Any())
            {
                var category1 = new QTE_Categories { Id = categoryMotivationId, Name = "Motivasyon", Description = "İlham verici sözler" };
                var category2 = new QTE_Categories { Id = categoryGeneralId, Name = "Genel", Description = "Genel sözler" };
                context.QTE_Categories.AddRange(category1, category2);
            }

            // SÖZLER
            if (!context.QTE_Quotes.Any())
            {
                context.QTE_Quotes.AddRange(
                    new QTE_Quotes
                    {
                        Id = Guid.NewGuid(),
                        Content = "Başlamak için mükemmel olmak zorunda değilsin, ama mükemmel olmak için başlamak zorundasın.",
                        Author = "Zig Ziglar",
                        CategoryId = categoryMotivationId,
                        LanguageId = languageTrId,
                        IsActive = true
                    },
                    new QTE_Quotes
                    {
                        Id = Guid.NewGuid(),
                        Content = "Don’t watch the clock; do what it does. Keep going.",
                        Author = "Sam Levenson",
                        CategoryId = categoryMotivationId,
                        LanguageId = languageEnId,
                        IsActive = true
                    }
                );
            }

            context.SaveChanges();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            foreach (AppRoles role in Enum.GetValues(typeof(AppRoles)))
            {
                var roleName = role.ToString();
                if (!roleManager.Roles.Any(r => r.Name == roleName))
                {
                    roleManager.CreateAsync(new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    }).Wait();
                }
            }

            // ADMIN USER
            const string adminUserName = "admin";
            if (!userManager.Users.Any(u => u.UserName == adminUserName))
            {
                var admin = new ApplicationUser
                {
                    UserName = adminUserName,
                    Email = "admin@example.com",
                    DeviceId = "default-device",
                    LanguageId = languageTrId
                };
                userManager.CreateAsync(admin, "Admin123!").Wait();
                userManager.AddToRoleAsync(admin, AppRoles.Admin.ToString()).Wait();
            }
        }
    }
}
