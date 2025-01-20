using MediatR;

namespace D2ETL.Core;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}