using ActorsCastings.Web.ViewModels.CastingAgentProfile;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ICastingAgentProfileService
    {
        Task<CastingAgentProfileViewModel> IndexGetMyProfileAsync(string id);

        Task<bool> CompleteCastingAgentProfileAsync(string id, CastingAgentProfileViewModel model);

        Task<UpdateCastingAgentProfileViewModel> GetCastingAgentProfileDataAsync(string id);

        Task<bool> UpdateCastingAgentProfileAsync(UpdateCastingAgentProfileViewModel model);
    }
}
