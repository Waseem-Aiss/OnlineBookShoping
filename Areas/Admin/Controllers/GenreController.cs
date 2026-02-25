using Microsoft.AspNetCore.Mvc;
using OnlineBookShoping.Controllers;
using OnlineBookShoping.Repositories.IRepository;
using OnlineBookShoping.Repositories.Repository;

namespace OnlineBookShoping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
       private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository )
        {
            _genreRepository = genreRepository;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Genre> allgenres =  await _genreRepository.getAllGenre();
            return View(allgenres);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            ModelState.Remove("Books");
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            else
            {
            await _genreRepository.AddGenre(genre);
              await  _genreRepository.Save();
            }
            return RedirectToAction("Index");
        }

    }
}
