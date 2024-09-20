using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class DiscussionValidator : AbstractValidator<Discussion>
    {
        public DiscussionValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("Başlık")
                ;
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
