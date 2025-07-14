using GununSozu.Business.DTOs;
using GununSozu.Data.Models;

namespace GununSozu.Business.Interfaces
{
    public interface IQuoteService
    {
        Task<List<QTE_Quotes>> GetAllQuotesAsync();
        Task<List<QuoteDto>> GetAllAsync();
        Task<QTE_Quotes> GetQuoteByIdAsync(Guid id);
        Task<QTE_Quotes> GetQuoteOfTheDayAsync();
        Task AddQuoteAsync(QTE_Quotes quote);
        Task UpdateQuoteAsync(QTE_Quotes quote);
        Task DeleteQuoteAsync(Guid id);

    }
}
