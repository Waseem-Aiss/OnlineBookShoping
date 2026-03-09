namespace OnlineBookShoping.Repositories.IRepository
{
    public interface IBookRepository
    {
        Task<(IEnumerable<Book> book, int totalPages)> GetAllBooksAdmin(string sTerm = "", int genreId = 0, int pageSize = 8, int pageNumber = 1);
        Task<IEnumerable<Genre>> Genres();
         Task<Book> BookEdit(int bookId);
        Task AddEditedBook(Book book);
        Task DeletBookbyId(int id);
        Book BookDetail(int id);

    
    } 
}
