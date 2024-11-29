using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IActorProfileService
    {
        Task<ActorProfileViewModel> IndexGetMyProfileAsync(string id);

        Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync();
    }
}
