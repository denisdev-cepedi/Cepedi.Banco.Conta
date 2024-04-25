using Cepedi.Banco.Conta.Api.Controllers;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
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
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarChavePixResponse>> CriarChavePixAsync(
        [FromBody] CriarChavePixRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarChavePixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ContaMensagemErrors), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarChavePixResponse>> AtualizarChavePixAsync(
        [FromBody] AtualizarChavePixRequest request) => await SendCommand(request);

}
