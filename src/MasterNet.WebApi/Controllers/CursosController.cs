using System.Net;
using MasterNet.Application.Core;
using MasterNet.Application.Cursos.CursoCreate;
using MasterNet.Application.Cursos.CursoUpdate;
using MasterNet.Application.Cursos.GetCurso;
using MasterNet.Application.Cursos.GetCursos;
using MasterNet.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Cursos.CursoCreate.CursoCreateCommand;
using static MasterNet.Application.Cursos.CursoDelete.CursoDeleteCommand;
using static MasterNet.Application.Cursos.CursoReporteExcel.CursoReporteExcelQuery;
using static MasterNet.Application.Cursos.CursoUpdate.CursoUpdateCommand;
using static MasterNet.Application.Cursos.GetCurso.GetCursoQuery;
using static MasterNet.Application.Cursos.GetCursos.GetCursosQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/cursos")]
public class CursosController : ControllerBase
{
    private readonly ISender _sender;
    public CursosController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult> PaginationCursos(
        [FromQuery] GetCursosRequest request,
        CancellationToken cancellationToken

    )
    {

        var query = new GetCursosQueryRequest { CursosRequest = request };
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();

    }

    [Authorize(Policy = PolicyMaster.CURSO_CREATE)]
    [HttpPost("create")]
    public async Task<ActionResult<Result<Guid>>> CursoCreate(
        [FromForm] CursoCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CursoCreateCommandRequest(request);
        return await _sender.Send(command, cancellationToken);
    }

    // 1*****RESPONSE CON TIPO DE DATO ESPECIFICO
    // [HttpGet("{id}")]
    // public async Task<CursoResponse> CursoGet(
    //     Guid id,
    //     CancellationToken cancellationToken
    // )
    // {
    //     var query = new GetCursoQueryRequest { Id = id };
    //     var resultado = await _sender.Send(query, cancellationToken);
    //     return resultado.IsSuccess ? resultado.Value! : null!;
    // }


    // 2. **** Response de tipo IActionResult
    // [HttpGet("{id}")]
    // [ProducesResponseType(typeof(CursoResponse), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> CursoGet(
    //     Guid id,
    //     CancellationToken cancellationToken
    // )
    // {
    //     var query = new GetCursoQueryRequest { Id = id };
    //     var resultado = await _sender.Send(query, cancellationToken);
    //     return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
    // }

    // [HttpGet("{id}")]
    // public async Task<ActionResult> GetCurso(
    // Guid id,
    // CancellationToken cancellationToken)
    // {
    //   var query = new GetCursoQueryRequest { Id = id };
    //   var resultado = await _sender.Send(query, cancellationToken);
    //   return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
    // }
    // Task ->> por uso se aysnc
    //*** 3. Response con ActionResult<T>

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<CursoResponse>> CursoGet(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetCursoQueryRequest { Id = id };
        var resultado = await _sender.Send(query, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
    }

    [Authorize(Policy = PolicyMaster.CURSO_UPDATE)]
    [HttpPut("update/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Result<Guid>>> CursoUpdate(
      [FromBody] CursoUpdateRequest request,
      Guid id,
      CancellationToken cancellationToken)
    {
        var command = new CursoUpdateCommandRequest(request, id);

        var resultado = await _sender.Send(command, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();

    }

    [Authorize(Policy = PolicyMaster.CURSO_DELETE)]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Result<Unit>>> CursoDelete(
      Guid id,
      CancellationToken cancellationToken)
    {
        var command = new CursoDeleteCommandRequest(id);

        var resultado = await _sender.Send(command, cancellationToken);

        return resultado.IsSuccess ? Ok() : BadRequest();

    }

    [AllowAnonymous]
    [HttpGet("report")]
    public async Task<IActionResult> ReportCSV(CancellationToken cancellationToken)
    {
        var query = new CursoReporteExcelQueryRequest();
        var resultado = await _sender.Send(query, cancellationToken);

        byte[] excelBytes = resultado.ToArray();
        return File(excelBytes, "text/csv", "cursos.csv");
    }


}