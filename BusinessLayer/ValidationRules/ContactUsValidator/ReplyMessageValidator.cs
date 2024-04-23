using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ContactUsValidator
{
    public class ReplyMessageValidator : AbstractValidator<ReplyMessageDTO>
    {
        public ReplyMessageValidator()
        {
            RuleFor(x => x.Reply).NotEmpty().WithMessage("Mesaj kısmını boş geçemezsiniz");
        }
    }
}