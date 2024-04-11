namespace Cepedi.Banco.Conta.Domain.Entities;
public class ContaEntity
{
    public int IdConta { get; set; }
    public string Agencia { get; set; }
    public string Numero { get; set; }
    public int IdPessoa { get; set; }
    public decimal Saldo { get; set; } = 0;
    public ICollection<TransacaoEntity>? Transacoes { get; }
    public ICollection<ChavePixEntity>? ChavesPix { get; set; }
}