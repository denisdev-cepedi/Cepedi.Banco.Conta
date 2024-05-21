﻿using Cepedi.Banco.Conta.Dominio.Entidades;

namespace Cepedi.Banco.Conta.Dominio.Repositorio.Queries;
public interface IPessoaQueryRepository
{
    Task<List<PessoaEntity>> ObterPessoasAsync(string nome);
}