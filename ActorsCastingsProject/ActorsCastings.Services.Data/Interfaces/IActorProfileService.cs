using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IActorProfileService
    {
        Task<ActorProfileViewModel> IndexGetMyProfileAsync(string id);

        Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync();

        Task<IEnumerable<PlayViewModel>> GetAllPlaysAsync();

        Task<bool> AddSelectedMovieToProfileAsync(Guid id, string role, string userId);

        Task<bool> AddSelectedPlayToProfileAsync(Guid id, string role, string userId);
    }
}
