using MasterNet.Application.Calificaciones.GetCalificaciones;
using MasterNet.Application.Core;
using MediatR;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Calificaciones.GetCalificaciones.GetPreciosQuery;
using MasterNet.Application.Instructores.GetInstructores;
using static MasterNet.Application.Instructores.GetInstructores.GetInstructoresQuery;
using Microsoft.AspNetCore.Authorization;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/instructores")]
    public class InstructoresController : ControllerBase
    {
        private readonly ISender _sender;
        public InstructoresController(ISender sender)
        {
            _sender = sender;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedList<InstructorResponse>>> PaginationCursos(
            [FromQuery] GetInstructoresRequest request,
            CancellationToken cancellationToken

        )
        {
            var query = new GetInstructoresQueryRequest { InstructorRequest = request };
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();

        }
    }
}
