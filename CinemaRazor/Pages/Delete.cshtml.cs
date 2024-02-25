using CinemaRazor.Models;
using CinemaRazor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaRazor.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Kino> _context;

        public DeleteModel(IRepository<Kino> _context)
        {
            this._context = _context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetList() == null)
            {
                return NotFound();
            }

            var m = await _context.GetObject((int)id);
            if (m == null)
            {
                return NotFound();
            }
            kino = m;
            return Page();
        }

        [BindProperty]
        public Kino kino { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null && kino.Id != id)
                return NotFound();

            await _context.DeleteObject((int)id);
            await _context.Save();

            return RedirectToPage("./Index");
        }
    }
}
