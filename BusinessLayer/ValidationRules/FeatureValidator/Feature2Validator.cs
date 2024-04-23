using DTOLayer.DTOs.FeatureDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.GuideValidator
{
    public class Feature2Validator : AbstractValidator<Feature2ViewDTO>
    {
        public Feature2Validator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlık giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen açıklama giriniz");
            RuleFor(x => x.ImageFile2).NotEmpty().WithMessage("Lütfen resim seçiniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen resim seçiniz");
        }
    }
}