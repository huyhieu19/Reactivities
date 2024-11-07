namespace Reactivities.Entity.Dtos;

public class PaginationParameter
{
    public string SearchKeyword { get; set; } = null;
    public Dictionary<string, List<string>> Filters { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public List<string> SearchColumns { get; set; } = [];
    public Dictionary<string, SortType> Sorter { get; set; }
}

public class PagedResult<T>
{
    public List<T> Data { get; set; }
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PagedResult(List<T> data, int totalItems, int pageNumber, int pageSize)
    {
        Data = data;
        TotalItems = totalItems;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}