namespace Cepedi.Banco.Conta.Domain.Entities;
public class ContaEntity
{
    public int IdConta { get; set; }
    public int Agencia { get; set; }
    public int Numero { get; set; }
    public int IdPessoa { get; set; }
    // public PessoaEntity? Pessoa { get; }
    public decimal Saldo { get; set; } = 0;
    public ICollection<TransacaoEntity>? Transacoes { get; }
    public string? ChavePix { get; set; }
}