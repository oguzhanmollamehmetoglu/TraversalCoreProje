namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }

        public string PersonCount { get; set; }

        public DateTime ReservationDate { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public int DestiantionID { get; set; }

        public Destination Destiantion { get; set; }
    }
}