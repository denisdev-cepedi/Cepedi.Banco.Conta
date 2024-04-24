namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record BuscarTransacaoResponse(int idTransacao, int idContaOrigem, int idContaDestino, decimal valorTransacao, DateTime dataTransacao);
