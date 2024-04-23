using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace DTOLayer.DTOs.DestinationsDTOs
{
    public class DestinationViewDTO
    {
        public int DestiantionID { get; set; }

        public string City { get; set; }

        public string DayNight { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public bool Status { get; set; }

        public string CoverImage { get; set; }

        public IFormFile CoverImageFile { get; set; }

        public string Details1 { get; set; }

        public string Details2 { get; set; }

        public string Image2 { get; set; }

        public IFormFile Image2File { get; set; }

        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Guide> guides { get; set; }

        public int? GuideID { get; set; }

        public Guide Guide { get; set; }
    }
}