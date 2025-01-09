namespace MasterNet.Application.Precios.GetPrecios;


using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using global::MasterNet.Application.Core.Pagination;
using global::MasterNet.Application.Core;
using global::MasterNet.Domain;
using global::MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetPreciosQuery
{
    public record GetPreciosQueryRequest :
        IRequest<Result<PagedList<PrecioResponse>>>
    {

        public GetPreciosRequest? PreciosRequest { get; set; }

        internal class GetPreciosQueryHandler :
            IRequestHandler<GetPreciosQueryRequest, Result<PagedList<PrecioResponse>>>
        {
            private readonly MasterNetDbContext _context;
            private readonly IMapper _mapper;

            public GetPreciosQueryHandler(MasterNetDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<PrecioResponse>>> Handle(
                GetPreciosQueryRequest request,
                CancellationToken cancellationToken)
            {
                IQueryable<Precio> queryable = _context.Precios!.
                Include(x => x.Cursos).
                Include(x => x.CursoPrecios);

                var predicate = ExpressionBuilder.New<Precio>();

                if (!string.IsNullOrEmpty(request.PreciosRequest!.Nombre))
                {
                    predicate = predicate.
                        And(y => y.Nombre!.Contains(request.PreciosRequest!.Nombre));
                }

                if (request.PreciosRequest!.PrecioActual.HasValue)
                {
                    decimal precioActual = request.PreciosRequest.PrecioActual.Value;
                    predicate = predicate.And(y => y.PrecioActual >= precioActual); // o cualquier otra comparación
                }

                if (request.PreciosRequest!.PrecioPromocion.HasValue)
                {
                    decimal precioPromocion = request.PreciosRequest.PrecioPromocion.Value;
                    predicate = predicate.And(y => y.PrecioPromocion >= precioPromocion); // o cualquier otra comparación
                }

                if (!string.IsNullOrEmpty(request.PreciosRequest.OrderBy))
                {
                    Expression<Func<Precio, object>>? orderBySelector =
                        request.PreciosRequest.OrderBy.ToLower() switch
                        {
                           "nombre" => precio => precio.Nombre!,
                           "precioActual" => precio => precio.PrecioActual!,
                           "precioPromocion" => precio => precio.PrecioPromocion!,
                            _ => precio => precio.Nombre!
                        };

                    bool orderBy = request.PreciosRequest.OrderAsc.HasValue
                        ? request.PreciosRequest.OrderAsc.Value : true;

                    queryable = orderBy ? queryable.OrderBy(orderBySelector)
                        : queryable.OrderByDescending(orderBySelector);
                }

                queryable = queryable.Where(predicate);
                var preciosQuery = queryable.ProjectTo<PrecioResponse>
                    (_mapper.ConfigurationProvider).
                    AsQueryable();
                var pagination = await PagedList<PrecioResponse>
                    .CreateAsync(
                    preciosQuery,
                    request.PreciosRequest.PageNumber,
                    request.PreciosRequest.PageSize
                    );

                return Result<PagedList<PrecioResponse>>.Success(pagination);
            }
        }

    }
}

public record PrecioResponse(
    Guid? Id,
    string? Nombre,
    decimal? PrecioActual,
    decimal? PrecioPromocion
)
{
    public PrecioResponse() : this(null, null, null, null) { }
};
