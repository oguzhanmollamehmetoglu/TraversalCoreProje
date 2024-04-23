using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace DTOLayer.DTOs.FeatureDTOs
{
    public class FeatureViewDTO
    {
        public int FeatureID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }

        public bool Status { get; set; }

        public List<Feature2> Feature2 { get; set; }
    }
}