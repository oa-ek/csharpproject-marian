using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class AdvertisementForSalesController : Controller
    {
        private readonly IRepository<AdvertisementForSales, Guid> _advertisementForSalesRepository;

        public AdvertisementForSalesController(
            IRepository<AdvertisementForSales, Guid> advertisementForSalesRepository
            )
        {
            _advertisementForSalesRepository = advertisementForSalesRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var advertisementForSales = await _advertisementForSalesRepository.GetAllAsync();
            return View(advertisementForSales);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementForSales advertisementForSales)
        {
            if (ModelState.IsValid)
            {
                await _advertisementForSalesRepository.CreateAsync(advertisementForSales);
                return RedirectToAction(nameof(Index));
            }
            return View(advertisementForSales);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var advertisementForSales = await _advertisementForSalesRepository.GetAsync(id);
            if (advertisementForSales == null)
            {
                return NotFound();
            }
            return View(advertisementForSales);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdvertisementForSales advertisementForSales)
        {
            if (id != advertisementForSales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            return View(advertisementForSales);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var advertisementForSales = await _advertisementForSalesRepository.GetAsync(id);
            if (advertisementForSales == null)
            {
                return NotFound();
            }
            return View(advertisementForSales);
        }

        // POST: Projects/Delete/5
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
