using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GununSozu.Data.Models;
using GununSozu.Business.DTOs;

namespace GununSozu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GununSozuDbContext _context;

        public CategoriesController(GununSozuDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.QTE_Categories
                .Include(c => c.Quotes)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    QuoteCount = c.Quotes.Count
                }).ToListAsync();

            return Ok(categories);
        }
    }
}
