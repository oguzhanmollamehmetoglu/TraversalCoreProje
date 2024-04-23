using DTOLayer.DTOs.AppRoleDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppRoleValidator
{
    public class AppRoleAssignValidator : AbstractValidator<RoleAssignViewDTO>
    {
        public AppRoleAssignValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol kısmını boş geçemezsiniz...!");
        }
    }
}