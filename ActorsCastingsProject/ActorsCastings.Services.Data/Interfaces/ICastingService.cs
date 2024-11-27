using ActorsCastings.Web.ViewModels.Casting;
using System.Security.Claims;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ICastingService
    {
        Task<IEnumerable<CastingViewModel>> IndexGetAllAsync();

        Task<bool> AddCastingAsync(AddCastingViewModel model, ClaimsPrincipal userPrincipal);

        Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(string id, ClaimsPrincipal userPrincipal);

        Task<bool> ApplyForCastingAsync(string id, ClaimsPrincipal userPrincipal);
    }
}
