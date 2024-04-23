using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules.SocialContactValidator
{
    public class SocialContactValidator : AbstractValidator<SocialContact>
    {
        public SocialContactValidator()
        {
            RuleFor(x => x.Url).NotEmpty().WithMessage("Lütfen bir Url ekleyiniz");
        }
    }
}