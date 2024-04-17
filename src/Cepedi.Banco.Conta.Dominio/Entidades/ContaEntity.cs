namespace Cepedi.Banco.Conta.Dominio.Entidades;
public class ContaEntity
{
    public int Id { get; set; }
    public string Agencia { get; set; }
    public string Numero { get; set; }
    public int IdPessoa { get; set; }
    public decimal Saldo { get; set; } = 0;
    public ICollection<TransacaoEntity>? TransacoesEnviadas { get; }
    public ICollection<TransacaoEntity>? TransacoesRecebidas { get; }
    public ICollection<ChavePixEntity>? ChavesPix { get; set; }
}
