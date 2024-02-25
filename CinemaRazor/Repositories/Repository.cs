using CinemaRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaRazor.Repositories
{
    public class Repository : IRepository<Kino>
    {
        private readonly KinoContext _context;
        public Repository(KinoContext context)
        {
            _context = context;
        }

        public async Task AddObject(Kino obj)
        {
           await _context.Kinos.AddAsync(obj);  
        }

        public async Task DeleteObject(int id)
        {
            var kino = await _context.Kinos.FindAsync(id);
            _context.Kinos.Remove(kino!);
        }

        public async Task<List<Kino>> GetList()
        {
            return _context.Kinos.ToList();
        }

        public async Task<Kino> GetObject(int id)
        {
            return await _context.Kinos.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateObject(Kino obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
