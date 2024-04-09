using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class GameAccountController : Controller
    {
        private readonly IRepository<GameAccount, Guid> _gameAccountRepository;

        public GameAccountController(
            IRepository<GameAccount, Guid> gameAccountRepository
            )
        {
            _gameAccountRepository = gameAccountRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var gameAccount = await _gameAccountRepository.GetAllAsync();
            return View(gameAccount);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameAccount gameAccount)
        {
            if (ModelState.IsValid)
            {
                await _gameAccountRepository.CreateAsync(gameAccount);
                return RedirectToAction(nameof(Index));
            }
            return View(gameAccount);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var gameAccount = await _gameAccountRepository.GetAsync(id);
            if (gameAccount == null)
            {
                return NotFound();
            }
            return View(gameAccount);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GameAccount gameAccount)
        {
            if (id != gameAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gameAccountRepository.UpdateAsync(gameAccount);
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(gameAccount.Id))
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

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var gameAccount = await _gameAccountRepository.GetAsync(id);
            if (gameAccount == null)
            {
                return NotFound();
            }
            return View(gameAccount);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _gameAccountRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(Guid id)
        {
            return true;
        }
    }
}
