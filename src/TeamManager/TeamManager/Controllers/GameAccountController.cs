using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;
using System.Security.Claims;

namespace TeamManager.Controllers
{
    public class GameAccountController : Controller
    {
        private readonly IRepository<GameAccount, Guid> _gameAccountRepository;
        private readonly IRepository<Game, Guid> _gameRepository;
        private readonly IRepository<Platform, Guid> _platformRepository;
        private readonly IWebHostEnvironment _environment;

        public GameAccountController(
            IRepository<GameAccount, Guid> gameAccountRepository,
            IRepository<Game, Guid> gameRepository,
            IRepository<Platform, Guid> platformRepository,
            IWebHostEnvironment environment)
        {
            _gameAccountRepository = gameAccountRepository;
            _gameRepository = gameRepository;
            _platformRepository = platformRepository;
            _environment = environment;
        }

        // GET: GameAccounts
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            var gameAccounts = (await _gameAccountRepository.GetAllAsync()).ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                gameAccounts = gameAccounts.Where(gf => gf.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.SearchTerm = searchTerm;
            return View(gameAccounts);
        }

        // GET: GameAccounts/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();
            ViewBag.Platforms = (await _platformRepository.GetAllAsync()).ToList();
            return View(new GameAccount());
        }

        // POST: GameAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameAccount gameAccount, IFormFile imageFile, string[] Games)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                gameAccount.userId = Guid.Parse(currentUserId);

                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    gameAccount.MainImage = "img/" + uniqueFileName;
                }

                foreach (var gameId in Games)
                {
                    if (!string.IsNullOrEmpty(gameId))
                    {
                        var game = await _gameRepository.GetAsync(Guid.Parse(gameId));
                        if (game != null)
                        {
                            gameAccount.Games.Add(game);
                        }
                    }
                }

                await _gameAccountRepository.CreateAsync(gameAccount);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Games = await _gameRepository.GetAllAsync();
            ViewBag.Platforms = await _platformRepository.GetAllAsync();

            return View(gameAccount);
        }

        // GET: GameAccounts/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var gameAccount = await _gameAccountRepository.GetAsync(id);
            if (gameAccount == null)
            {
                return NotFound();
            }

            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();
            ViewBag.Platforms = (await _platformRepository.GetAllAsync()).ToList();
            return View(gameAccount);
        }

        // POST: GameAccounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GameAccount gameAccount, IFormFile imageFile, string[] Games)
        {
            if (id != gameAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    gameAccount.userId = Guid.Parse(currentUserId);

                    var gameAccountToUpdate = await _gameAccountRepository.GetAsync(id);
                    if (gameAccountToUpdate == null)
                    {
                        return NotFound();
                    }

                    gameAccountToUpdate.Name = gameAccount.Name;
                    gameAccountToUpdate.accountPlatformId = gameAccount.accountPlatformId;
                    gameAccountToUpdate.Games.Clear();

                    foreach (var gameId in Games)
                    {
                        if (!string.IsNullOrEmpty(gameId))
                        {
                            var game = await _gameRepository.GetAsync(Guid.Parse(gameId));
                            if (game != null)
                            {
                                gameAccountToUpdate.Games.Add(game);
                            }
                        }
                    }

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                        var filePath = Path.Combine(uploadsDir, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                        gameAccountToUpdate.MainImage = "img/" + uniqueFileName;
                    }

                    await _gameAccountRepository.UpdateAsync(gameAccountToUpdate);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    if (!GameAccountExists(gameAccount.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();
            return View(gameAccount);
        }

        // GET: GameAccounts/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var gameAccount = await _gameAccountRepository.GetAsync(id);
            if (gameAccount == null)
            {
                return NotFound();
            }
            return View(gameAccount);
        }

        // POST: GameAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _gameAccountRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GameAccountExists(Guid id)
        {
            return _gameAccountRepository.GetAsync(id) != null;
        }
    }
}
