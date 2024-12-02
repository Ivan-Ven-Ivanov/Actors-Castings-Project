namespace ActorsCastings.Web.ViewModels.Movie
{
    public class AddMovieViewModel
    {
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Genre { get; set; } = null!;

        public string? Description { get; set; }
    }
}
