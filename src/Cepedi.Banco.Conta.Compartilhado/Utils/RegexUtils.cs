using System.Text.RegularExpressions;

namespace Cepedi.Banco.Conta.Compartilhado.Utils;
public static class RegexUtils
{
    // Documentação do Banco Central do Brasil sobre a validação dos valores:
    // https://www.bcb.gov.br/content/estabilidadefinanceira/pix/API-DICT.html#tag/Key
    
    public static readonly Regex CpfRegex = new Regex("^[0-9]{11}$", RegexOptions.Compiled);
    public static readonly Regex CnpjRegex = new Regex("^[0-9]{14}$", RegexOptions.Compiled);
    public static readonly Regex TelefoneRegex = new Regex("^\\+[1-9]\\d{1,14}$", RegexOptions.Compiled);
    public static readonly Regex EmailRegex = new Regex("^[a-z0-9.!#$&'*+\\/=?^_`{|}~-]+@[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?(?:\\.[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?)*$", RegexOptions.Compiled);
    public static readonly Regex ChaveAleatoriaRegex = new Regex("^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$", RegexOptions.Compiled);
}
