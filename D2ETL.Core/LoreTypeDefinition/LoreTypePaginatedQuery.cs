using D2ETL.Core.Models;

namespace D2ETL.Core.LoreTypeDefinition;

public class LoreTypePaginatedQuery : IQuery<PaginatedResult<List<LoreTypeResponse>>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

    public LoreTypePaginatedQuery(int pageSize, int pageNumber)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}