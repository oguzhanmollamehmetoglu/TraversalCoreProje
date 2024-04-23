using DTOLayer.DTOs.GuideDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.GuideValidator
{
    public class GuideProfileEditViewValidator : AbstractValidator<GuideProfileEditViewDTO>
    {
        public GuideProfileEditViewValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen rehber adınızı giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen açıklama giriniz");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Lütfen açıklama giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen resim seçiniz");
            RuleFor(x => x.GuideListImage).NotEmpty().WithMessage("Lütfen resim seçiniz");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Lütfen url doldurun ");
            RuleFor(x => x.TwitterUrl).NotEmpty().WithMessage("Lütfen url doldurun ");

            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen 30 karakterden daha kısa bir isim giriniz");
            RuleFor(x => x.Name).MinimumLength(8).WithMessage("Lütfen 8 karakterden daha uzun bir isim giriniz");
        }
    }
}