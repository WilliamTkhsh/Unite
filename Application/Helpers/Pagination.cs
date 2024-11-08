namespace Unite.Application.Helpers
{
    public class Pagination<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public T Data { get; set; }

        public Pagination(int totalCount, T data, int currentPage, int pageSize)
        {
            TotalCount = totalCount;
            Data = data;
            CurrentPage = currentPage;
            PageSize = pageSize;

            TotalPages = (int)Math.Ceiling((double)TotalPages / (double)PageSize);

            HasPreviousPage = CurrentPage > 1;
            HasNextPage = CurrentPage < TotalPages;
        }
    }
}
