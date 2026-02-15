using Microsoft.EntityFrameworkCore;
using RoomBooking.Api.Models;

namespace RoomBooking.Api.Data
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<RoomBookingEntity> RoomBookings { get; set; }


    }

}
