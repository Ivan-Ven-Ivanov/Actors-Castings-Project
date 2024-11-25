using ActorsCastings.Web.ViewModels.Casting;
using System.Security.Claims;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ICastingService
    {
        Task<IEnumerable<CastingViewModel>> IndexGetAllAsync();

        Task<bool> AddCastingAsync(AddCastingViewModel model, ClaimsPrincipal userPrincipal);

        Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(Guid id);
    }
}
