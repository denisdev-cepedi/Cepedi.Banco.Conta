using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Compartilhado.Excecoes;
public class ResultadoErro
{
    public string Titulo { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public ETipoErro Tipo { get; set; }
}
