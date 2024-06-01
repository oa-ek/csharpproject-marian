using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TeamManager.Controllers
{
    [Authorize]
    public class UserGroupController : Controller
    {
        private readonly IRepository<UserGroup, Guid> _userGroupRepository;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _environment;

        public UserGroupController(
            IRepository<UserGroup, Guid> userGroupRepository,
            UserManager<User> userManager,
            IWebHostEnvironment environment)
        {
            _userGroupRepository = userGroupRepository;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: UserGroups
        public async Task<IActionResult> Index()
        {
            var userGroups = await _userGroupRepository.GetAllAsync();
            return View(userGroups);
        }

        // GET: UserGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserGroup userGroup, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // Get the current logged-in user
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    userGroup.Users.Add(currentUser);
                }

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

                await _userGroupRepository.CreateAsync(userGroup);
                return RedirectToAction(nameof(Index));
            }
            return View(userGroup);
        }

        // GET: UserGroups/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var userGroup = await _userGroupRepository.GetAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }

        // POST: UserGroups/Edit/5
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

                    await _userGroupRepository.UpdateAsync(userGroup);
                }
                catch (Exception)
                {
                    if (!UserGroupExists(userGroup.Id))
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

        // GET: UserGroups/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var userGroup = await _userGroupRepository.GetAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }

        // POST: UserGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _userGroupRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserGroupExists(Guid id)
        {
            return _userGroupRepository.GetAsync(id) != null;
        }
    }
}
