namespace OnlineBookShoping.Repositories
{
    public interface IHomeRepository
    {
 Task<(IEnumerable<Book> books, int totalPages)> GetBooks(string sTerm = "", int genreId = 0,
     int pageSize=8,int pageNumber=1);
        Task<IEnumerable<Genre>> Genres();

    }
}