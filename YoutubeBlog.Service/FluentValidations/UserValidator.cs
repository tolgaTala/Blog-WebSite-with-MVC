﻿using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İsim")
                ;
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Soy İsim")
                ;
            RuleFor(x => x.Email)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(80)
                .WithName("Email")
                ;
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(11)
                .WithName("Telefon Numarası")
                ;
            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .WithName("Şifre")
                ;
        }
    }
}
