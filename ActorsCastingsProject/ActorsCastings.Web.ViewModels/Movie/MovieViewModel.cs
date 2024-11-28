namespace ActorsCastings.Web.ViewModels.Movie
{
    public class MovieViewModel
    {
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
