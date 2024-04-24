namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record ExtratoContaResponse(int idConta, string dataExtrato, double saldo, List<BuscarTransacaoResponse> transacoes);