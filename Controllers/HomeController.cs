using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShoping.Models;
using OnlineBookShoping.Models.DTOs;

namespace OnlineBookShoping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }




        public async Task<IActionResult> Index(string sTerm="",int genreId =0, int pageNumber = 1)
        {
           var (books , totalPages) = await _homeRepository.GetBooks(sTerm, genreId,8,pageNumber);
            IEnumerable<Genre> Genres = await _homeRepository.Genres();

            BookDisplayModel bookModel = new BookDisplayModel
            {
                Books = books,
                Genres = Genres,
                pageSize = 8,
                totalPages = totalPages,
                currentPage = pageNumber,
                sTerm=sTerm,
                genreId=genreId
            };




            return View(bookModel);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
