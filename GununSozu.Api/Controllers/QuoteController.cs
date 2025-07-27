using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GununSozu.Business.DTOs;
using GununSozu.Data.Models;
using System.Security.Claims;
using GununSozu.Business.Services;

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

        [HttpGet("GetToday")]
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetToday()
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
                }).FirstOrDefaultAsync();

            return Ok(quotes);
        }


        [HttpPost("Setfavorite")]
        public async Task<IActionResult> SetFavorite([FromBody] SetFavoriteDto dto)
        {
            if (dto == null || dto.QuoteId == Guid.Empty)
                return BadRequest("Eksik bilgi.");

            // JWT içerisinden UserId alın (NameIdentifier ya da sub claim)
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized();
            
            var _quoteService = new QuoteService(_context);
            await _quoteService.SetFavoriteAsync(userId, dto);
            return NoContent();
        }

    }
}
