using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineBookShoping.Repositories.IRepository;
using OnlineBookShoping.Repositories.Repository;

namespace OnlineBookShoping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> Index(string sTerm = "", int genreId = 0, int pageNumber = 1)
        {
            var (books, totalPages) = await _bookRepository.GetAllBooksAdmin(sTerm, genreId, 8, pageNumber);
            IEnumerable<Genre> Genres = await _bookRepository.Genres();

            BookDisplayModel bookModel = new BookDisplayModel
            {
                Books = books,
                Genres = Genres,
                pageSize = 8,
                totalPages = totalPages,
                currentPage = pageNumber,
                sTerm = sTerm,
                genreId = genreId
            };

            return View(bookModel);
        }

    }
}
