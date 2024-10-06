using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        private readonly DataHotelContext _context;
        public RoomController(DataHotelContext context)
        {
            _context = context;
        }

        //============================================================================================
        [HttpGet]

        public IActionResult ChooseRoom()
        {
            return View(new Rooms());
        }

        public IActionResult ChooseRoom(Rooms room)
        {
            if (room != null)
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return RedirectToAction("RoomDetails");
            }
            return View(room);
        }
        public IActionResult RoomDetails()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }
        //============================================================================================

        // ================= Edit =================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }


        [HttpPost]
        public IActionResult Edit(Rooms room)
        {
            if (ModelState.IsValid)
            {
                _context.Update(room);
                _context.SaveChanges();
                return RedirectToAction("RoomDetails", new { id = room.Roomid });
            }
            return View(room);
        }


        // =================Delete=================
        public IActionResult Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return RedirectToAction("RoomDetails");
        }
    }
}
