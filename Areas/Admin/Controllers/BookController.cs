using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineBookShoping.Repositories.IRepository;

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
        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> ResultBooks = await _bookRepository.GetAllBooks();
            return View(ResultBooks);
        }
             
    }
}
