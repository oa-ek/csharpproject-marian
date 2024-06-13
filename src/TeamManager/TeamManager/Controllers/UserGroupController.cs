﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace TeamManager.Controllers
{
    public class UserGroupController : Controller
    {
        private readonly IRepository<UserGroup, Guid> _userGroupRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<User> _userManager;

        public UserGroupController(
            IRepository<UserGroup, Guid> userGroupRepository,
            IWebHostEnvironment environment,
            UserManager<User> userManager)
        {
            _userGroupRepository = userGroupRepository;
            _environment = environment;
            _userManager = userManager;
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // GET: UserGroups
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            var currentUserId = GetCurrentUserId();
            var isAdmin = User.IsInRole("Admin");

            IEnumerable<UserGroup> userGroups;

            if (isAdmin)
            {
                userGroups = (await _userGroupRepository.GetAllAsync()).ToList();
            }
            else
            {
                userGroups = (await _userGroupRepository.GetAllAsync()).ToList();
                userGroups = userGroups.Where(ug => ug.Users.Any(u => u.Id == Guid.Parse(currentUserId)));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                userGroups = userGroups.Where(gf => gf.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.SearchTerm = searchTerm;

            ViewBag.CurrentUserId = currentUserId;
            ViewBag.IsAdmin = isAdmin;

            return View(userGroups);
        }


        // GET: UserGroups/Create
        public IActionResult Create()
        {
            return View(new UserGroup());
        }

        // POST: UserGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserGroup userGroup, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // Отримуємо поточного користувача
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return NotFound("Current user not found.");
                }

                // Додаємо поточного користувача до групи (якщо його ще немає в списку)
                if (!userGroup.Users.Any(u => u.Id == currentUser.Id))
                {
                    userGroup.Users.Add(currentUser);
                }

                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    userGroup.MainImage = "img/" + uniqueFileName;
                }

                userGroup.Id = Guid.NewGuid();
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

            ViewBag.CurrentUserId = GetCurrentUserId();

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
                var userGroupToUpdate = await _userGroupRepository.GetAsync(id);
                if (userGroupToUpdate == null)
                {
                    return NotFound();
                }

                userGroupToUpdate.Name = userGroup.Name;
                userGroupToUpdate.Description = userGroup.Description;

                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsDir = Path.Combine(_environment.WebRootPath, "img");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    userGroupToUpdate.MainImage = "img/" + uniqueFileName;
                }

                await _userGroupRepository.UpdateAsync(userGroupToUpdate);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CurrentUserId = GetCurrentUserId();

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

            ViewBag.CurrentUserId = GetCurrentUserId();

            return View(userGroup);
        }

        // POST: UserGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userGroup = await _userGroupRepository.GetAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }

            await _userGroupRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveGroup(Guid id)
        {
            var userGroup = await _userGroupRepository.GetAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }

            var currentUserId = Guid.Parse(GetCurrentUserId());
            var currentUser = userGroup.Users.FirstOrDefault(u => u.Id == currentUserId);
            if (currentUser == null)
            {
                return Forbid();
            }

            userGroup.Users.Remove(currentUser);
            await _userGroupRepository.UpdateAsync(userGroup);

            return RedirectToAction(nameof(Index));
        }
    }
}
