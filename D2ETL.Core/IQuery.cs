using MediatR;

namespace D2ETL.Core;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
    
}

public interface IQuery : IRequest { }