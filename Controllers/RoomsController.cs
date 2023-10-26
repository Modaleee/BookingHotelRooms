using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using BookingHotelRooms.Repositories;
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
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _roomRepository.GetAllRooms();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoom(int id)
        {
            var model = await _roomRepository.GetRoom(id);
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
            if (await _roomRepository.CheckForRoomNumberDuplicates(room.RoomNumber) )
            {
                ModelState.AddModelError("RoomNumber", "This room number is already registered!");
            }
            if (ModelState.IsValid)
            {
                var model = new Room
                {
                    Description = room.Description,
                    Price = room.Price,
                    RoomNumber = room.RoomNumber
                };
                await _roomRepository.AddRoom(model);

                return RedirectToAction("Index", "Rooms");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> ModifyRoom(int id)
        {
            var room = await _roomRepository.GetRoom(id);
            var model = new ModifyRoomViewModel { RoomId=room.RoomId,
                RoomNumber = room.RoomNumber, 
                Description = room.Description, 
                IsAvailable = room.IsAvailable, 
                Price = room.Price };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ModifyRoom(ModifyRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var room = await _roomRepository.GetRoom(model.RoomId);
                room.RoomId = model.RoomId;
                room.RoomNumber = model.RoomNumber;
                room.Description = model.Description;
                room.IsAvailable = model.IsAvailable;
                room.Price = model.Price;

                await _roomRepository.UpdateRoom(room);
                return RedirectToAction("Index", "Rooms");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomRepository.DeleteRoom(id);
            return RedirectToAction("Index", "Rooms");
        }


    }
}
