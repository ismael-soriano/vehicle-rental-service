using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Respawn;
using Testcontainers.PostgreSql;
using VehicleRental.Microservice.Api;
using VehicleRental.Microservice.Infrastructure;
using VehicleRental.Microservice.Infrastructure.Persistence;
using Xunit;

[assembly: CLSCompliant(false)]

namespace VehicleRental.Microservice.FunctionalTests.Infrastructure
{
#pragma warning disable CA1001 // Disposable resources are released by xUnit through IAsyncLifetime.DisposeAsync().
    public sealed class CompositionRootTestFixture : IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder("postgres:16-alpine")
            .WithDatabase("vehiclerental")
            .WithUsername("vehiclerental")
            .WithPassword("vehiclerental")
            .Build();

        private NpgsqlConnection _connection;
        private Respawner _respawner;
        private ServiceProvider _serviceProvider;

        public IConfiguration Configuration { get; private set; }

        public async Task InitializeAsync()
        {
            await _postgreSqlContainer.StartAsync();

            var connectionString = _postgreSqlContainer.GetConnectionString();

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            ConfigureServices(services);
            services.AddPersistence(connectionString);
            services.AddSingleton(Configuration);

            _serviceProvider = services.BuildServiceProvider();

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<VehicleRentalDbContext>();
                await context.Database.MigrateAsync();
            }

            _connection = new NpgsqlConnection(connectionString);
            await _connection.OpenAsync();

            _respawner = await Respawner.CreateAsync(_connection, new RespawnerOptions
            {
                DbAdapter = DbAdapter.Postgres,
                SchemasToInclude = ["public"],
                TablesToIgnore = ["__EFMigrationsHistory"],
            });
        }

        public async Task ResetDatabaseAsync() => await _respawner.ResetAsync(_connection);

        public async Task DisposeAsync()
        {
            if (_connection is not null)
            {
                await _connection.DisposeAsync();
            }

            if (_serviceProvider is not null)
            {
                await _serviceProvider.DisposeAsync();
            }

            await _postgreSqlContainer.DisposeAsync();
        }

        public async Task UsingHandlerForRequest<TRequest>(Func<IRequestHandler<TRequest, Unit>, Task> handlerAction)
            where TRequest : IRequest<Unit>
        {
            ArgumentNullException.ThrowIfNull(handlerAction);

            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<TRequest, Unit>>();

            await handlerAction.Invoke(handler);
        }

        public async Task UsingHandlerForRequestResponse<TRequest, TResponse>(Func<IRequestHandler<TRequest, TResponse>, Task> handlerAction)
            where TRequest : IRequest<TResponse>
        {
            ArgumentNullException.ThrowIfNull(handlerAction);

            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

            if (handler == null)
            {
                Debug.Fail("The requested handler has not been registered");
            }

            await handlerAction.Invoke(handler);
        }

        public async Task UsingRepository<TRepository>(Func<TRepository, Task> handlerAction)
        {
            ArgumentNullException.ThrowIfNull(handlerAction);

            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<TRepository>();

            if (handler == null)
            {
                Debug.Fail("The requested handler has not been registered");
            }

            await handlerAction.Invoke(handler);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDependencies();
            services.AddLogging();
            services.AddBaseInfrastructure(true);
        }
    }
#pragma warning restore CA1001
}
