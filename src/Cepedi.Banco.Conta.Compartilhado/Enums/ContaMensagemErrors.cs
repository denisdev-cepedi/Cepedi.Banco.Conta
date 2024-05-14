using Cepedi.Banco.Conta.Compartilhado.Excecoes;

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

    public static ResultadoErro ErroStatusConta = new()
    {
        Titulo = "Conta com Status não ativa",
        Descricao = "Ocorreu um erro na operação devido ao Status da conta",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro ErroTransacaoSaldo = new()
    {
        Titulo = "Valor ultrapassa saldo da conta",
        Descricao = "Não foi possível criar a transação. Valor acima do saldo da conta",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro ErroTransacaoLimiteTransacao = new()
    {
        Titulo = "Valor ultrapassa limite de transacao da conta",
        Descricao = "Não foi possível criar a transação. Valor acima do limite de transacao da conta",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro ErroTransacaoLimiteCredito = new()
    {
        Titulo = "Valor ultrapassa limite de saldo da conta",
        Descricao = "Não foi possível criar a transação. Valor acima do limite de saldo da conta",
        Tipo = ETipoErro.Erro
    };

}
