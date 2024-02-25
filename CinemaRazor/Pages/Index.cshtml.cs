using CinemaRazor.Models;
using CinemaRazor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Kino> _context;

        public IList<Kino> Kinos { get; set; } = default!;

        public IndexModel(IRepository<Kino> _context)
        {
            this._context = _context;
        }

        public async void OnGet()
        {
            if (await _context.GetList() != null)
            {
                Kinos = await _context.GetList();
            }
        }
    }
}
