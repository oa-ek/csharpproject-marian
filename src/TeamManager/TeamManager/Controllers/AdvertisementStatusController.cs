using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class AdvertisementStatusController : Controller
    {
        private readonly IRepository<AdvertisementStatus, Guid> _advertisementStatusRepository;

        public AdvertisementStatusController(
            IRepository<AdvertisementStatus, Guid> advertisementStatusRepository
            )
        {
            _advertisementStatusRepository = advertisementStatusRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var advertisementStatus = await _advertisementStatusRepository.GetAllAsync();
            return View(advertisementStatus);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementStatus advertisementStatus)
        {
            if (ModelState.IsValid)
            {
                await _advertisementStatusRepository.CreateAsync(advertisementStatus);
                return RedirectToAction(nameof(Index));
            }
            return View(advertisementStatus);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var advertisementStatus = await _advertisementStatusRepository.GetAsync(id);
            if (advertisementStatus == null)
            {
                return NotFound();
            }
            return View(advertisementStatus);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdvertisementStatus advertisementStatus)
        {
            if (id != advertisementStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _advertisementStatusRepository.UpdateAsync(advertisementStatus);
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(advertisementStatus.Id))
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
            return View(advertisementStatus);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var advertisementStatus = await _advertisementStatusRepository.GetAsync(id);
            if (advertisementStatus == null)
            {
                return NotFound();
            }
            return View(advertisementStatus);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _advertisementStatusRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(Guid id)
        {
            return true;
        }
    }
}
