namespace ActorsCastings.Web.ViewModels.Movie
{
    public class MovieViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsSelected { get; set; }

        public bool IsRoleInMovieApproved { get; set; }
    }
}
