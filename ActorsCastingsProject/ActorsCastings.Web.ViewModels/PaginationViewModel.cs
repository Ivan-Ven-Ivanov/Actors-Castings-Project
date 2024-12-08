namespace ActorsCastings.Web.ViewModels
{
    public class PaginationViewModel<T>
    {
        public IList<T> Items { get; set; }
            = new List<T>();

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

        public int PageSize { get; set; }

        public int TotalItems { get; set; }


        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
