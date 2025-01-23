using D2ETL.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace D2ETL.Core.LoreTypeDefinition;

public class LoreTypeQueryHandler : IRequestHandler<LoreTypePaginatedQuery, PaginatedResult<List<LoreTypeResponse>>>
{
    private readonly ILoreTypeRepository _repository;
    private readonly IHttpContextAccessor _httpAccessor;

    public LoreTypeQueryHandler(ILoreTypeRepository repository, IHttpContextAccessor httpAccessor)
    {
        _repository = repository;
        _httpAccessor = httpAccessor;
    }

    public async Task<PaginatedResult<List<LoreTypeResponse>>> Handle(LoreTypePaginatedQuery request, CancellationToken cancellationToken)
    {
        var count = _repository.TotalNumberOfRecords;
        var context = _httpAccessor.HttpContext;
        var results = await _repository.GetPagedResult(request.PageSize, request.PageNumber * request.PageSize - 1);
        var response = results.Select(x => new LoreTypeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Subtitle = x.Subtitle,
        }).ToList();
        var paginatedResult = new PaginatedResult<List<LoreTypeResponse>>(request.PageSize, request.PageNumber, count, response, context);
        
        return paginatedResult;
    }
}