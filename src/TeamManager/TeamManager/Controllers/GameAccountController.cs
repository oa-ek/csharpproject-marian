using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

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
        public async Task<IActionResult> Index()
        {
            var gameAccounts = await _gameAccountRepository.GetAllAsync();
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
                    var gameAccountToUpdate = await _gameAccountRepository.GetAsync(id);
                    if (gameAccountToUpdate == null)
                    {
                        return NotFound();
                    }

                    // Оновлення властивостей моделі gameAccountToUpdate з отриманими з форми значеннями
                    gameAccountToUpdate.Name = gameAccount.Name;
                    gameAccountToUpdate.accountPlatformId = gameAccount.accountPlatformId;

                    // Очистка списку ігор та додавання нових
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

                    // Перевірка і завантаження зображення, якщо воно було вибрано
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

                    // Оновлення моделі в репозиторії
                    await _gameAccountRepository.UpdateAsync(gameAccountToUpdate);

                    // Перенаправлення на дію Index після успішного оновлення
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Обробка винятку у разі невдачі оновлення
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

            // Якщо ModelState не є валідним, повертаємо форму знову з поточними значеннями
            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();
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
            return true;
        }
    }
}
