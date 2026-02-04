
using Microsoft.EntityFrameworkCore;

namespace OnlineBookShoping.Repositories
{

    
    public class HomeRepository :   IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepository(ApplicationDbContext db)
        {
           _dbContext = db;
        }
        public async Task<IEnumerable<Book>> GetBooks(string sTerm="",int genreId = 0)
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

            return await book.ToListAsync();
                        
        }


    }

   
}
