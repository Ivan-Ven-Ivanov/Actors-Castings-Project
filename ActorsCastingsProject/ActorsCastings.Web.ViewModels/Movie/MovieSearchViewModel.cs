namespace ActorsCastings.Web.ViewModels.Movie
{
    public class MovieSearchViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string? Description { get; set; }
    }
}
