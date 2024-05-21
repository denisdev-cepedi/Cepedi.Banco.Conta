using Cepedi.Banco.Conta.Dominio;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using Cepedi.Banco.Conta.Compartilhado.Excecoes;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cepedi.Banco.Conta.Compartilhado;

namespace Cepedi.Banco.Conta.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransacaoController : BaseController
{
    private readonly ILogger<TransacaoController> _logger;
    private readonly IMediator _mediator;

    public TransacaoController(
        ILogger<TransacaoController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    [HttpPost]
    [ProducesResponseType(typeof(CriarTransacaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarTransacaoResponse>> CriarTransacaoAsync(
        [FromBody] CriarTransacaoRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(BuscarTransacaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BuscarTransacaoResponse>> BuscarTransacaoAsync(
        [FromQuery] BuscarTransacaoRequest request) => await SendCommand(request);

    [HttpGet("periodo")]
    [ProducesResponseType(typeof(BuscarExtratoPorPeriodoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BuscarExtratoPorPeriodoResponse>> BuscarExtratoPorPeriodoAsync(
        [FromQuery] BuscarExtratoPorPeriodoRequest request) => await SendCommand(request);

    [HttpGet("mes")]
    [ProducesResponseType(typeof(BuscarExtratoPorMesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BuscarExtratoPorMesResponse>> BuscarExtratoPorMesAsync(
        [FromQuery] BuscarExtratoPorMesRequest request) => await SendCommand(request);    

    [HttpGet("conta")]
    [ProducesResponseType(typeof(BuscarTransacaoPorContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BuscarTransacaoPorContaResponse>> ObterTransacoesPorContaAsync(
        [FromQuery] BuscarTransacaoPorContaRequest request) => await SendCommand(request);

    [HttpGet("recentes")]
    [ProducesResponseType(typeof(BuscarTransacoesRecentesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BuscarTransacoesRecentesResponse>> BuscarTransacoesRecentesAsync(
        [FromQuery] BuscarTransacoesRecentesRequest request) => await SendCommand(request);


/*     [HttpPut]
    [ProducesResponseType(typeof(AtualizarTransacaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarTransacaoResponse>> AtualizarTransacaoAsync(
        [FromBody] AtualizarTransacaoRequest request) => await SendCommand(request); */

}
