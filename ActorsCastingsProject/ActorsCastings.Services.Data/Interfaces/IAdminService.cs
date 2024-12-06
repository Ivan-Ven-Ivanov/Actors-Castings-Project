using ActorsCastings.Web.ViewModels.Admin;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<DataToApproveViewModel> GetAllNotApprovedElements();

        Task<bool> ApproveElement(ApproveSubmitViewModel model);

        Task<IEnumerable<MovieToEditViewModel>> IndexViewAllMoviesForEditAsync();
        Task<IEnumerable<PlayToEditViewModel>> IndexViewAllPlaysForEditAsync();

        Task<bool> DeleteMovieAndItsRolesByIdAsync(string id);
        Task<bool> DeletePlayAndItsRolesByIdAsync(string id);
    }
}
