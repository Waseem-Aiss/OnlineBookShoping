namespace OnlineBookShoping.Repositories.IRepository
{
    public interface IGenreRepository
    {
     Task<IEnumerable<Genre>> getAllGenre();

     Task AddGenre(Genre genre);
        Task Save();
    }
}
