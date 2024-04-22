using Cepedi.Banco.Conta.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.Banco.ChavePix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ChavePixController : BaseController
{
    private readonly ILogger<ChavePixController> _logger;
    private readonly IMediator _mediator;

    public ChavePixController(
        ILogger<ChavePixController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    [HttpPost]
    [ProducesResponseType(typeof(CriarChavePixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarChavePixResponse>> CriarChavePixAsync(
        [FromBody] CriarChavePixRequest request) => await SendCommand(request);

    // [HttpPut]
    // [ProducesResponseType(typeof(AtualizarChavePixResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status204NoContent)]
    // public async Task<ActionResult<AtualizarChavePixResponse>> AtualizarChavePixAsync(
    //     [FromBody] AtualizarChavePixRequest request) => await SendCommand(request);

}
