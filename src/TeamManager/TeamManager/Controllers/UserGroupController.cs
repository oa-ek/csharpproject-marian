using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class UserGroupController : Controller
    {
        private readonly IRepository<UserGroup, Guid> _UserGroupRepository;

        public UserGroupController(

            IRepository<UserGroup, Guid> userGroupRepository
            )
        {
            _UserGroupRepository = userGroupRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var userGroup = await _UserGroupRepository.GetAllAsync();
            return View(userGroup);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                await _UserGroupRepository.CreateAsync(userGroup);
                return RedirectToAction(nameof(Index));
            }
            return View(userGroup);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var userGroup = await _UserGroupRepository.GetAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserGroup userGroup)
        {
            if (id != userGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _UserGroupRepository.UpdateAsync(userGroup);
                }
                catch (Exception)
                {
                    if (!AdvertisementExists(userGroup.Id))
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
            return View(userGroup);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var userGroup = await _UserGroupRepository.GetAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _UserGroupRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(Guid id)
        {
            return true;
        }
    }
}
