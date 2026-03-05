using Microsoft.EntityFrameworkCore;
using OnlineBookShoping.Repositories.IRepository;

namespace OnlineBookShoping.Repositories.Repository
{
    public class GenreRepository : IGenreRepository
    {
        public readonly ApplicationDbContext _dbContext;
        
        public GenreRepository(ApplicationDbContext db) {
            _dbContext = db; 
        }

      public async Task<IEnumerable<Genre>> getAllGenre()
        {
         return  await _dbContext.Genres.ToListAsync();

        }
        public async Task AddGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
        }
        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _dbContext.Genres.FindAsync(id);
           
        }
        public async Task UpdateGenre(Genre genre)
        {
             _dbContext.Genres.Update(genre);
        }

        public async Task DeleteGenre(Genre rec)
        {
            _dbContext.Genres.Remove(rec);
        }

        public async Task<Genre> GetGenreWithBooks(int id)
        {
           Genre booksFromDb = await _dbContext.Genres.Include(u => u.Books)
                .FirstOrDefaultAsync(u  => u.Id == id);
            return booksFromDb;
        }
    }
}
