﻿using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado;

public class BuscarContaRequest : IRequest<Result<BuscarContaResponse>>
{
    public int IdPessoa { get; set; }
}