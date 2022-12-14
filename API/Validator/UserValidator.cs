using Common;
using FluentValidation;

namespace API.Validator
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username).NotNull().WithMessage("Username vazio");
            RuleFor(user => user.Person.Email).NotNull().WithMessage("E-mail vazio");
            RuleFor(user => user.Person.Email).EmailAddress().WithMessage("o e-mail está inválido");
            RuleFor(user => user.Password).NotNull().WithMessage("senha vazia");
            RuleFor(user => user.Password).Equal(o => o.ConfirmPassword).WithMessage("senhas diferentes");

        }
    }
}

