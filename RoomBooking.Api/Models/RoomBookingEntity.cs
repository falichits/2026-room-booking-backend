namespace RoomBooking.Api.Models
{

    public class RoomBookingEntity
    {

        public int Id { get; set; }

        public int RoomId { get; set; }

        public string Peminjam { get; set; } = "";

        public string Keperluan { get; set; } = "";

        public DateTime TanggalMulai { get; set; }

        public DateTime TanggalSelesai { get; set; }

        public string Status { get; set; } = "Pending";

    }

}
