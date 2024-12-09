using ActorsCastings.Web.ViewModels.Casting;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ICastingService
    {
        Task<IList<CastingViewModel>> IndexGetPaginatedCastingsAsync(int page, int pageSize);

        Task<int> GetCastingsCountAsync();

        Task AddCastingAsync(AddCastingViewModel model, string userId);

        Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(string id, string userId);

        Task ApplyForCastingAsync(string id, string userId);
    }
}
