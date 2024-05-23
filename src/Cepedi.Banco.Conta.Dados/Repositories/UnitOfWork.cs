using Cepedi.Banco.Conta.Dominio.Repositorio;

namespace Cepedi.Banco.Conta.Dados.Repositorios;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T> Repository<T>() 
        where T : class
    {
        if(_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }

        var repository = new Repository<T>(_context);
        _repositories[typeof(T)] = repository;

        return repository;
    }
    
    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var retorno = await _context.SaveChangesAsync(cancellationToken);

        return retorno > 0;
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
