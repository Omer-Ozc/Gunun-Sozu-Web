using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GununSozu.Data.Models;
using GununSozu.Business.DTOs;

namespace GununSozu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly GununSozuDbContext _context;

        public LanguagesController(GununSozuDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetLanguages")]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguages()
        {
            var languages = await _context.SYS_Language
                .Include(l => l.Quotes)
                .Select(l => new LanguageDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    QuoteCount = l.Quotes.Count
                }).ToListAsync();

            return Ok(languages);
        }
    }
}
