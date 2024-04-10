﻿using Cepedi.Shareable.Exceptions;

namespace Cepedi.Banco.Conta.Shareable.Exceptions;
public class ApplicationException : Exception
{
    public ApplicationException(ResponseErro erro)
     : base(erro.Descricao) => ResponseErro = erro;

    public ResponseErro ResponseErro { get; set; }
}
