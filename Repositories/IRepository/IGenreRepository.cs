namespace OnlineBookShoping.Repositories.IRepository
{
    public interface IGenreRepository
    {
     Task<IEnumerable<Genre>> getAllGenre();

     Task AddGenre(Genre genre);
        Task Save();

    Task <Genre> GetGenreById(int id);

    Task UpdateGenre(Genre genre);

   Task DeleteGenre(Genre rec);

    }
}
