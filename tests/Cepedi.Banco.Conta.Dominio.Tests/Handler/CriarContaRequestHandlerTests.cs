using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Handlers;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;

namespace Cepedi.Banco.Conta.Domain.Tests;

public class CriarContaRequestHandlerTests
{
    private readonly IContaRepository _contaRepository = Substitute.For<IContaRepository>();
    private readonly IUsuarioRepository _usuarioRepository = Substitute.For<IUsuarioRepository>();
    private readonly ILogger<CriarContaRequestHandler> _logger = Substitute.For<ILogger<CriarContaRequestHandler>>();
    private readonly CriarContaRequestHandler _sut;

    public CriarContaRequestHandlerTests()
    {
        _sut = new CriarContaRequestHandler(_contaRepository, _usuarioRepository, _logger);
    }

    [Fact]
    public async Task CriarContaAsync_QuandoCriar_DeveRetornarSucesso()
    {

        //Arrange 
        var conta = new CriarContaRequest { 
            IdPessoa = 1, 
            Agencia = "1234", 
            Numero = "123456", 
            Status = EStatusConta.Ativa, 
            LimiteTrasancao = 1000, 
            LimiteCredito = 1000, 
            Saldo = 0 };

        _contaRepository.ObterContaPorAgenciaNumeroAsync(conta.Agencia, conta.Numero)
            .Returns(Task.FromResult<ContaEntity>(null));

        _usuarioRepository.ObterUsuarioAsync(conta.IdPessoa)
            .Returns(new UsuarioEntity { Id = conta.IdPessoa });
            
        _contaRepository.CriarContaAsync(It.IsAny<ContaEntity>())
            .Returns(new ContaEntity { Id = 1, Agencia = conta.Agencia, Numero = conta.Numero });

        //Act
        var result = await _sut.Handle(conta, CancellationToken.None);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value?.Agencia.Should().Be(conta.Agencia);
        result.Value?.Numero.Should().Be(conta.Numero);
    }

    [Fact]
    public async Task CriarContaAsync_QuandoUsuarioNaoExiste_DeveRetornarErro()
    {
        //Arrange 
        var conta = new CriarContaRequest { 
            IdPessoa = 1, 
            Agencia = "1234", 
            Numero = "123456", 
            Status = EStatusConta.Ativa, 
            LimiteTrasancao = 1000, 
            LimiteCredito = 1000, 
            Saldo = 0 };

        _contaRepository.ObterContaPorAgenciaNumeroAsync(conta.Agencia, conta.Numero)
            .Returns(Task.FromResult<ContaEntity>(null));

        _usuarioRepository.ObterUsuarioAsync(conta.IdPessoa)
            .Returns(Task.FromResult<UsuarioEntity>(null));

        //Act
        var result = await _sut.Handle(conta, CancellationToken.None);

        //Assert
        result.IsSuccess.Should().BeFalse();
    }

}
