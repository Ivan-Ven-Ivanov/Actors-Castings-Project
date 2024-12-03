using ActorsCastings.Web.ViewModels.CastingAgentProfile;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ICastingAgentProfileService
    {
        Task<CastingAgentProfileViewModel> IndexGetMyProfileAsync(string id);

        Task<UpdateCastingAgentProfileViewModel> GetCastingAgentProfileDataAsync(string id);

        Task<bool> UpdateCastingAgentProfileAsync(UpdateCastingAgentProfileViewModel model);
    }
}
