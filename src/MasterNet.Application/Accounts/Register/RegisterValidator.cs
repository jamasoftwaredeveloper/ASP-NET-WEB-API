
using FluentValidation;

namespace MasterNet.Application.Accounts.Register
{
    public class RegisterValidator :AbstractValidator<RegisterRequest>
    {
        public RegisterValidator() {

            RuleFor(x => x.Email).NotEmpty().WithMessage("El campo email esta vacio");
            RuleFor(x => x.Password).NotEmpty().WithMessage("El campo password esta vacio");
            RuleFor(x => x.NombreCompleto).NotEmpty().WithMessage("El campo nombre completo esta vacio"); ;
            RuleFor(x => x.Carrera).NotEmpty().WithMessage("El campo carrera esta vacio");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("El campo nombre usuario esta vacio");

        }
    }
}
