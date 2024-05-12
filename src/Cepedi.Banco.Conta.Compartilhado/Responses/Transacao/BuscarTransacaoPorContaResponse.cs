using Cepedi.Banco.Conta.Compartilhado.Responses;

namespace Cepedi.Banco.Conta.Compartilhado;

public record BuscarTransacaoPorContaResponse(
    int idConta,
    List<BuscarTransacaoResponse> transacoes);