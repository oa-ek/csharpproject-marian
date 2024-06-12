using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    [Authorize]
    public class AdvertisementToFindController : Controller
    {
        private readonly IRepository<AdvertisementToFind, Guid> _advertisementToFindRepository;
        private readonly IRepository<Game, Guid> _gameRepository;
        private readonly UserManager<User> _userManager;

        public AdvertisementToFindController(
            IRepository<AdvertisementToFind, Guid> advertisementToFindRepository,
            IRepository<Game, Guid> gameRepository,
            UserManager<User> userManager)
        {
            _advertisementToFindRepository = advertisementToFindRepository;
            _gameRepository = gameRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var advertisementsToFind = await _advertisementToFindRepository.GetAllAsync();
            ViewBag.CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(advertisementsToFind);
        }


        // GET: AdvertisementToFind/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();
            return View(new AdvertisementToFind());
        }

        // POST: AdvertisementToFind/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementToFind advertisementToFind, List<Guid> selectedGameIds)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                advertisementToFind.userId = Guid.Parse(userId);

                if (selectedGameIds != null && selectedGameIds.Count > 0)
                {
                    var selectedGames = await _gameRepository.GetAllAsync();
                    advertisementToFind.Games = selectedGames.Where(g => selectedGameIds.Contains(g.Id)).ToList();
                }

                await _advertisementToFindRepository.CreateAsync(advertisementToFind);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();
            return View(advertisementToFind);
        }

        // GET: AdvertisementToFind/Index


        // GET: AdvertisementToFind/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var advertisementToFind = await _advertisementToFindRepository.GetAsync(id);
            if (advertisementToFind == null)
            {
                return NotFound();
            }

            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();
            return View(advertisementToFind);
        }

        // POST: AdvertisementToFind/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdvertisementToFind advertisementToFind, string[] Games)
        {
            if (id != advertisementToFind.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var advertisementToUpdate = await _advertisementToFindRepository.GetAsync(id);
                    if (advertisementToUpdate == null)
                    {
                        return NotFound();
                    }

                    advertisementToUpdate.Name = advertisementToFind.Name;
                    advertisementToUpdate.Description = advertisementToFind.Description;
                    advertisementToUpdate.Price = advertisementToFind.Price;
                    advertisementToUpdate.IsActive = advertisementToFind.IsActive;

                    advertisementToUpdate.Games.Clear();
                    foreach (var gameId in Games)
                    {
                        if (!string.IsNullOrEmpty(gameId))
                        {
                            var game = await _gameRepository.GetAsync(Guid.Parse(gameId));
                            if (game != null)
                            {
                                advertisementToUpdate.Games.Add(game);
                            }
                        }
                    }

                    await _advertisementToFindRepository.UpdateAsync(advertisementToUpdate);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(advertisementToFind.Id))
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
            return View(advertisementToFind);
        }

        // GET: AdvertisementToFind/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var advertisementToFind = await _advertisementToFindRepository.GetAsync(id);
            if (advertisementToFind == null)
            {
                return NotFound();
            }
            return View(advertisementToFind);
        }

        // POST: AdvertisementToFind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _advertisementToFindRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(Guid id)
        {
            return _advertisementToFindRepository.GetAsync(id) != null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JoinGroup(Guid id)
        {
            var advertisement = await _advertisementToFindRepository.GetAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Forbid();
            }

            advertisement.User?.UserGroups.Add(new UserGroup
            {
                Name = $"Group for {advertisement.Name}",
                Description = $"Group created from advertisement {advertisement.Name}",
                Users = new List<User> { currentUser }
            });

            await _advertisementToFindRepository.UpdateAsync(advertisement);
            return RedirectToAction(nameof(Index));
        }
    }
}
