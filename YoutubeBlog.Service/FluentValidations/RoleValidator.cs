using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class RoleValidator : AbstractValidator<AppRole>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Rol")
                ;            
        }
    }
}
