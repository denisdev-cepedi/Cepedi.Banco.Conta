using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Dominio.Entidades;

public class TipoTransacaoEntity
{
    public ETipoTransacao Id { get; set; }
    public string Nome { get; set; }
    public ICollection<TransacaoEntity>? Transacoes { get; }

}
