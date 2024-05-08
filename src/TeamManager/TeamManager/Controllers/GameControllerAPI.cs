using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;
using TeamManager.Repository.RawgApiService;

namespace TeamManager.Controllers
{
    public class GameControllerAPI : Controller
    {
        private readonly IRawgApiService _rawgApiService;
        private readonly IWebHostEnvironment _environment;

        public GameControllerAPI(IRawgApiService rawgApiService, IWebHostEnvironment environment)
        {
            _rawgApiService = rawgApiService;
            _environment = environment;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var games = await _rawgApiService.GetGamesAsync();
            return View(games);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View(new Game());
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // Your code for handling image upload

                // Call RawgApiService to create the game
                await _rawgApiService.CreateGameAsync(game);

                return RedirectToAction(nameof(Index));
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var game = await _rawgApiService.GetGameByIdAsync(id.ToString());
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }


        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Game game, IFormFile imageFile)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Your code for handling image upload

                // Call RawgApiService to update the game
                await _rawgApiService.UpdateGameAsync(id.ToString(), game);

                return RedirectToAction(nameof(Index));
            }

            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var game = await _rawgApiService.GetGameByIdAsync(id.ToString());
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Call RawgApiService to delete the game
            await _rawgApiService.DeleteGameAsync(id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
