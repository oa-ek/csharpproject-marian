using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IRepository<Developer, Guid> _developerRepository;

        public DeveloperController(IRepository<Developer, Guid> developerRepository)
        {
            _developerRepository = developerRepository;
        }

        // GET: Developers
        public async Task<IActionResult> Index()
        {
            var developers = await _developerRepository.GetAllAsync();
            return View(developers);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Developer developer)
        {
            if (ModelState.IsValid)
            {
                await _developerRepository.CreateAsync(developer);
                return RedirectToAction(nameof(Index));
            }
            return View(developer);
        }

        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var developer = await _developerRepository.GetAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }

        // POST: Developers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Developer developer)
        {
            if (id != developer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _developerRepository.UpdateAsync(developer);
                }
                catch (Exception)
                {
                    if (!DeveloperExists(developer.Id))
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
            return View(developer);
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var developer = await _developerRepository.GetAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _developerRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DeveloperExists(Guid id)
        {
            return true;
        }
    }
}
