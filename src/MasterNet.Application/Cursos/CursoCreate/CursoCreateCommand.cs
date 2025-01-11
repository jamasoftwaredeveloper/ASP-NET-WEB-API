// Command
// CommandHandler

using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Cursos.CursoCreate;

public class CursoCreateCommand
{
    public record CursoCreateCommandRequest(CursoCreateRequest cursoCreateRequest)
    : IRequest<Result<Guid>>, ICommandBase;


    internal class CursoCreateCommandHandler
    : IRequestHandler<CursoCreateCommandRequest, Result<Guid>>
    {
        private readonly MasterNetDbContext _context;
        private readonly IPhotoService _phonoService;

        public CursoCreateCommandHandler(
            IPhotoService phonoService,
            MasterNetDbContext context)
        {
            _context = context;
            _phonoService = phonoService;
        }

        public async Task<Result<Guid>> Handle(
            CursoCreateCommandRequest request,
            CancellationToken cancellationToken
        )
        {
            var cursoId = Guid.NewGuid();
            var curso = new Curso
            {
                Id = Guid.NewGuid(),
                Titulo = request.cursoCreateRequest.Titulo,
                Descripcion = request.cursoCreateRequest.Descripcion,
                FechaPublicacion = request.cursoCreateRequest.FechaPublicacion
            };

            if (request.cursoCreateRequest.Foto is not null)
            {
                var photoUploadResult = _phonoService.AddPhoto(request.cursoCreateRequest.Foto);

                var photo = new Photo
                {
                    Id = Guid.NewGuid(),
                    Url = photoUploadResult.Result.Url,
                    PublicId = photoUploadResult.Result.PublicId,
                    CursoId = cursoId,
                };
                curso.Photos = new List<Photo> { photo };

            }

            if (request.cursoCreateRequest.InstructorId is not null)
            {
                var instructor = _context.Instructores!
                    .FirstOrDefault(x => x.Id == request.cursoCreateRequest.InstructorId);

                if (instructor is null)
                {
                    return Result<Guid>.Failure("No se encontro el instructor.");
                }

                curso.Instructores = new List<Instructor> { instructor };
            }

            if (request.cursoCreateRequest.PrecioId is not null)
            {
                var precio = _context.Precios!
                    .FirstOrDefault(x => x.Id == request.cursoCreateRequest.PrecioId);

                if (precio is null)
                {
                    return Result<Guid>.Failure("No se encontro el precio.");
                }

                curso.Precios = new List<Precio> { precio };
            }

            _context.Add(curso);

            var resultado = await _context.SaveChangesAsync(cancellationToken) > 0;

            return resultado ?
                Result<Guid>.Success(curso.Id) :
                Result<Guid>.Failure("No se pudo ingresar");
        }
    }

    public class CursoCreateRequestValidator : AbstractValidator<CursoCreateCommandRequest>
    {
        public CursoCreateRequestValidator()
        {
            RuleFor(x => x.cursoCreateRequest).SetValidator(new CursoCreateValidator());
        }
    }
}
