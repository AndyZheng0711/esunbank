namespace MyWebAPI.Models
{
    public class BaseModel
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public int PageNo { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public int TotalPage { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
