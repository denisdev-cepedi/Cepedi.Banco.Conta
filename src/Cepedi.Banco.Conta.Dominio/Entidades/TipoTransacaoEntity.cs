namespace Cepedi.Banco.Conta.Dominio.Entidades;

public class TipoTransacaoEntity
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<TransacaoEntity>? Transacoes { get; }

}
