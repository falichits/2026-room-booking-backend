using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Api.Data;
using RoomBooking.Api.Models;

namespace RoomBooking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomBookingsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public RoomBookingsController(AppDbContext context)
        {
            _context = context;
        }


        // GET ALL
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {

            var data = await _context.RoomBookings.ToListAsync();

            return Ok(data);

        }


        // GET BY ID
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var booking = await _context.RoomBookings.FindAsync(id);

            if (booking == null)
                return NotFound();

            return Ok(booking);

        }


        // CREATE
        [HttpPost]

        public async Task<IActionResult> Create(RoomBookingEntity booking)
        {

            booking.Status = "Pending";

            _context.RoomBookings.Add(booking);

            await _context.SaveChangesAsync();

            return Ok(booking);

        }


        // UPDATE STATUS
        [HttpPut("{id}/status")]

        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {

            var booking = await _context.RoomBookings.FindAsync(id);

            if (booking == null)
                return NotFound();

            booking.Status = status;

            await _context.SaveChangesAsync();

            return Ok(booking);

        }


        // DELETE
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {

            var booking = await _context.RoomBookings.FindAsync(id);

            if (booking == null)
                return NotFound();

            _context.RoomBookings.Remove(booking);

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
