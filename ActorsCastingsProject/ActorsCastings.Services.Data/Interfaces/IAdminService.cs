using ActorsCastings.Web.ViewModels.Admin;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<DataToApproveViewModel> GetAllNotApprovedElements();

        Task ApproveElement(ApproveSubmitViewModel model);

        Task<IEnumerable<MovieToEditViewModel>> IndexViewAllMoviesForEditAsync();
        Task<IEnumerable<PlayToEditViewModel>> IndexViewAllPlaysForEditAsync();
        Task<IEnumerable<CastingToEditViewModel>> IndexViewAllCastingsForEditAsync();
        Task<IEnumerable<UserToEditViewModel>> IndexViewAllUsersForEditAsync();

        Task DeleteMovieAndItsRolesByIdAsync(string id);
        Task DeletePlayAndItsRolesByIdAsync(string id);
        Task DeleteCastingAndItsCastedActorsByIdAsync(string id);
        Task DeleteUserAndItsConnectedEntitiesByIdAsync(string id);
    }
}
