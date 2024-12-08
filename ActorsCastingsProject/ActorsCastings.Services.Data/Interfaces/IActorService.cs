using ActorsCastings.Web.ViewModels.Actor;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IActorService
    {
        Task<bool> IsUserActorAsync(string userId);

        Task<int> GetActorCountAsync();

        Task<IList<ActorIndexViewModel>> IndexGetPaginatedActorsAsync(int page, int pageSize);

        Task<ActorDetailsViewModel> GetActorDetailsByIdAsync(string id);
    }
}
