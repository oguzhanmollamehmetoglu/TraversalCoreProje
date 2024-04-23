using DTOLayer.DTOs.CityDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.CityValidator
{
    public class CityValidator : AbstractValidator<CityAddDTO>
    {
        public CityValidator()
        {
            RuleFor(x => x.CityName).NotEmpty().WithMessage("Şehir kısmını boş geçemezsiniz...!");
            RuleFor(x => x.CityCountry).NotEmpty().WithMessage("Ülke kısmını boş geçemezsiniz...!");
        }
    }
}