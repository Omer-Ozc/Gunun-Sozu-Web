using GununSozu.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            if (context.QTE_Quotes.Any())
                return; // Daha önce seed yapılmış

            // Id'leri önceden belirleyerek ilişkileri düzgün kur
            var languageTrId = Guid.NewGuid();
            var languageEnId = Guid.NewGuid();

            var categoryMotivationId = Guid.NewGuid();
            var categoryGeneralId = Guid.NewGuid();

            // DİLLER
            var languageTr = new SYS_Language { Id = languageTrId, Name = "Türkçe" };
            var languageEn = new SYS_Language { Id = languageEnId, Name = "English" };
            context.SYS_Language.AddRange(languageTr, languageEn);

            // KATEGORİLER
            var category1 = new QTE_Categories { Id = categoryMotivationId, Name = "Motivasyon", Description = "İlham verici sözler" };
            var category2 = new QTE_Categories { Id = categoryGeneralId, Name = "Genel", Description = "Genel sözler" };
            context.QTE_Categories.AddRange(category1, category2);

            // SÖZLER
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

            context.SaveChanges();
        }
    }
}
