using ActorsCastings.Web.ViewModels.Play;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IPlayService
    {
        Task<IList<PlayViewModel>> IndexGetPaginatedPlaysAsync(int page, int pageSize);

        Task<int> GetPlaysCountAsync();

        Task<PlayDetailsViewModel> GetPlayDetailsAsync(string id);

        Task AddPlayAndRoleInItAsync(AddPlayViewModel model, string userId);
    }
}
