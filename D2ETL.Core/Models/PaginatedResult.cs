using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace D2ETL.Core.Models;

public class PaginatedResult<TResponse>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public long TotalRecords { get; set; }
    public double TotalPages { get; set; }
    public Uri FirstPage { get; set; }
    public Uri LastPage { get; set; }
    public Uri NextPage { get; set; }
    public Uri PreviousPage { get; set; }
    public TResponse Result { get; set; }
    private Uri BaseUrl { get; set;}

    public PaginatedResult(
        int pageSize,
        int pageNumber,
        long count,
        TResponse result,
        HttpContext httpContext
        )
    {
        PageSize = pageSize > 10 ? 10 : pageSize;
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        TotalRecords = count;
        Result = result;
        TotalPages = (int)Math.Ceiling((double)count / PageSize);
        BaseUrl = GetBaseUri(httpContext);
        FirstPage = GetFirstPageUri(httpContext);
        LastPage = GetLastPageUri(httpContext);
        NextPage = GetNextPageUri(httpContext);
        PreviousPage = GetPreviousPageUri(httpContext);
    }

    public Uri GetBaseUri(HttpContext httpContext)
    {
        return new Uri(GetScheme(httpContext) + "://" + GetHost(httpContext) + GetBasePath(httpContext) + GetPath(httpContext));
    }

    public Uri GetFirstPageUri(HttpContext httpContext)
    {
        return new Uri(QueryHelpers.AddQueryString(BaseUrl.ToString(), new Dictionary<string, string?>
        {
            ["pageSize"] = $"{PageSize}",
            ["pageNumber"] = $"{1}",
        }));
    }

    public Uri GetLastPageUri(HttpContext httpContext)
    {
        return LastPage = new Uri(QueryHelpers.AddQueryString(BaseUrl.ToString(), new Dictionary<string, string?>
        {
            ["pageSize"] = $"{PageSize}",
            ["pageNumber"] = $"{Math.Ceiling((double)TotalRecords / PageSize)}",
        }));
    }

    public Uri GetNextPageUri(HttpContext httpContext)
    {
        var nextPage = PageNumber + 1;
        if (nextPage >= TotalPages)
        {
            return FirstPage;
        }
        else
        {
            return new Uri(QueryHelpers.AddQueryString(BaseUrl.ToString(), new Dictionary<string, string?>
            {
                ["pageSize"] = $"{PageSize}",
                ["pageNumber"] = $"{nextPage}",
            }));
        }
    }

    public Uri GetPreviousPageUri(HttpContext httpContext)
    {
        var prevPage = PageNumber - 1;
        if (prevPage <= 1)
        {
            prevPage = 1;
            return LastPage;
        }
        else
        {
            return new Uri(QueryHelpers.AddQueryString(BaseUrl.ToString(), new Dictionary<string, string?>
            {
                ["pageSize"] = $"{PageSize}",
                ["pageNumber"] = $"{prevPage}",
            }));
        }
    }

    public string GetScheme(HttpContext context)
    {
        return context.Request.Scheme;
    }

    public string GetHost(HttpContext context)
    {
        return context.Request.Host.Value;
    }

    public string GetBasePath(HttpContext context)
    {
        return context.Request.PathBase.Value;
    }

    public string GetPath(HttpContext context)
    {
        return context.Request.Path.Value;
    }
}