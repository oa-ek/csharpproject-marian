using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class AccountPlatformController : Controller
    {
        private readonly IRepository<Platform, Guid> _accountPlatformRepository;
        public AccountPlatformController(
            IRepository<Platform, Guid> accountPlatformRepository
            )
        {
            _accountPlatformRepository = accountPlatformRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var accountPlatform = await _accountPlatformRepository.GetAllAsync();
            return View(accountPlatform);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Platform accountPlatform)
        {
            if (ModelState.IsValid)
            {
                await _accountPlatformRepository.CreateAsync(accountPlatform);
                return RedirectToAction(nameof(Index));
            }
            return View(accountPlatform);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var accountPlatform = await _accountPlatformRepository.GetAsync(id);
            if (accountPlatform == null)
            {
                return NotFound();
            }
            return View(accountPlatform);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Platform accountPlatform)
        {
            if (id != accountPlatform.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _accountPlatformRepository.UpdateAsync(accountPlatform);
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(accountPlatform.Id))
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
            return View(accountPlatform);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var accountPlatform = await _accountPlatformRepository.GetAsync(id);
            if (accountPlatform == null)
            {
                return NotFound();
            }
            return View(accountPlatform);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _accountPlatformRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(Guid id)
        {
            return true;
        }
    }
}
