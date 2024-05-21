namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record BuscarTransacoesRecentesResponse(
    int idConta,
    List<BuscarTransacaoResponse> transacoes);
