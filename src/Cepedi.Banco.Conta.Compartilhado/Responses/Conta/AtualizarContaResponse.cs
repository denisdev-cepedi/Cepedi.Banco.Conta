using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public record AtualizarContaResponse(int IdConta, EStatusConta Status, decimal LimiteTrasancao, decimal LimiteCredito);