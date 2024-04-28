using Microsoft.AspNetCore.Mvc;
using System;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class AdvertisementToFindController : Controller
    {
        private readonly IRepository<AdvertisementToFind, Guid> _advertisementToFindRepository;
        private readonly IRepository<Game, Guid> _gameRepository;

        public AdvertisementToFindController(

            IRepository<AdvertisementToFind, Guid> advertisementToFindRepository,
            IRepository<Game, Guid> gameRepository
            )
        {
            _advertisementToFindRepository = advertisementToFindRepository;
            _gameRepository = gameRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var advertisementToFind = await _advertisementToFindRepository.GetAllAsync();
            return View(advertisementToFind);
        }

        // GET: Projects/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList();

            return View(new AdvertisementToFind());
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementToFind advertisementToFind, string[] Games)
        {
            if (ModelState.IsValid)
            {
                foreach (var gameId in Games)
                {
                    if (!string.IsNullOrEmpty(gameId))
                    {
                        var game = await _gameRepository.GetAsync(Guid.Parse(gameId));
                        if (game != null)
                        {
                            advertisementToFind.Games.Add(game);
                        }
                    }
                }
                await _advertisementToFindRepository.CreateAsync(advertisementToFind);
                return RedirectToAction(nameof(Index));
            }
            return View(advertisementToFind);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var advertisementToFind = await _advertisementToFindRepository.GetAsync(id);
            if (advertisementToFind == null)
            {
                return NotFound();
            }

            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList(); // Додайте цей рядок для передачі списку ігор у представлення

            return View(advertisementToFind);
        }

        // POST: Projects/Edit/5
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
            ViewBag.Games = (await _gameRepository.GetAllAsync()).ToList(); // Передати список ігор у вигляд, якщо є помилки в ModelState
            return View(advertisementToFind);
        }


        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var advertisementToFind = await _advertisementToFindRepository.GetAsync(id);
            if (advertisementToFind == null)
            {
                return NotFound();
            }
            return View(advertisementToFind);
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

