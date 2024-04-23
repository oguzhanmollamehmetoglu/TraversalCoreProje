using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace DTOLayer.DTOs.GuideDTOs
{
    public class GuideViewDTO
    {
        public int GuideID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? Description2 { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }

        public string? GuideListImage { get; set; }

        public IFormFile ImageFile2 { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public bool Status { get; set; }

        public List<Destination> Destiantion { get; set; }

        public int? AppUserID { get; set; }

        public AppUser AppUser { get; set; }

        public List<Guide> guides { get; set; }

        public List<AppUser> appUsers { get; set; }
    }
}