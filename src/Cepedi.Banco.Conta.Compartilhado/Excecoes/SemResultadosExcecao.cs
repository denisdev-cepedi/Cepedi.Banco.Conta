using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Compartilhado.Excecoes;
public class SemResultadosExcecao : ExcecaoAplicacao
{
    public SemResultadosExcecao() : 
        base(ContaMensagemErrors.SemResultados)
    {
    }
}
