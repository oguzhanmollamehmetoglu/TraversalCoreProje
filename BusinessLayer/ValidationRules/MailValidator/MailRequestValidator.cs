using DTOLayer.DTOs.MailDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.MailValidator
{
    public class MailRequestValidator : AbstractValidator<MailRequestDTO>
    {
        public MailRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim kısmını boş geçemezsiniz...!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmını boş geçemezsiniz...!");
            RuleFor(x => x.Body).NotEmpty().WithMessage("İçerik kısmını boş geçemezsiniz...!");
        }
    }
}