using CinemaRazor.Models;
using CinemaRazor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaRazor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Kino> _context;

        public DetailsModel(IRepository<Kino> _context)
        {
            this._context = _context;
        }

        public Kino kino { get; set; } = default;
        public async Task<IActionResult> OnGet(int id)
        {
            kino = await _context.GetObject(id);
            if (kino == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
