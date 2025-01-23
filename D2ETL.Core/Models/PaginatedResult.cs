using Microsoft.AspNetCore.Http;

namespace D2ETL.Core.Models;

public class PaginatedResult<TResponse>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalRecords { get; set; }
    
    public double TotalPages => Math.Ceiling((double)TotalRecords / PageSize);

    public Uri FirstPage { get; set; } = null!;
    public Uri LastPage { get; set; } = null!;
    public Uri NextPage { get; set; } = null!;
    public Uri PreviousPage { get; set; } = null!;
    public TResponse Result { get; set; }

    public PaginatedResult(
        int pageSize,
        int pageNumber,
        TResponse result
        )
    {
        PageSize = pageSize > 10 ? 10 : pageSize;
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        Result = result;
    }

    public Uri GetBaseUri(HttpContext context)
    {
        return new Uri(context.Request.Scheme + "://" + context.Request.Host.Value + context.Request.PathBase.Value);
    }

    public string GetScheme(HttpContext context)
    {
        return context.Request.Scheme;
    }

    public string GetHost(HttpContext context)
    {
        return context.Request.Host.Value;
    }

    public string GetPath(HttpContext context)
    {
        return context.Request.Path.Value;
    }
}