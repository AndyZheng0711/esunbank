namespace MyWebAPI.Models
{
    public class PageInfoModel
    {
        public int PageSize { get; set; } = 0;
        public int PageNo { get; set; } = 0;
        public int TotalPage { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
        public string OrderByColumn { get; set; } = "";
    }
}
