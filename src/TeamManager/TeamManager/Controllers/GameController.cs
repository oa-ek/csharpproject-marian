using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class GameController : Controller
    {
        private readonly IRepository<Game, Guid> _gameRepository;
        private readonly IRepository<Platform, Guid> _platformsRepository;
        private readonly IRepository<Genre, Guid> _genresRepository;
        private readonly IRepository<Language, Guid> _languagesRepository;
        private readonly IRepository<Developer, Guid> _developersRepository;
        private readonly IWebHostEnvironment _environment;

        public GameController(
            IRepository<Game, Guid> gameRepository,
            IRepository<Platform, Guid> platformsRepository,
            IRepository<Genre, Guid> genresRepository,
            IRepository<Language, Guid> languagesRepository,
            IRepository<Developer, Guid> developersRepository,
            IWebHostEnvironment environment
            )
        {
            _gameRepository = gameRepository;
            _environment = environment;
            _platformsRepository = platformsRepository;
            _genresRepository = genresRepository;
            _languagesRepository = languagesRepository;
            _developersRepository = developersRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            var game = (await _gameRepository.GetAllAsync()).ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                game = game.Where(gf => gf.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            ViewBag.SearchTerm = searchTerm;

            return View(game);
        }

        // GET: Projects/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Platforms = (await _platformsRepository.GetAllAsync()).ToList();
            ViewBag.Genres = (await _genresRepository.GetAllAsync()).ToList();
            ViewBag.Languages = (await _languagesRepository.GetAllAsync()).ToList();
            ViewBag.Developers = (await _developersRepository.GetAllAsync()).ToList();
            return View(new Game());
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game, IFormFile imageFile, string[] Platforms, string[] Genres, string[] Languages, string[] Developers)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    game.MainImage = "img/" + uniqueFileName;
                }

                foreach (var platformId in Platforms)
                {
                    if (!string.IsNullOrEmpty(platformId))
                    {
                        var platform = await _platformsRepository.GetAsync(Guid.Parse(platformId));
                        if (platform != null)
                        {
                            game.Platforms.Add(platform);
                        }
                    }
                }

                foreach (var genreId in Genres)
                {
                    if (!string.IsNullOrEmpty(genreId))
                    {
                        var genre = await _genresRepository.GetAsync(Guid.Parse(genreId));
                        if (genre != null)
                        {
                            game.Genres.Add(genre);
                        }
                    }
                }

                foreach (var languageId in Languages)
                {
                    if (!string.IsNullOrEmpty(languageId))
                    {
                        var language = await _languagesRepository.GetAsync(Guid.Parse(languageId));
                        if (language != null)
                        {
                            game.Languages.Add(language);
                        }
                    }
                }

                foreach (var developerId in Developers)
                {
                    if (!string.IsNullOrEmpty(developerId))
                    {
                        var developer = await _developersRepository.GetAsync(Guid.Parse(developerId));
                        if (developer != null)
                        {
                            game.Developers.Add(developer);
                        }
                    }
                }

                await _gameRepository.CreateAsync(game);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Platforms = await _platformsRepository.GetAllAsync();
            ViewBag.Genres = await _genresRepository.GetAllAsync();
            ViewBag.Languages = await _languagesRepository.GetAllAsync();
            ViewBag.Developers = await _developersRepository.GetAllAsync();

            return View(game);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var game = await _gameRepository.GetAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Game game, IFormFile imageFile, string[] Platforms, string[] Genres, string[] Languages, string[] Developers)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                        var filePath = Path.Combine(uploadsDir, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                        game.MainImage = "img/" + uniqueFileName;
                    }

                    var gameToUpdate = await _gameRepository.GetAsync(id);
                    if (gameToUpdate == null)
                    {
                        return NotFound();
                    }

                    gameToUpdate.Name = game.Name;
                    gameToUpdate.Description = game.Description;
                    gameToUpdate.Price = game.Price;
                    gameToUpdate.ReleasedDate = game.ReleasedDate;

                    gameToUpdate.Platforms.Clear();
                    foreach (var platformId in Platforms)
                    {
                        if (!string.IsNullOrEmpty(platformId))
                        {
                            var platform = await _platformsRepository.GetAsync(Guid.Parse(platformId));
                            if (platform != null)
                            {
                                gameToUpdate.Platforms.Add(platform);
                            }
                        }
                    }

                    gameToUpdate.Genres.Clear();
                    foreach (var genreId in Genres)
                    {
                        if (!string.IsNullOrEmpty(genreId))
                        {
                            var genre = await _genresRepository.GetAsync(Guid.Parse(genreId));
                            if (genre != null)
                            {
                                gameToUpdate.Genres.Add(genre);
                            }
                        }
                    }

                    gameToUpdate.Languages.Clear();
                    foreach (var languageId in Languages)
                    {
                        if (!string.IsNullOrEmpty(languageId))
                        {
                            var language = await _languagesRepository.GetAsync(Guid.Parse(languageId));
                            if (language != null)
                            {
                                gameToUpdate.Languages.Add(language);
                            }
                        }
                    }

                    gameToUpdate.Developers.Clear();
                    foreach (var developerId in Developers)
                    {
                        if (!string.IsNullOrEmpty(developerId))
                        {
                            var developer = await _developersRepository.GetAsync(Guid.Parse(developerId));
                            if (developer != null)
                            {
                                gameToUpdate.Developers.Add(developer);
                            }
                        }
                    }

                    await _gameRepository.UpdateAsync(gameToUpdate);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }
            }

            ViewBag.Platforms = await _platformsRepository.GetAllAsync();
            ViewBag.Genres = await _genresRepository.GetAllAsync();
            ViewBag.Languages = await _languagesRepository.GetAllAsync();
            ViewBag.Developers = await _developersRepository.GetAllAsync();

            return View(game);
        }


        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var game = await _gameRepository.GetAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _gameRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(Guid id)
        {
            return true;
        }
    }
}
