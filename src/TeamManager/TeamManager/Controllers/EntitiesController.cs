using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class EntitiesController : Controller
    {
        private readonly IRepository<AccountPlatform, Guid> _accountPlatformRepository;//?

        private readonly IRepository<AdvertisementForSales, Guid> _advertisementForSalesRepository;

        private readonly IRepository<AdvertisementStatus, Guid> _advertisementStatusRepository;
        private readonly IRepository<AdvertisementToFind, Guid> _advertisementToFindRepository;//?
        private readonly IRepository<Game, Guid> _gameRepository;
        private readonly IRepository<GameAccount, Guid> _gameAccountRepository;
        private readonly IRepository<UserGroup, Guid> _UserGroupRepository;



        public EntitiesController(
            IRepository<AccountPlatform, Guid> accountPlatformRepository,
            IRepository<AdvertisementForSales, Guid> advertisementForSalesRepository,
            IRepository<AdvertisementStatus, Guid> advertisementStatusRepository,
            IRepository<AdvertisementToFind, Guid> advertisementToFindRepository,
            IRepository<Game, Guid> gameRepository,
            IRepository<GameAccount, Guid> gameAccountRepository,
            IRepository<UserGroup, Guid> userGroupRepository
            )
        {
            _accountPlatformRepository = accountPlatformRepository;
            _advertisementForSalesRepository = advertisementForSalesRepository;
            _advertisementStatusRepository = advertisementStatusRepository;
            _advertisementToFindRepository = advertisementToFindRepository;
            _gameRepository = gameRepository;
            _gameAccountRepository = gameAccountRepository;
            _UserGroupRepository = userGroupRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var advertisementToFind = await _advertisementToFindRepository.GetAllAsync();
            return View(advertisementToFind);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementToFind advertisement)
        {
            if (ModelState.IsValid)
            {
                await _advertisementToFindRepository.CreateAsync(advertisement);
                return RedirectToAction(nameof(Index));
            }
            return View(advertisement);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var advertisement = await _advertisementToFindRepository.GetAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdvertisementToFind advertisement)
        {
            if (id != advertisement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _advertisementToFindRepository.UpdateAsync(advertisement);
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(advertisement.Id))
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
            return View(advertisement);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var advertisement = await _advertisementToFindRepository.GetAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _advertisementToFindRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(Guid id)
        {
            return true;
        }
    }
}

