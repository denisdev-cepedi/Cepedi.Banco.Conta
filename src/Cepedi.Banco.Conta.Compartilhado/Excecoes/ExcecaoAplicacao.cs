namespace Cepedi.Banco.Conta.Compartilhado.Excecoes;
public class ExcecaoAplicacao : Exception
{
    public ExcecaoAplicacao(ResultadoErro erro)
     : base(erro.Descricao) => ResponseErro = erro;

    public ResultadoErro ResponseErro { get; set; }
}
