using System.Text.Json;
using System.Text.Json.Serialization;
using Cepedi.Banco.Conta.Dominio.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Cepedi.BancoCentral.Conta.Cache;

public class Cache<T> : ICache<T>
{
    private readonly IDistributedCache _cache;

    public Cache(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T> ObterAsync(string chave)
    {
        var json = await _cache.GetStringAsync(chave);

        if (json == null) return default!;

        return JsonSerializer.Deserialize<T>(json);
    }

    public async Task SalvarAsync(string chave, T objeto, int tempoExpiracao = 10)
    {
        await _cache.SetStringAsync(chave, JsonSerializer.Serialize<T>(objeto), new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(tempoExpiracao)
        });
    }
}