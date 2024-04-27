namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record BuscarExtratoPorPeriodoResponse(int idConta, DateTime dataExtrato, decimal saldo, List<BuscarTransacaoResponse> transacoes);