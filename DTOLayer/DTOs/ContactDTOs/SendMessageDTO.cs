namespace DTOLayer.DTOs.ContactDTOs
{
    public class SendMessageDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }

        public DateTime MessageDate { get; set; }

        public bool ContactUsStatus { get; set; }
    }
}