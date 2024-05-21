namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record FazerSaqueContaResponse (int IdConta, string Agencia, string Numero, decimal Saldo); 