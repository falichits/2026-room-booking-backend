using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Models;

namespace RoomBooking.Api.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    // Simpan data di memory (sementara)
    private static readonly List<Booking> bookings = new();
    private static int nextId = 1;

    // GET: api/bookings
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(bookings);
    }

    // GET: api/bookings/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var booking = bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
            return NotFound("Booking tidak ditemukan");

        return Ok(booking);
    }

    // POST: api/bookings
    [HttpPost]
    public IActionResult Create(Booking booking)
    {
        booking.Id = nextId++;
        booking.Status = "Pending";
        bookings.Add(booking);

        return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
    }

    // PUT: api/bookings/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Booking updatedBooking)
    {
        var booking = bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
            return NotFound("Booking tidak ditemukan");

        booking.RoomId = updatedBooking.RoomId;
        booking.BorrowerName = updatedBooking.BorrowerName;
        booking.Date = updatedBooking.Date;

        return Ok(booking);
    }

    // DELETE: api/bookings/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var booking = bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
            return NotFound("Booking tidak ditemukan");

        bookings.Remove(booking);
        return NoContent();
    }
}
