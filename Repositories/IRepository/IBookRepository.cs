namespace OnlineBookShoping.Repositories.IRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
