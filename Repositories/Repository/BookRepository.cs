using Microsoft.EntityFrameworkCore;
using OnlineBookShoping.Repositories.IRepository;

namespace OnlineBookShoping.Repositories.Repository
{
    public class BookRepository : IBookRepository

    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.Include(b => b.Genre).ToListAsync();
        }
       
    }
}
