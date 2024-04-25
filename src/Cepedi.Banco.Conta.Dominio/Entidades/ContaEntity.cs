using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Dominio.Entidades;
public class ContaEntity
{
    public int Id { get; set; }
    public required string Agencia { get; set; }
    public required string Numero { get; set; }
    public int IdPessoa { get; set; }
    public DateTime DataCriacao { get; } = DateTime.Now;
    public EStatusConta Status { get; set; }
    public decimal LimiteTrasancao { get; set; }
    public decimal LimiteCredito { get; set; }
    public decimal Saldo { get; set; } = 0;
    public ICollection<TransacaoEntity>? TransacoesEnviadas { get; }
    public ICollection<TransacaoEntity>? TransacoesRecebidas { get; }
    public ICollection<ChavePixEntity>? ChavesPix { get; set; }
}
