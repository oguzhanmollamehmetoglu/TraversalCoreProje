using DTOLayer.DTOs.AppRoleDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppRoleValidator
{
    public class AppRoleUpdateValidator : AbstractValidator<UpdateRoleViewDTO>
    {
        public AppRoleUpdateValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol kısmını boş geçemezsiniz...!");
        }
    }
}