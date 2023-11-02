using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using BookingHotelRooms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _roomService.GetAllRoomsAsync();
            return View(model);
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomViewModel room)
        {
            if (await _roomService.CheckForRoomNumberDuplicatesAsync(room.RoomNumber) )
            {
                ModelState.AddModelError("RoomNumber", "This room number is already registered!");
            }
            if (ModelState.IsValid)
            {
                await _roomService.AddRoomAsync(room);

                return RedirectToAction("Index", "Rooms");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditRoom(int id)
        {
            var model = await _roomService.EditRoomAsync(id);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditRoom(EditRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _roomService.EditRoomAsync(model);
                return RedirectToAction("Index", "Rooms");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.RemoveRoomAsync(id);
            return RedirectToAction("Index", "Rooms");
        }


    }
}
