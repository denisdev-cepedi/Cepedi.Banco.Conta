using Cepedi.Banco.Conta.Api.Controllers;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.Banco.ChavePix.Api.Controllers;

[ApiController]
[Route("v1/chavespix")]
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
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarChavePixResponse>> CriarChavePixAsync(
        [FromBody] CriarChavePixRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarChavePixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarChavePixResponse>> AtualizarChavePixAsync(
        [FromBody] AtualizarChavePixRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(BuscarChavePixPorContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)] //Talvez adicionar um responsetype para 404 seja válido
    public async Task<ActionResult<BuscarChavePixPorContaResponse>> ObterChavePixPorContaAsync(
        [FromQuery] BuscarChavePixPorContaRequest request) => await SendCommand(request);

    [HttpDelete]
    [ProducesResponseType(typeof(RemoverChavePixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RemoverChavePixResponse>> RemoverChavePixAsync(
        [FromBody] RemoverChavePixRequest request) => await SendCommand(request);

}
