using Cepedi.Banco.Conta.Shareable.Enums;

namespace Cepedi.Banco.Conta.Domain.Entities;
public class ChavePixEntity
{
    public int IdChavePix { get; set; }
    public int IdConta { get; set; }
    public int IdTipo { get; set; }
    public string ValorToken { get; set; }
}
