using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AnnouncementValidator
{
    public class AnnouncementListValidator : AbstractValidator<AnnouncementListDTO>
    {
        public AnnouncementListValidator()
        {
            RuleFor(x => x.AnnouncementID).NotEmpty().WithMessage("Listelenecek bir değer bulunamadı");
        }
    }
}