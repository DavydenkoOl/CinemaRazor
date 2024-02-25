using CinemaRazor.Models;
using CinemaRazor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaRazor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Kino> _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public CreateModel(IRepository<Kino> _context, IWebHostEnvironment _appEnvironment)
        {
            this._context = _context;
            this._appEnvironment = _appEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kino kino { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync(IFormFile? uploadedFile)
        {
            if (!ModelState.IsValid || _context == null || kino == null || uploadedFile == null)
            {
                return Page();
            }

            string path = uploadedFile.FileName; // имя файла

            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/images/" + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
            }
            kino.Poster = path;
            await _context.AddObject(kino);
            await _context.Save();

            return RedirectToPage("./Index");
        }
    }
}
