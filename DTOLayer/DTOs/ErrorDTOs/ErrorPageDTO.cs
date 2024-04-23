namespace DTOLayer.DTOs.ErrorDTOs
{
    public class ErrorPageDTO
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}