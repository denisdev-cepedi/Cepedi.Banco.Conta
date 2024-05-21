namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record FazerDepositoContaResponse (int IdConta, string Agencia, string Numero, decimal Saldo); 