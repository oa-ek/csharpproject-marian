using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class UserGroupController : Controller
    {
        private readonly IRepository<UserGroup, Guid> _UserGroupRepository;
        private readonly IWebHostEnvironment _environment;


        public UserGroupController(

            IRepository<UserGroup, Guid> userGroupRepository,
            IWebHostEnvironment environment
            )
        {
            _UserGroupRepository = userGroupRepository;
            _environment = environment;
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
       public async Task<IActionResult> Create(UserGroup userGroup, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Save uploaded image to wwwroot/img directory
                    var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    userGroup.MainImage = "img/" + uniqueFileName;
                }

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
        public async Task<IActionResult> Edit(Guid id, UserGroup userGroup, IFormFile imageFile)
        {
            if (id != userGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        // Save the new image file
                        var uploadsDir = Path.Combine(_environment.WebRootPath, "uploads");
                        if (!Directory.Exists(uploadsDir))
                        {
                            Directory.CreateDirectory(uploadsDir);
                        }
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                        var filePath = Path.Combine(uploadsDir, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                        userGroup.MainImage = "/uploads/" + uniqueFileName;
                    }

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
