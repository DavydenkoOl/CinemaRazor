using CinemaRazor.Models;
using CinemaRazor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRazor.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Kino> _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public EditModel(IRepository<Kino> _context, IWebHostEnvironment _appEnvironment)
        {
            this._context = _context;
            this._appEnvironment = _appEnvironment;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0 || await _context.GetList() == null)
            {
                return NotFound();
            }

            var k = await _context.GetObject(id);
            if (k == null)
            {
                return NotFound();
            }
            kino = k;
            return Page();
        }

        [BindProperty]
        public Kino kino { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync(IFormFile? uploadedFile)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (uploadedFile != null)
            {
                string path = uploadedFile!.FileName; // имя файла

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/images/" + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                }
                kino.Poster = path;
            }

            
            try
            {
                _context.UpdateObject(kino);
                await _context.Save();

            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
