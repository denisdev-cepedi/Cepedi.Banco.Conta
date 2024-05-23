using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Compartilhado.Responses;

public class ChavePixInfo
{
    public int Id { get; set; }
    public required string Valor { get; set; }
    public required string Tipo { get; set; }
}

public record BuscarChavePixPorContaResponse(int IdConta, List<ChavePixInfo> ChavesPix);
