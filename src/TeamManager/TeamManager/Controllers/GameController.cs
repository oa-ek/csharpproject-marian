using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class GameController : Controller
    {
        private readonly IRepository<Game, Guid> _gameRepository;
        private readonly IWebHostEnvironment _environment;

        public GameController(
            IRepository<Game, Guid> gameRepository,
            IWebHostEnvironment environment
            )
        {
            _gameRepository = gameRepository;
            _environment = environment;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var game = await _gameRepository.GetAllAsync();
            return View(game);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();

        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game Game, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Save uploaded image to wwwroot/img directory
                    var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    Game.MainImage = "img/" + uniqueFileName;
                }

                await _gameRepository.CreateAsync(Game);
                return RedirectToAction(nameof(Index));
            }
            return View(Game);
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
        public async Task<IActionResult> Edit(Guid id, Game game, IFormFile imageFile)
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
                        // Save the new image file
                        var uploadsDir = Path.Combine(_environment.WebRootPath, "uploads");
                        if (!Directory.Exists(uploadsDir))
                        {
                            Directory.CreateDirectory(uploadsDir);
                        }
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                        var filePath = Path.Combine(uploadsDir, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                        game.MainImage = "/uploads/" + uniqueFileName;
                    }

                    await _gameRepository.UpdateAsync(game);
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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

        private bool AdvertisementExists(Guid id)
        {
            return true;
        }
    }
}
