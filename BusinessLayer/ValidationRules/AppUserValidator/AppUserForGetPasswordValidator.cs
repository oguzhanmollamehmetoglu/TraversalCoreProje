using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppUserValidator
{
    public class AppUserForGetPasswordValidator : AbstractValidator<AppUserForGetPasswordDTO>
    {
        public AppUserForGetPasswordValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("Lütfen email adresinizi giriniz");
        }
    }
}