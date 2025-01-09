using MasterNet.Application.Calificaciones.GetCalificaciones;
using MasterNet.Application.Cursos.GetCursos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Calificaciones.GetCalificaciones.GetPreciosQuery;
using static MasterNet.Application.Cursos.GetCursos.GetCursosQuery;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/calificaciones")]
    public class CalificacionesController : Controller
    {
        private readonly ISender _sender;
        public CalificacionesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> PaginationCursos(
            [FromQuery] GetCalificacionesRequest request,
            CancellationToken cancellationToken

        )
        {
            var query = new GetCalificacionesQueryRequest { CalificacionesRequest = request };
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();

        }
    }
}
