using ActorsCastings.Web.ViewModels.Admin;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<DataToApproveViewModel> GetAllNotApprovedElements();

        Task<bool> ApproveElement(ApproveSubmitViewModel model);

        Task<IEnumerable<MovieToEditViewModel>> IndexViewAllMoviesForEditAsync();

        Task<bool> DeleteMovieByIdAsync(string id);
    }
}
