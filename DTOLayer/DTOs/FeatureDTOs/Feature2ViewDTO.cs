using Microsoft.AspNetCore.Http;

namespace DTOLayer.DTOs.FeatureDTOs
{
    public class Feature2ViewDTO
    {
        public int Feature2ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile2 { get; set; }

        public bool Status { get; set; }
    }
}