using CursoASPNET.Models;
using FluentValidation;

namespace CursoASPNET.Validator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email).NotNull().WithMessage("E-mail vazio");
            RuleFor(user => user.Password).NotNull().WithMessage("senha vazia");
            RuleFor(user => user.Email).EmailAddress().WithMessage("o e-mail está inválido");
        }
    }
}
