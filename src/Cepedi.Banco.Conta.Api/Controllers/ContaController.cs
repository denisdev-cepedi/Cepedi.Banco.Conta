using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Cepedi.Banco.Conta.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaController : BaseController
{
    private readonly ILogger<ContaController> _logger;
    private readonly IMediator _mediator;

    public ContaController(
        ILogger<ContaController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarContaResponse>> CriarContaAsync(
        [FromBody] CriarContaRequest request) => await SendCommand(request);


    [HttpGet]
    [ProducesResponseType(typeof(BuscarContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)] //Talvez adicionar um responsetype para 404 seja válido
    public async Task<ActionResult<BuscarContaResponse>> ObterContaAsync(
        [FromQuery] BuscarContaRequest request) => await SendCommand(request);
    
    [HttpGet("saldo")]
    [ProducesResponseType(typeof(BuscarSaldoContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)] //Talvez adicionar um responsetype para 404 seja válido
    public async Task<ActionResult<BuscarSaldoContaResponse>> ObterSaldoConta(
        [FromQuery] BuscarSaldoContaRequest request) => await SendCommand(request);

    [HttpPut]
    [Authorize]
    [ProducesResponseType(typeof(AtualizarContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarContaResponse>> AtualizarContaAsync(
        [FromBody] AtualizarContaRequest request) => await SendCommand(request);

    [HttpPut("deposito")]
    [ProducesResponseType(typeof(FazerDepositoContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<FazerDepositoContaResponse>> AtualizarContaAsync(
        [FromBody] FazerDepositoContaRequest request) => await SendCommand(request);

    [HttpPut("saque")]
    [ProducesResponseType(typeof(FazerSaqueContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<FazerSaqueContaResponse>> AtualizarContaAsync(
        [FromBody] FazerSaqueContaRequest request) => await SendCommand(request);
}
