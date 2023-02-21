using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comp2084_project.Data;
using comp2084_project.Models;

namespace comp2084_project.Controllers
{
    public class CinemaRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinemaRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CinemaRooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CinemaRoom.Include(c => c.Movies);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CinemaRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CinemaRoom == null)
            {
                return NotFound();
            }

            var cinemaRoom = await _context.CinemaRoom
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaRoom == null)
            {
                return NotFound();
            }

            return View(cinemaRoom);
        }

        // GET: CinemaRooms/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: CinemaRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CinemaRoomId,Name,Seats_no,CinemaRoomNumber,Id")] CinemaRoom cinemaRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinemaRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Movie, "Id", "Title", cinemaRoom.Id);
            return View(cinemaRoom);
        }

        // GET: CinemaRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CinemaRoom == null)
            {
                return NotFound();
            }

            var cinemaRoom = await _context.CinemaRoom.FindAsync(id);
            if (cinemaRoom == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Movie, "Id", "Title", cinemaRoom.Id);
            return View(cinemaRoom);
        }

        // POST: CinemaRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CinemaRoomId,Name,Seats_no,CinemaRoomNumber,Id")] CinemaRoom cinemaRoom)
        {
            if (id != cinemaRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinemaRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaRoomExists(cinemaRoom.Id))
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
            ViewData["Id"] = new SelectList(_context.Movie, "Id", "Title", cinemaRoom.Id);
            return View(cinemaRoom);
        }

        // GET: CinemaRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CinemaRoom == null)
            {
                return NotFound();
            }

            var cinemaRoom = await _context.CinemaRoom
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaRoom == null)
            {
                return NotFound();
            }

            return View(cinemaRoom);
        }

        // POST: CinemaRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CinemaRoom == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CinemaRoom'  is null.");
            }
            var cinemaRoom = await _context.CinemaRoom.FindAsync(id);
            if (cinemaRoom != null)
            {
                _context.CinemaRoom.Remove(cinemaRoom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaRoomExists(int id)
        {
          return _context.CinemaRoom.Any(e => e.Id == id);
        }
    }
}
