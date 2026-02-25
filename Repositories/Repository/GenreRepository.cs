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


    }
}
