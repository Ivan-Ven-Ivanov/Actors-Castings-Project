using ActorsCastings.Web.ViewModels.Actor;

namespace ActorsCastings.Web.ViewModels.Play
{
    public class PlayDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public IList<ActorInPlayViewModel> Actors { get; set; }
            = new List<ActorInPlayViewModel>();
    }
}
