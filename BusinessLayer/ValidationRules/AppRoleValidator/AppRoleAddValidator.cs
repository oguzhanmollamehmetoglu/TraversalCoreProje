using DTOLayer.DTOs.AppRoleDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppRoleValidator
{
    public class AppRoleAddValidator : AbstractValidator<AppRoleAddDTO>
    {
        public AppRoleAddValidator()
        {
            RuleFor(x => x.Rolename).NotEmpty().WithMessage("Rol kısmını boş geçemezsiniz...!");
        }
    }
}