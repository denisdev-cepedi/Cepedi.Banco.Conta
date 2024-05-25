using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record BuscarContaResponse (int IdConta, int IdPessoa, string Agencia, string Numero, DateTime DataCriacao, EStatusConta Status, decimal LimiteTrasancao, decimal LimiteCredito, decimal Saldo); 