using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record BuscarSaldoContaResponse (int IdConta, string Agencia, string Numero, decimal Saldo); 