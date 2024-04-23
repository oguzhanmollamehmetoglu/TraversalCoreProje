using Microsoft.AspNetCore.Http;

namespace DTOLayer.DTOs.AboutDTOs
{
    public class AboutViewDTO
    {
        public int AboutID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image1 { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Title2 { get; set; }

        public string Description2 { get; set; }

        public bool Status { get; set; }
    }
}