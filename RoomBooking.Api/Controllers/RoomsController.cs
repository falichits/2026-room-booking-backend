using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Models;

namespace RoomBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    // DATA SEMENTARA (IN-MEMORY)
    private static readonly List<Room> Rooms = new()
    {
        new Room { Id = 1, Name = "Lab Komputer", Capacity = 30 },
        new Room { Id = 2, Name = "Ruang Rapat", Capacity = 15 }
    };

    // GET: /api/rooms
    [HttpGet]
    public IActionResult GetRooms()
    {
        return Ok(Rooms);
    }

    // POST: /api/rooms
    [HttpPost]
    public IActionResult CreateRoom(Room room)
    {
        room.Id = Rooms.Count + 1;
        Rooms.Add(room);
        return Ok(room);
    }
}
