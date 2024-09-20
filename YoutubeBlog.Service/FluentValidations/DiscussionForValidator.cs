using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class DiscussionForValidator : AbstractValidator<DiscussionFor>
    {
        public DiscussionForValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(2150)
                .WithName("İçerik")
                ;

        }
    }
}
