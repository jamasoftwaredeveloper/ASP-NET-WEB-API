using AutoMapper.QueryableExtensions;
using AutoMapper;
using MasterNet.Application.Core.Pagination;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Calificaciones.GetCalificaciones;


public class GetPreciosQuery
{
    public record GetCalificacionesQueryRequest :
        IRequest<Result<PagedList<CalificacionResponse>>>
    {

        public GetCalificacionesRequest? CalificacionesRequest { get; set; }

        internal class GetCalificacionesQueryHandler :
            IRequestHandler<GetCalificacionesQueryRequest, Result<PagedList<CalificacionResponse>>>
        {
            private readonly MasterNetDbContext _context;
            private readonly IMapper _mapper;

            public GetCalificacionesQueryHandler(MasterNetDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<CalificacionResponse>>> Handle(
                GetCalificacionesQueryRequest request,
                CancellationToken cancellationToken)
            {
                IQueryable<Calificacion> queryable = _context.Calificaciones!.
                    Include(x => x.Curso);

                var predicate = ExpressionBuilder.New<Calificacion>();

                if (!string.IsNullOrEmpty(request.CalificacionesRequest!.Alumno))
                {
                    predicate = predicate.
                        And(y => y.Alumno!.Contains(request.CalificacionesRequest!.Alumno));
                }

                if (request.CalificacionesRequest!.Puntaje.HasValue)
                {
                    int precioActual = request.CalificacionesRequest.Puntaje.Value;
                    predicate = predicate.And(y => y.Puntaje >= precioActual); // o cualquier otra comparación
                }

                if (!string.IsNullOrEmpty(request.CalificacionesRequest.OrderBy))
                {
                    Expression<Func<Calificacion, object>>? orderBySelector =
                        request.CalificacionesRequest.OrderBy.ToLower() switch
                        {
                            "alumno" => calificacion => calificacion.Alumno!,
                            "puntaje" => calificacion => calificacion.Puntaje!,
                            _ => calificacion => calificacion.Alumno!
                        };

                    bool orderBy = request.CalificacionesRequest.OrderAsc.HasValue
                        ? request.CalificacionesRequest.OrderAsc.Value : true;

                    queryable = orderBy ? queryable.OrderBy(orderBySelector)
                        : queryable.OrderByDescending(orderBySelector);
                }

                queryable = queryable.Where(predicate);
                var calificacionQuery = queryable.ProjectTo<CalificacionResponse>
                    (_mapper.ConfigurationProvider).
                    AsQueryable();
                var pagination = await PagedList<CalificacionResponse>
                    .CreateAsync(
                    calificacionQuery,
                    request.CalificacionesRequest.PageNumber,
                    request.CalificacionesRequest.PageSize
                    );

                return Result<PagedList<CalificacionResponse>>.Success(pagination);
            }
        }

    }
}


public record CalificacionResponse(
    string? Alumno,
    int? Puntaje,
    string? Comentario,
    string? NombreCurso
)
{
    public CalificacionResponse() : this(null, null, null, null) { }
};

