using ActorsCastings.Web.ViewModels.Casting;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ICastingService
    {
        Task<IEnumerable<CastingViewModel>> IndexGetAllAsync();

        Task AddCastingAsync(AddCastingViewModel model);

        Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(Guid id);
    }
}
