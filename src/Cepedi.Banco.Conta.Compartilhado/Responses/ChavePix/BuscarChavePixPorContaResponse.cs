using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public class ChavePixInfo
{
    public string Valor { get; set; }
    public string Tipo { get; set; }
}

public record BuscarChavePixPorContaResponse(ICollection<ChavePixInfo> lista);
