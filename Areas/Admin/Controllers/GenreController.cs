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
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id==0)
            {
                return NotFound();
            }
            else
            {
                var genreFromDb = await _genreRepository.GetGenreById(id);

                if (genreFromDb == null)
                {
                    return NotFound();
                }
                
             return View(genreFromDb);
                
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Genre rec)
        {

            ModelState.Remove("Books");
            if (!ModelState.IsValid)
            {
                return View(rec);
            }
            else
            {
                await _genreRepository.UpdateGenre(rec);
                await _genreRepository.Save();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
                var genreFromDb = await _genreRepository.GetGenreById(id);

                return View(genreFromDb);
        }
       
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRec(int Id)
        {       
           Genre recForDel =  await _genreRepository.GetGenreById(Id);
                await _genreRepository.DeleteGenre(recForDel);
                await _genreRepository.Save();
            
                return RedirectToAction("Index");
        }

    }
}

