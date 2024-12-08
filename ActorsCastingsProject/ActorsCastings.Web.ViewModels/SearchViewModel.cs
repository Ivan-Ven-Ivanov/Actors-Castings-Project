using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Casting;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;

namespace ActorsCastings.Web.ViewModels
{
    public class SearchViewModel
    {
        public IList<MovieSearchViewModel> Movies { get; set; }
            = new List<MovieSearchViewModel>();

        public IList<PlaySearchViewModel> Plays { get; set; }
            = new List<PlaySearchViewModel>();

        public IList<CastingSearchViewModel> Castings { get; set; }
            = new List<CastingSearchViewModel>();

        public IList<ActorSearchViewModel> Actors { get; set; }
            = new List<ActorSearchViewModel>();
    }
}
