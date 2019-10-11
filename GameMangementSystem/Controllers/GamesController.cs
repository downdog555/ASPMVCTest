using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameMangementSystem.Context;
using GameMangementSystem.Models;
using Microsoft.AspNetCore.Authorization;
namespace GameMangementSystem.Controllers
{ 
    [Authorize]
    public class GamesController : Controller
    {
        //access to database
        private readonly GameContext _context;
        /// <summary>
        /// construcor
        /// </summary>
        /// <param name="context">db context</param>
        public GamesController(GameContext context)
        {
            //sets the context
            _context = context;
        }

        /// <summary>
        /// index function
        /// </summary>
        /// <returns>index view</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Game.ToListAsync());
        }

        /// <summary>
        /// details method 
        /// </summary>
        /// <param name="id">optional id from get request</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            //if no id 404
            if (id == null)
            {
                return NotFound();
            }

            //start async task to find the id
            var game = await _context.Game.FirstOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }
            //load the view with apropriate details
            return View(game);
        }

       //basic create function loads view 
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post verstion of creates 
        /// actuall creates game entry
        /// </summary>
        /// <param name="game">used to bind post form sinto  a tempoary game class</param>
        /// <returns>either redirect if correct or the page with the details submitted before</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        /// <summary>
        /// edit function loads edit view
        /// </summary>
        /// <param name="id">optional id</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            //404
            if (id == null)
            {
                return NotFound();
            }
            //find entry
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            //load view with data
            return View(game);
        }

        /// <summary>
        /// post version of edit
        /// performs the update
        /// </summary>
        /// <param name="id">id of entry</param>
        /// <param name="game">form values boudn to a game class/model</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Game game)
        {
            if (id != game.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try to update 
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if not then the database has been altered 
                    if (!GameExists(game.ID))
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
            return View(game);
        }

        /// <summary>
        /// Delte function
        /// get request
        /// loads basic view
        /// </summary>
        /// <param name="id">id of entry to delete</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            //404
            if (id == null)
            {
                return NotFound();
            }
            //use db context to search fro game
            var game = await _context.Game.FirstOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        /// <summary>
        /// post request fr delete
        /// </summary>
        /// <param name="id">id fo entry to delte</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            //find entry
            var game = await _context.Game.FindAsync(id);
            //remove from in mmeory
            _context.Game.Remove(game);
            //update store
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.ID == id);
        }
    }
}
