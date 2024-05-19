using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Handlers;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Cepedi.Banco.Conta.Domain.Tests;

public class CriarChavePixRequestHandlerTests
{
    private readonly IChavePixRepository _chavePixRepository = Substitute.For<IChavePixRepository>();
    private readonly IContaRepository _contaRepository = Substitute.For<IContaRepository>();
    private readonly ILogger<CriarChavePixRequestHandler> _logger = Substitute.For<ILogger<CriarChavePixRequestHandler>>();
    private readonly CriarChavePixRequestHandler _sut;

    public CriarChavePixRequestHandlerTests()
    {
        _sut = new CriarChavePixRequestHandler(_chavePixRepository, _contaRepository, _logger);
    }

    [Fact]
    public async Task CriarChavePixAsync_QuandoCriar_DeveRetornarSucesso()
    {

        //Arrange 
        var chavePix = new CriarChavePixRequest { 
            IdConta = 1, 
            Valor = "123456", 
            IdTipoChavePix = ETipoPix.CPF };

        var conta = new ContaEntity { Id = 1, Agencia = "1234", Numero = "123456" };

        var chavePixEntity = new ChavePixEntity { Id = 1, IdConta = chavePix.IdConta, Valor = chavePix.Valor, IdTipoChavePix = chavePix.IdTipoChavePix };

        _contaRepository.ObterContaAsync(chavePix.IdConta)
            .Returns(Task.FromResult(conta));

        _chavePixRepository.CriarChavePixAsync(Arg.Any<ChavePixEntity>())
            .Returns(chavePixEntity);

        //Act
        var result = await _sut.Handle(chavePix, CancellationToken.None);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value?.idChavePix.Should().Be(chavePixEntity.Id);
    }

    [Fact]
    public async Task CriarChavePixAsync_QuandoContaNaoExiste_DeveRetornarErro()
    {
        //Arrange 
        var chavePix = new CriarChavePixRequest { 
            IdConta = 1, 
            Valor = "123456", 
            IdTipoChavePix = ETipoPix.CPF };

        _contaRepository.ObterContaAsync(chavePix.IdConta)
            .Returns(Task.FromResult<ContaEntity>(null));

        //Act
        var result = await _sut.Handle(chavePix, CancellationToken.None);

        //Assert
        result.IsSuccess.Should().BeFalse();
    }

}
