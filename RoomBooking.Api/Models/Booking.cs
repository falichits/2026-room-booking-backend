namespace RoomBooking.Api.Models;

public class Booking
{
    public int Id { get; set; }

    // Ruangan yang dipinjam
    public int RoomId { get; set; }

    // Nama peminjam
    public string BorrowerName { get; set; } = string.Empty;

    // Tanggal peminjaman
    public DateTime Date { get; set; }

    // Status: Pending, Approved, Rejected
    public string Status { get; set; } = "Pending";
}
