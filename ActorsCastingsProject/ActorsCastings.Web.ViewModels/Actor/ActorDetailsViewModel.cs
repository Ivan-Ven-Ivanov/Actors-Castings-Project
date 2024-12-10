using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;

namespace ActorsCastings.Web.ViewModels.Actor
{
    public class ActorDetailsViewModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Age { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string ProfilePictureUrl { get; set; } = null!;

        public string? Biography { get; set; }

        public IList<MovieViewModel> Movies { get; set; }
            = new List<MovieViewModel>();

        public IList<PlayViewModel> Plays { get; set; }
            = new List<PlayViewModel>();
    }
}
