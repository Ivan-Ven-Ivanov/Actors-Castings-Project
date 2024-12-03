using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Casting;
using ActorsCastings.Web.ViewModels.CastingAgentProfile;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class CastingAgentProfileService : BaseService, ICastingAgentProfileService
    {
        private readonly IRepository<CastingAgent, Guid> _castingAgentRepository;

        public CastingAgentProfileService(IRepository<CastingAgent, Guid> castingAgentRepository)
        {
            _castingAgentRepository = castingAgentRepository;
        }
        public async Task<CastingAgentProfileViewModel> IndexGetMyProfileAsync(string id)
        {
            Guid guidId = Guid.Empty;

            bool isGuidValid = IsGuidValid(id, ref guidId);

            CastingAgent? castingAgent = await _castingAgentRepository
                .GetAllAttached()
                .Include(ca => ca.Castings)
                .FirstOrDefaultAsync(ca => ca.UserId == guidId);

            if (castingAgent == null)
            {
                throw new Exception("Casting agent not found.");
            }

            CastingAgentProfileViewModel model = new CastingAgentProfileViewModel
            {
                Name = castingAgent.Name,
                CastingAgency = castingAgent.CastingAgency,
                Castings = castingAgent.Castings
                .Select(c => new CastingViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    CastingEnd = c.CastingEnd.ToString()
                }).ToList()
            };

            return model;
        }
    }
}
