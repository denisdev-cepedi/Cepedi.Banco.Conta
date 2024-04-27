namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record BuscarExtratoPorMesResponse(int idConta, DateTime dataExtrato, decimal saldo, List<BuscarTransacaoResponse> transacoes);