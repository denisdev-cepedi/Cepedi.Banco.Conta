﻿using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class BuscarContaRequest : IRequest<Result<BuscarContaResponse>>
{
    public int IdConta { get; set; }
}