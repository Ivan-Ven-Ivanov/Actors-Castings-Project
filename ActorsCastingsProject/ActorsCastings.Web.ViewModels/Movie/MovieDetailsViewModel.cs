using ActorsCastings.Web.ViewModels.Actor;

namespace ActorsCastings.Web.ViewModels.Movie
{
    public class MovieDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Genre { get; set; } = null!;

        public string? Description { get; set; }

        public IList<ActorInMovieViewModel> Actors { get; set; }
            = new List<ActorInMovieViewModel>();
    }
}
