using DTOLayer.DTOs.AppRoleDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppRoleValidator
{
    public class AppRoleCreateValidator : AbstractValidator<CreateRoleViewDTO>
    {
        public AppRoleCreateValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol kısmını boş geçemezsiniz...!");
        }
    }
}