using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;


namespace TeamManager.Controllers
{
    public class GameAccountController : Controller
    {
        private readonly IRepository<GameAccount, Guid> _gameAccountRepository;
        private readonly IWebHostEnvironment _environment;

        public GameAccountController(
            IRepository<GameAccount, Guid> gameAccountRepository,
            IWebHostEnvironment environment
            )
        {
            _gameAccountRepository = gameAccountRepository;
            _environment = environment;
        }

        // GET: GameAccounts
        public async Task<IActionResult> Index()
        {
            var gameAccounts = await _gameAccountRepository.GetAllAsync();
            return View(gameAccounts);
        }

        // GET: GameAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameAccount gameAccount, IFormFile imageFile)
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
                    gameAccount.MainImage = "img/" + uniqueFileName;
                }

                await _gameAccountRepository.CreateAsync(gameAccount);
                return RedirectToAction(nameof(Index));
            }
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
            return View(gameAccount);
        }

        // POST: GameAccounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GameAccount gameAccount, IFormFile imageFile)
        {
            if (id != gameAccount.Id)
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
                        gameAccount.MainImage = "/uploads/" + uniqueFileName;
                    }

                    await _gameAccountRepository.UpdateAsync(gameAccount);
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
                return RedirectToAction(nameof(Index));
            }
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
            return true;
        }
    }
}
