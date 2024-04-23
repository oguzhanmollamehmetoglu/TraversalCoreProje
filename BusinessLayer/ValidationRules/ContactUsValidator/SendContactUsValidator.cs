using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ContactUsValidator
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail kısmını boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj kısmını boş geçemezsiniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim kısmını boş geçemezsiniz");

            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik konu içeriği giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakterlik konu içeriği giriniz");

            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik mail içeriği giriniz");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakterlik mail içeriği giriniz");

        }
    }
}