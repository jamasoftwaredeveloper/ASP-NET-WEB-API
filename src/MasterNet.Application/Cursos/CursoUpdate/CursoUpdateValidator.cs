using FluentValidation;

namespace MasterNet.Application.Cursos.CursoUpdate
{
    public class CursoUpdateValidator : AbstractValidator<CursoUpdateRequest>
    {
        public CursoUpdateValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty().
                WithMessage("El titulo, no debe ser vacio.");
            RuleFor(x => x.Descripcion).NotEmpty().
                WithMessage("La descripción, no debe ser vacio.");
            RuleFor(x => x.FechaPublicacion).NotEmpty().
                WithMessage("La fecha de publicación no debe ser vacio.");
        }
    }
}
