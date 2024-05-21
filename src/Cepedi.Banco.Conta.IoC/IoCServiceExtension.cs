using Cepedi.Banco.Conta.Cache;
using Cepedi.Banco.Conta.Compartilhado;
using Cepedi.Banco.Conta.Dados;
using Cepedi.Banco.Conta.Dados.Repositories.Queries;
using Cepedi.Banco.Conta.Dados.Repositorios;
using Cepedi.Banco.Conta.Dominio.Handlers.Pipelines;
using Cepedi.Banco.Conta.Dominio.Queries;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using Cepedi.Banco.Conta.Dominio.Servicos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cepedi.Banco.Conta.IoC
{
    public static class IoCServiceExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurarDbContext(services, configuration);
            services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExcecaoPipeline<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacaoComportamento<,>));

            ConfigurarFluentValidation(services);
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IChavePixRepository, ChavePixRepository>();
            //services.AddHttpContextAccessor();

            services.AddScoped<ITransacaoQueryRepository, TransacaoQueryRepository>();

            // Cache Redis
            services.AddStackExchangeRedisCache(obj =>
            {
                obj.Configuration = configuration["Redis::Connection"];
                obj.InstanceName = configuration["Redis::Instance"];
            });

            services.AddSingleton<IDistributedCache, RedisCache>();
            services.AddScoped(typeof(ICache<>), typeof(Cache<>));
            // CacheRedis

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void ConfigurarFluentValidation(IServiceCollection services)
        {
            var abstractValidator = typeof(AbstractValidator<>);
            var validadores = typeof(QualquerCoisa)
                .Assembly
                .DefinedTypes
                .Where(type => type.BaseType?.IsGenericType is true &&
                type.BaseType.GetGenericTypeDefinition() ==
                abstractValidator)
                .Select(Activator.CreateInstance)
                .ToArray();

            foreach (var validator in validadores)
            {
                services.AddSingleton(validator!.GetType().BaseType!, validator);
            }
        }

        private static void ConfigurarDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}
