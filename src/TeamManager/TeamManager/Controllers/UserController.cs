using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Repository.Models;
using TeamManager.Repository.Users;

namespace TeamManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await userRepository.GetAllWithRolesAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserCreateModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userRepository.CreateWithPasswordAsync(model);

                if (user != null)
                {
                    return RedirectToAction(nameof(Edit), new { id = user.Id });
                }
            }

            return View(new UserCreateModel());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Roles = await userRepository.GetRolesAsync();
            return View(await userRepository.GetOneWithRolesAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserListItemModel model, string[] roles)
        {
            if (ModelState.IsValid)
            {
                await userRepository.UpdateUserAsync(model, roles);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await userRepository.GetRolesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await userRepository.GetOneWithRolesAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await userRepository.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
