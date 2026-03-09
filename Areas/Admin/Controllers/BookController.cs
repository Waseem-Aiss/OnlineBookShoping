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

        public async Task<IActionResult> Edit(int id)
        {
            Book resBook = await _bookRepository.BookEdit(id);
            return View(resBook);
        }

       
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {

          await _bookRepository.AddEditedBook(book);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletBookbyId(int id)
        {
            await _bookRepository.DeletBookbyId(id);
            return RedirectToAction("Index");
        }
       public  IActionResult BookDetail(int id)
        {
            Book detBook =  _bookRepository.BookDetail(id);
            
            return View(detBook);
        }


    }
}
