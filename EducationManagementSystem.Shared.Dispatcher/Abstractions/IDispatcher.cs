using EducationManagementSystem.Abstractions;

namespace EducationManagementSystem.Shared.Dispatcher.Abstractions
{
    public interface IDispatcher
    {
        Task SendCommand<TCommand>(TCommand command) where TCommand : ICommand; 
        Task<TResult> SendQuery<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
