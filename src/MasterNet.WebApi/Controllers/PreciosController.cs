using System.Net;
using MasterNet.Application.Core;
using MasterNet.Application.Precios.GetPrecios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Cursos.GetCursos.GetCursosQuery;
using static MasterNet.Application.Precios.GetPrecios.GetPreciosQuery;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/precios")]
    public class PreciosController : ControllerBase
    {
        private readonly ISender _sender;
        public PreciosController(ISender sender)
        {
            _sender = sender;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedList<PrecioResponse>>> PaginationCursos(
            [FromQuery] GetPreciosRequest request,
            CancellationToken cancellationToken

        )
        {

            var query = new GetPreciosQueryRequest { PreciosRequest = request };
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();

        }
    }
}
