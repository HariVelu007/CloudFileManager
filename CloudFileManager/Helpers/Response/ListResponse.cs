namespace CloudFileManager.Helpers.Response
{
    public class ListResponse<T> : Response
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public List<T> Model { get; set; }
        public int TotalRecords { get; set; }
    }
}
