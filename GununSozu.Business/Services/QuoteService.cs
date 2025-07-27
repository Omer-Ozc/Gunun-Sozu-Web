using GununSozu.Business.DTOs;
using GununSozu.Business.Interfaces;
using GununSozu.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GununSozu.Business.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly GununSozuDbContext _context;

        public QuoteService(GununSozuDbContext context)
        {
            _context = context;
        }

        public async Task<List<QTE_Quotes>> GetAllQuotesAsync()
        {
            return await _context.QTE_Quotes.OrderByDescending(q => q.Id).ToListAsync();
        }

        public async Task<QTE_Quotes> GetQuoteByIdAsync(Guid id)
        {
            return await _context.QTE_Quotes.FindAsync(id);
        }

        public async Task<QTE_Quotes> GetQuoteOfTheDayAsync()
        {
            return await _context.QTE_Quotes
                .Where(q => q.IsActive)
                .OrderBy(q => Guid.NewGuid()) // rastgele
                .FirstOrDefaultAsync();
        }

        public async Task AddQuoteAsync(QTE_Quotes quote)
        {
            _context.QTE_Quotes.Add(quote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuoteAsync(QTE_Quotes quote)
        {
            _context.QTE_Quotes.Update(quote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuoteAsync(Guid id)
        {
            var quote = await _context.QTE_Quotes.FindAsync(id);
            if (quote != null)
            {
                _context.QTE_Quotes.Remove(quote);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<QuoteDto>> GetAllAsync()
        {
            var list = await _context.QTE_Quotes
                .Include(x => x.Category)
                .Include(x => x.Language)
                .ToListAsync();

            return list.Select(q => new QuoteDto
            {
                Id = q.Id,
                Content = q.Content,
                Author = q.Author,
                CategoryName = q.Category?.Name,
                LanguageName = q.Language?.Name
            }).ToList();
        }

        public async Task SetFavoriteAsync(Guid userId, SetFavoriteDto dto)
        {
            // Kullanıcının varlığını doğrula
            var user = await _context.USR_Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                throw new KeyNotFoundException("Kullanıcı bulunamadı.");

            // Aynı favori daha önce eklenmiş mi?
            bool exists = await _context.USR_Favorites
                .AnyAsync(f => f.UserId == userId && f.QuoteId == dto.QuoteId);
            if (exists)
                return;

            // Yeni favorite kaydı
            var fav = new USR_Favorites
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                QuoteId = dto.QuoteId,
            };

            _context.USR_Favorites.Add(fav);
            await _context.SaveChangesAsync();
        }

    }
}
