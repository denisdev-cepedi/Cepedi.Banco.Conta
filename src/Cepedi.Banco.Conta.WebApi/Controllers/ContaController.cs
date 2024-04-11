using Cepedi.Banco.Conta.Domain;
using Cepedi.Banco.Conta.Domain.Repository;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.Banco.Conta.WebApi.Controllers;

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


    // [HttpPost]
    // [ProducesResponseType(typeof(CriarContaResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<CriarContaResponse>> CriarContaAsync(
    //     [FromBody] CriarContaRequest request) => await SendCommand(request);

    // [HttpPut]
    // [ProducesResponseType(typeof(AtualizarContaResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status204NoContent)]
    // public async Task<ActionResult<AtualizarContaResponse>> AtualizarContaAsync(
    //     [FromBody] AtualizarContaRequest request) => await SendCommand(request);

}
