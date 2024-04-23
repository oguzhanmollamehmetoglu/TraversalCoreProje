using DTOLayer.DTOs.AboutDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AboutValidator
{
    public class AboutViewValidator : AbstractValidator<AboutViewDTO>
    {
        public AboutViewValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz...!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen görsel seçiniz...!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama bilgisi giriniz...!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("En fazla 1590 karakterlik açıklama bilgisi girebilirsiniz...!");
        }
    }
}