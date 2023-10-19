namespace API.Helpers;

public class Pager<T> where T : class
{
    public string Search { get; set; }
    public int PageIndex { get; set; }
    public int pageSize { get; set; }
    public int Total { get; set; }
    public List<T> Registers { get; set; }
    public Pager(string search, int pageIndex, int pageSize, int total, List<T> registers)
    {
        Search = search;
        PageIndex = pageIndex;
        this.pageSize = pageSize;
        Total = total;
        Registers = registers;
    }

    public int totalpages
    {
        get { return (int)Math.Ceiling(Total / (double)pageSize); }
        set { this.totalpages = value; }
    }
    public bool hasPreviousPage
    {
        get { return (PageIndex > 1); }
        set { this.hasPreviousPage = value; }
    }
    public bool hasNextPage
    {
        get { return (PageIndex < totalpages); }
        set { this.hasNextPage = value; }
    }

}
