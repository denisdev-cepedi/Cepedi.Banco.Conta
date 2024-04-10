namespace Cepedi.Banco.Conta.Domain.Entities;
public class TransacaoEntity
{
    public int Id { get; set; }
    public int IdContaOrigem { get; set; }
    //public Conta ContaOrigem { get; set; }
    public int IdContaDestino { get; set; }
    //public Conta ContaDestino { get; set; }

    public DateTime DataTransacao { get; set; }

    public int ValorTransacao { get; set; }
}
