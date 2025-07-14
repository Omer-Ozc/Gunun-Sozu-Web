using Microsoft.AspNetCore.Mvc;
using GununSozu.Business.Interfaces;
using GununSozu.Data.Models;
using GununSozu.Business.DTOs;

namespace GununSozu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuoteController : Controller
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<IActionResult> Index()
        {
            var quotes = await _quoteService.GetAllAsync();
            return View(quotes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QTE_Quotes model)
        {
            if (ModelState.IsValid)
            {
                await _quoteService.AddQuoteAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var quote = await _quoteService.GetQuoteByIdAsync(id);
            if (quote == null)
                return NotFound();

            return View(quote);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(QTE_Quotes quote)
        {
            if (!ModelState.IsValid)
                return View(quote);

            await _quoteService.UpdateQuoteAsync(quote);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _quoteService.DeleteQuoteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
