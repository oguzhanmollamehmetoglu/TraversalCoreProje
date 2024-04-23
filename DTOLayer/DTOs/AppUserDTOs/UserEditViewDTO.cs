using Microsoft.AspNetCore.Http;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class UserEditViewDTO
    {
        public string name { get; set; }

        public string surname { get; set; }

        public string password { get; set; }

        public string confirmpassword { get; set; }

        public string phonenumber { get; set; }

        public string mail { get; set; }

        public string imgurl { get; set; }

        public IFormFile ımage { get; set; }
    }
}