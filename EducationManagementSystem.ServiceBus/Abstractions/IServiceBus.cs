using EducationManagementSystem.Abstractions;

namespace EducationManagementSystem.ServiceBus.Abstractions
{
    public interface IServiceBus
    {
        Task SendCommandAsync<TCommand>(TCommand command)
            where TCommand : ICommand;

        Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}