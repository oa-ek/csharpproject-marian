using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    [Authorize]
    public class AdvertisementForSalesController : Controller
    {
        private readonly IRepository<AdvertisementForSales, Guid> _advertisementRepository;
        private readonly IRepository<GameAccount, Guid> _gameAccountRepository;
        private readonly IRepository<AdvertisementStatus, Guid> _advertisementStatusRepository;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _environment;

        public AdvertisementForSalesController(
            IRepository<AdvertisementForSales, Guid> advertisementRepository,
            IRepository<GameAccount, Guid> gameAccountRepository,
            IRepository<AdvertisementStatus, Guid> advertisementStatusRepository,
            UserManager<User> userManager,
            IWebHostEnvironment environment)
        {
            _advertisementRepository = advertisementRepository;
            _gameAccountRepository = gameAccountRepository;
            _advertisementStatusRepository = advertisementStatusRepository;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: AdvertisementForSales
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var advertisements = (await _advertisementRepository.GetAllAsync()).ToList();
            ViewBag.CurrentUserId = currentUser?.Id;

            var userEmails = new Dictionary<Guid, string>();
            var userIds = advertisements.Select(a => a.userId).Distinct();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                advertisements = advertisements.Where(gf => gf.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            ViewBag.SearchTerm = searchTerm;

            foreach (var userIdNullable in userIds)
            {
                if (userIdNullable.HasValue)
                {
                    var userId = userIdNullable.Value;
                    var user = await _userManager.FindByIdAsync(userId.ToString());
                    if (user != null)
                    {
                        userEmails.Add(userId, user.Email);
                    }
                }
            }

            ViewBag.UserEmails = userEmails;
            return View(advertisements);
        }

        // GET: AdvertisementForSales/Create
        public async Task<IActionResult> CreateAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var gameAccounts = await _gameAccountRepository.GetAllAsync();

            ViewBag.GameAccounts = gameAccounts.ToList();
            ViewBag.AdvertisementStatuses = (await _advertisementStatusRepository.GetAllAsync()).ToList();

            return View(new AdvertisementForSales());
        }

        // POST: AdvertisementForSales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementForSales advertisement, IFormFile imageFile, string advertisementStatusId)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                advertisement.User = currentUser;
                advertisement.userId = currentUser.Id;

                if (imageFile != null)
                {
                    advertisement.MainImage = await SaveImageAsync(imageFile);
                }

                await _advertisementRepository.CreateAsync(advertisement);

                return RedirectToAction(nameof(Index));
            }
            if (!string.IsNullOrEmpty(advertisementStatusId))
            {
                var advertisementStatus = await _advertisementStatusRepository.GetAsync(Guid.Parse(advertisementStatusId));
                if (advertisementStatus != null)
                {
                    advertisement.advertisementStatus = advertisementStatus;
                }
            }

            var gameAccounts = await _gameAccountRepository.GetAllAsync();
            var advertisementStatuses = await _advertisementStatusRepository.GetAllAsync();

            ViewBag.GameAccounts = gameAccounts.ToList();
            ViewBag.AdvertisementStatuses = advertisementStatuses.ToList();

            return View(advertisement);
        }

        // GET: AdvertisementForSales/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var advertisement = await _advertisementRepository.GetAsync(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (advertisement.userId != currentUser.Id && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            var gameAccounts = await _gameAccountRepository.GetAllAsync();
            var advertisementStatuses = await _advertisementStatusRepository.GetAllAsync();

            ViewBag.GameAccounts = gameAccounts.ToList();
            ViewBag.AdvertisementStatuses = advertisementStatuses.ToList();

            return View(advertisement);
        }

        // POST: AdvertisementForSales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdvertisementForSales advertisement, IFormFile imageFile)
        {
            if (id != advertisement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingAdvertisement = await _advertisementRepository.GetAsync(id);

                    if (existingAdvertisement == null)
                    {
                        return NotFound();
                    }

                    var currentUser = await _userManager.GetUserAsync(User);

                    if (existingAdvertisement.userId != currentUser.Id && !User.IsInRole("Admin"))
                    {
                        return Forbid();
                    }

                    existingAdvertisement.Name = advertisement.Name;
                    existingAdvertisement.Description = advertisement.Description;
                    existingAdvertisement.Price = advertisement.Price;
                    existingAdvertisement.IsActive = advertisement.IsActive;
                    existingAdvertisement.gameAccountId = advertisement.gameAccountId;
                    existingAdvertisement.advertisementStatusId = advertisement.advertisementStatusId;

                    if (imageFile != null)
                    {
                        existingAdvertisement.MainImage = await SaveImageAsync(imageFile);
                    }

                    await _advertisementRepository.UpdateAsync(existingAdvertisement);

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
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
            }

            var gameAccounts = await _gameAccountRepository.GetAllAsync();
            var advertisementStatuses = await _advertisementStatusRepository.GetAllAsync();

            ViewBag.GameAccounts = gameAccounts.ToList();
            ViewBag.AdvertisementStatuses = advertisementStatuses.ToList();

            return View(advertisement);
        }

        // GET: AdvertisementForSales/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var advertisement = await _advertisementRepository.GetAsync(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (advertisement.userId != currentUser.Id && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            return View(advertisement);
        }

        // POST: AdvertisementForSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var advertisement = await _advertisementRepository.GetAsync(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (advertisement.userId != currentUser.Id && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            await _advertisementRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "img");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return $"img/{uniqueFileName}";
        }

        private bool AdvertisementExists(Guid id)
        {
            return _advertisementRepository.GetAsync(id) != null;
        }
    }
}
