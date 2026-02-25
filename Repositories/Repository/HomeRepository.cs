
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineBookShoping.Repositories.IRepository;

namespace OnlineBookShoping.Repositories.Repository
{

    
    public class HomeRepository :   IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepository(ApplicationDbContext db)
        {
           _dbContext = db;
        }
        public async Task<IEnumerable<Genre>> Genres() {
        
        return await _dbContext.Genres.ToListAsync();
        }

        public async Task<(IEnumerable<Book> books, int totalPages)> GetBooks(string sTerm="",int genreId = 0,
            int pageSize = 8,int pageNumber =1)
        {
            sTerm = sTerm.ToLower();

            var book =  from Book in _dbContext.Books
                              join Genre in _dbContext.Genres
                              on Book.GenreId equals Genre.Id
                              where string.IsNullOrWhiteSpace(sTerm) || (Book != null && Book.BookName.ToLower().StartsWith(sTerm))
                              select new Book
                              {
                                  id = Book.GenreId,
                                  Image = Book.Image,
                                  AuthorName = Book.AuthorName,
                                  BookName = Book.BookName,
                                  GenreId = Book.GenreId,
                                  Price = Book.Price,
                                  GenreName = Genre.GenreName,
                              };

            if(genreId > 0)
            {
                book = book.Where(a => a.GenreId == genreId);
            }
            
            int totalBooks = await book.CountAsync();
            int totalViewPages = (int)Math.Ceiling((totalBooks / (double)pageSize));
            var pageData = await book.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (pageData,totalViewPages);
                        
        }


    }

   
}
