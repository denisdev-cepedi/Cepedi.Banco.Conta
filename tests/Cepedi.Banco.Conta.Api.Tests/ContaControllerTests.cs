using Cepedi.Banco.Conta.Api.Controllers;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Excecoes;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;

namespace Cepedi.Banco.Conta.Api.Tests;

public class ContaControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<ContaController> _logger = Substitute.For<ILogger<ContaController>>();
    private readonly ContaController _sut;
    public ContaControllerTests()
    {
        _sut = new ContaController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarContaAsync_DeveRetornarSucesso()
    {
        var request = new CriarContaRequest
        {
            IdPessoa = 1,
            Agencia = "1234",
            Numero = "123456",
            Status = EStatusConta.Ativa,
            LimiteTrasancao = 1000,
            LimiteCredito = 1000,
            Saldo = 1000
        };

        var response = new CriarContaResponse(1, "1234", "123456");

        _mediator.Send(Arg.Any<CriarContaRequest>()).Returns(Result.Success(response));

        // Act
        var result = await _sut.CriarContaAsync(request);

        // Assert
        Assert.IsType<ActionResult<CriarContaResponse>>(result);
        Assert.Equal(StatusCodes.Status200OK, (result.Result as ObjectResult)?.StatusCode);
        Assert.Equal(response, (result.Result as ObjectResult)?.Value);
    }

    [Fact]
    public async Task CriarContaAsync_DeveRetornarBadRequest()
    {
        // Arrange
        var request = new CriarContaRequest
        {
            IdPessoa = 1,
            Agencia = "1234",
            Numero = "123456",
            Status = EStatusConta.Ativa,
            LimiteTrasancao = 1000,
            LimiteCredito = 1000,
            Saldo = 1000
        };

        var expectedError = ContaMensagemErrors.UsuarioNaoEncontrado;

        _mediator.Send(Arg.Any<CriarContaRequest>()).Returns(Result.Error<CriarContaResponse>(new ExcecaoAplicacao(expectedError)));

        // Act
        var result = await _sut.CriarContaAsync(request);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
        
        var resultadoErro = Assert.IsType<ResultadoErro>(badRequestResult.Value);
        Assert.Equal(expectedError.Titulo, resultadoErro.Titulo);
        Assert.Equal(expectedError.Descricao, resultadoErro.Descricao);
    }

}
