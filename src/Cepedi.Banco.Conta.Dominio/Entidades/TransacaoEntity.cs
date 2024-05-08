using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Dominio.Entidades;
public class TransacaoEntity
{
    public int Id { get; set; }
    public required int IdContaOrigem { get; set; }
    public  ContaEntity? ContaOrigem { get; set; }
    public required int IdContaDestino { get; set; }
    public  ContaEntity? ContaDestino { get; set; }
    public DateTime DataTransacao { get; set; }
    public decimal ValorTransacao { get; set; }
    public TipoTransacaoEntity? TipoTransacao { get; set; }
    public required ETipoTransacao IdTipoTransacao { get; set; }
    
}
