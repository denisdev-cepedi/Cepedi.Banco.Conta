﻿using Cepedi.Banco.Conta.Dominio.Entidades;

namespace Cepedi.Banco.Conta.Dominio.Repositorio.Queries;
public interface IPessoaQueryRepository
{
    Task<List<ContaEntity>> ObterPessoasAsync(string nome);
}