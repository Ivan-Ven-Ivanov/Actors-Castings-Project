using ActorsCastings.Web.ViewModels.Actor;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IActorService
    {
        Task<bool> IsUserActorAsync(string userId);

        Task<IEnumerable<ActorIndexViewModel>> IndexGetAllActorsAsync();

        Task<ActorDetailsViewModel> GetActorDetailsByIdAsync(string id);
    }
}
