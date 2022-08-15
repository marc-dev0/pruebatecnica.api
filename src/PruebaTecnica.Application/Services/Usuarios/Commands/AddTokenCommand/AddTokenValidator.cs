using FluentValidation;

namespace PruebaTecnica.Application.Services.Usuarios.Commands.AddTokenCommand
{
    public class AddTokenValidator : AbstractValidator<AddTokenCommand>
    {
        public AddTokenValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
