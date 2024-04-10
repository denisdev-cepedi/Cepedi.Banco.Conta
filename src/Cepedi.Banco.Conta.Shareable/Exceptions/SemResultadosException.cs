using Cepedi.Banco.Conta.Shareable.Enums;

namespace Cepedi.Banco.Conta.Shareable.Exceptions;
public class SemResultadosException : ApplicationException
{
    public SemResultadosException() : 
        base(BancoCentralMensagemErrors.SemResultados)
    {
    }
}
