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

       public async Task<(IEnumerable<Book> book, int totalPages)> GetAllBooksAdmin(string sTerm = "", int genreId = 0,
            int pageSize = 8, int pageNumber = 1)
        {
            var book = from Book in _dbContext.Books
                       join Genre in _dbContext.Genres
                       on Book.GenreId equals Genre.Id
                       where string.IsNullOrWhiteSpace(sTerm) || (Book != null && Book.BookName.ToLower().StartsWith(sTerm))
                       select new Book
                       {
                           id = Book.id,
                           AuthorName = Book.AuthorName,
                           BookName = Book.BookName,
                           GenreId = Book.GenreId,
                           Price = Book.Price,
                           GenreName = Genre.GenreName,
                       };
            if (genreId > 0)
            {
                book = book.Where(s => s.GenreId == genreId);
            }
            int totalBooks =await book.CountAsync();
            int totalViewPages =(int) Math.Ceiling(totalBooks / (double)pageSize);
            var pageData = await book.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return (pageData, totalViewPages);
        }

       public async Task<IEnumerable<Genre>> Genres()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<Book> BookEdit(int bookId)
        {
           Book resBook =  await _dbContext.Books.FindAsync(bookId);
            return resBook;

        }

        public async Task AddEditedBook(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
    public async Task DeletBookbyId(int id)
        {
            Book delBook = await _dbContext.Books.FindAsync(id);
           
          _dbContext.Books.Remove(delBook);
          await  _dbContext.SaveChangesAsync();

        }
        public Book BookDetail(int id)
        {
            Book foundBook =  _dbContext.Books.Include(b => b.Genre).FirstOrDefault(b=>b.id == id) ;


            return (foundBook);
        }






    }
}
