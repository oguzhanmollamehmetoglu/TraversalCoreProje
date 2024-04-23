using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string İmageUrl { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Gender { get; set; }

        public List<Reservation> reservations { get; set; }

        public List<Comment> comments { get; set; }

        public List<Guide> guides { get; set; }
    }
}