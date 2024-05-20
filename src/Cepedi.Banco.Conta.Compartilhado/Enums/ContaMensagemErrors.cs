﻿using Cepedi.Banco.Conta.Compartilhado.Excecoes;

namespace Cepedi.Banco.Conta.Compartilhado.Enums;
public class ContaMensagemErrors
{
    public static readonly ResultadoErro Generico = new()
    {
        Titulo = "Ops ocorreu um erro no nosso sistema",
        Descricao = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static readonly ResultadoErro SemResultados = new()
    {
        Titulo = "Sua busca não obteve resultados",
        Descricao = "Tente buscar novamente",
        Tipo = ETipoErro.Alerta
    };

    public static ResultadoErro ErroGravacaoConta = new()
    {
        Titulo = "Ocorreu um erro na gravação",
        Descricao = "Ocorreu um erro na gravação da conta. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro DadosInvalidos = new()
    {
        Titulo = "Dados inválidos",
        Descricao = "Os dados enviados na requisição são inválidos",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro ErroGravacaoUsuario = new()
    {
        Titulo = "Ocorreu um erro na gravação",
        Descricao = "Ocorreu um erro na gravação do usuario. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro ContaExistente = new()
    {
        Titulo = "Conta já existente",
        Descricao = "Já existe uma conta com o mesmo número e agência",
        Tipo = ETipoErro.Alerta
    };

    public static ResultadoErro UsuarioNaoEncontrado = new()
    {
        Titulo = "Usuário não encontrado",
        Descricao = "Não foi possível encontrar o usuário informado para a criação da conta",
        Tipo = ETipoErro.Alerta
    };
          
    public static ResultadoErro ContaNaoExiste = new()
    {
        Titulo = "Conta não encontrada",
        Descricao = "A conta informada não foi encontrada",
        Tipo = ETipoErro.Erro
    };
}
