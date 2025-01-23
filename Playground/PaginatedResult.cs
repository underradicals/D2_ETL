namespace Playground;

public class PaginatedResult<TResponse>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalRecords { get; set; }
    public double TotalPages => Math.Ceiling((double)TotalRecords / PageSize);
    public Uri FirstPage { get; set; }
    public Uri LastPage { get; set; }
    public Uri NextPage { get; set; }
    public Uri PreviousPage { get; set; }
    public TResponse Result { get; set; }
    
    public PaginatedResult(
        int pageSize,
        int pageNumber,
        int totalRecords,
        Uri firstPage,
        Uri lastPage,
        Uri nextPage,
        Uri previousPage,
        TResponse result
    )
    {
        PageSize = pageSize > 10 ? 10 : pageSize;
        PageNumber = pageNumber < 0 ? 1 : pageNumber;
        TotalRecords = totalRecords < 0 ? 0 : totalRecords;
        FirstPage = firstPage;
        LastPage = lastPage;
        NextPage = nextPage;
        PreviousPage = previousPage;
        Result = result;
    }
}