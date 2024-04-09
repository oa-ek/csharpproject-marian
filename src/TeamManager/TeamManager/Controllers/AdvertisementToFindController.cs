using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class AdvertisementToFindController : Controller
    {
        private readonly IRepository<AdvertisementToFind, Guid> _advertisementToFindRepository;

        public AdvertisementToFindController(

            IRepository<AdvertisementToFind, Guid> advertisementToFindRepository
            )
        {
            _advertisementToFindRepository = advertisementToFindRepository;

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
        public async Task<IActionResult> Create(AdvertisementToFind advertisementToFind)
        {
            if (ModelState.IsValid)
            {
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
            return View(advertisementToFind);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdvertisementToFind advertisementToFind)
        {
            if (id != advertisementToFind.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _advertisementToFindRepository.UpdateAsync(advertisementToFind);
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
                return RedirectToAction(nameof(Index));
            }
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

