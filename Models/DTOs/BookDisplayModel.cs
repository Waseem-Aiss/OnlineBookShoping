namespace OnlineBookShoping.Models.DTOs
{
    public class BookDisplayModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
        public string sTerm { get; set; } = "";
        public int genreId { get; set; } = 0;

    }
}
