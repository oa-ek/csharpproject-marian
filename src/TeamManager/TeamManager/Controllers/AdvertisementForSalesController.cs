using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class AdvertisementForSalesController : Controller
    {
        private readonly IRepository<AdvertisementForSales, Guid> _advertisementForSalesRepository;
        private readonly IRepository<GameAccount, Guid> _gameAccountRepository;
        private readonly IRepository<AdvertisementStatus, Guid> _advertisementStatusRepository;
        private readonly IWebHostEnvironment _environment;

        public AdvertisementForSalesController(
            IRepository<AdvertisementForSales, Guid> advertisementForSalesRepository,
            IRepository<GameAccount, Guid> gameAccountRepository,
            IRepository<AdvertisementStatus, Guid> advertisementStatusRepository,
            IWebHostEnvironment environment)
        {
            _advertisementForSalesRepository = advertisementForSalesRepository;
            _gameAccountRepository = gameAccountRepository;
            _advertisementStatusRepository = advertisementStatusRepository;
            _environment = environment;
        }

        // GET: AdvertisementForSales
        public async Task<IActionResult> Index()
        {
            var advertisementsForSales = await _advertisementForSalesRepository.GetAllAsync();
            ViewBag.CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(advertisementsForSales);
        }


        // GET: AdvertisementForSales/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.GameAccounts = (await _gameAccountRepository.GetAllAsync()).ToList();
            ViewBag.AdvertisementStatuses = (await _advertisementStatusRepository.GetAllAsync()).ToList();

            return View(new AdvertisementForSales());
        }

        // POST: AdvertisementForSales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementForSales advertisementForSales, IFormFile imageFile, string gameAccountId, string advertisementStatusId)
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
                    advertisementForSales.MainImage = "img/" + uniqueFileName;
                }
                if (!string.IsNullOrEmpty(gameAccountId))
                {
                    var gameAccount = await _gameAccountRepository.GetAsync(Guid.Parse(gameAccountId));
                    if (gameAccount != null)
                    {
                        advertisementForSales.gameAccount = gameAccount;
                    }
                }
                if (!string.IsNullOrEmpty(advertisementStatusId))
                {
                    var advertisementStatus = await _advertisementStatusRepository.GetAsync(Guid.Parse(advertisementStatusId));
                    if (advertisementStatus != null)
                    {
                        advertisementForSales.advertisementStatus = advertisementStatus;
                    }
                }

                // Призначення ідентифікатора користувача
                advertisementForSales.userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                await _advertisementForSalesRepository.CreateAsync(advertisementForSales);
                return RedirectToAction(nameof(Index));
            }
            return View(advertisementForSales);
        }


        // GET: AdvertisementForSales/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var advertisementForSales = await _advertisementForSalesRepository.GetAsync(id);
            if (advertisementForSales == null)
            {
                return NotFound();
            }
            ViewBag.GameAccounts = (await _gameAccountRepository.GetAllAsync()).ToList();
            ViewBag.AdvertisementStatuses = (await _advertisementStatusRepository.GetAllAsync()).ToList();

            return View(advertisementForSales);
        }

        // POST: AdvertisementForSales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdvertisementForSales advertisementForSales, IFormFile imageFile, string gameAccountId, string advertisementStatusId)
        {
            if (id != advertisementForSales.Id)
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
                        advertisementForSales.MainImage = "img/" + uniqueFileName;
                    }

                    var gameAccount = await _gameAccountRepository.GetAsync(Guid.Parse(gameAccountId));
                    if (gameAccount != null)
                    {
                        advertisementForSales.gameAccount = gameAccount;
                    }

                    var advertisementStatus = await _advertisementStatusRepository.GetAsync(Guid.Parse(advertisementStatusId));
                    if (advertisementStatus != null)
                    {
                        advertisementForSales.advertisementStatus = advertisementStatus;
                    }

                    await _advertisementForSalesRepository.UpdateAsync(advertisementForSales);
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(advertisementForSales.Id))
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
            ViewBag.GameAccounts = (await _gameAccountRepository.GetAllAsync()).ToList();
            ViewBag.AdvertisementStatuses = (await _advertisementStatusRepository.GetAllAsync()).ToList();

            return View(advertisementForSales);
        }

        // GET: AdvertisementForSales/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var advertisementForSales = await _advertisementForSalesRepository.GetAsync(id);
            if (advertisementForSales == null)
            {
                return NotFound();
            }
            return View(advertisementForSales);
        }

        // POST: AdvertisementForSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _advertisementForSalesRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(Guid id)
        {
            return true;
        }
    }
}
