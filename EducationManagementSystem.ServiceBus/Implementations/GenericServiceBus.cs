using EducationManagementSystem.Abstractions;
using EducationManagementSystem.ServiceBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EducationManagementSystem.ServiceBus.Implementations
{
    public class GenericServiceBus : IServiceBus
    {
        private readonly IServiceProvider _serviceProvider;

        public GenericServiceBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task SendCommandAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler =
                _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            return handler.HandleAsync(command);
        }

        public Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
        {
            var handler =
                _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

            return handler.HandleAsync(query);
        }
    }
}