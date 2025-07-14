using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GununSozu.Business.DTOs;
using GununSozu.Data.Models;

namespace GununSozu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly GununSozuDbContext _context;

        public QuotesController(GununSozuDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetQuotes")]
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetQuotes()
        {
            var quotes = await _context.QTE_Quotes
                .Include(q => q.Category)
                .Include(q => q.Language)
                .Select(q => new QuoteDto
                {
                    Id = q.Id,
                    Content = q.Content,
                    Author = q.Author,
                    IsActive = q.IsActive,
                    CategoryName = q.Category.Name,
                    LanguageName = q.Language.Name
                }).ToListAsync();

            return Ok(quotes);
        }
    }
}
