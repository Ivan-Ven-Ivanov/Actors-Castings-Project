using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IActorProfileService
    {
        Task<ActorProfileViewModel> IndexGetMyProfileAsync(string id);

        Task<bool> CompleteActorProfileAsync(string id, ActorProfileViewModel model);

        Task<SelectedMovieViewModel> GetAllMoviesForSelectAsync(SelectedMovieViewModel model);

        SelectedMovieViewModel SelectAMovieForValidation(SelectedMovieViewModel model);

        Task<IEnumerable<PlayViewModel>> GetAllPlaysAsync();

        Task<bool> AddSelectedMovieToProfileAsync(Guid id, string role, string userId);

        Task<bool> AddSelectedPlayToProfileAsync(Guid id, string role, string userId);

        Task<UpdateActorProfileViewModel> GetActorProfileDataAsync(string id);

        Task<bool> UpdateActorProfileAsync(UpdateActorProfileViewModel model);
    }
}
