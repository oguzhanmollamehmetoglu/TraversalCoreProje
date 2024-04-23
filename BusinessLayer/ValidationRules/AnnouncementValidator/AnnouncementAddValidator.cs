using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AnnouncementValidator
{
    public class AnnouncementAddValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementAddValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık kısmını boş geçemezsiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyin");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik başlık bilgisi giriniz");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Lütfen en az 20 karakterlik duyuru içeriği giriniz");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik başlık bilgisi giriniz");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakterlik duyuru içeriği giriniz");
        }
    }
}