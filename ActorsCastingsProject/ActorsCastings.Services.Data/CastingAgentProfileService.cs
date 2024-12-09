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

        public async Task<bool> CompleteCastingAgentProfileAsync(string id, CastingAgentProfileViewModel model)
        {
            Guid guidUserId = Guid.Empty;
            GuidValidation(id, ref guidUserId);

            CastingAgent castingAgentProfile = new CastingAgent()
            {
                Name = model.Name,
                CastingAgency = model.CastingAgency,
                UserId = guidUserId
            };

            if (castingAgentProfile == null)
            {
                return false;
            }

            await _castingAgentRepository.AddAsync(castingAgentProfile);

            return true;
        }

        public async Task<UpdateCastingAgentProfileViewModel> GetCastingAgentProfileDataAsync(string id)
        {
            Guid guidId = Guid.Empty;

            GuidValidation(id, ref guidId);

            CastingAgent castingAgent = await _castingAgentRepository.FirstOrDefaultAsync(ca => ca.UserId == guidId);

            if (castingAgent == null)
            {
                throw new Exception();
            }

            UpdateCastingAgentProfileViewModel model = new UpdateCastingAgentProfileViewModel
            {
                Id = castingAgent.Id,
                Name = castingAgent.Name,
                CastingAgency = castingAgent.CastingAgency
            };

            return model;
        }

        public async Task<CastingAgentProfileViewModel> IndexGetMyProfileAsync(string id)
        {
            Guid guidId = Guid.Empty;

            GuidValidation(id, ref guidId);

            CastingAgent? castingAgent = await _castingAgentRepository
                .GetAllAttached()
                .Include(ca => ca.Castings)
                    .ThenInclude(c => c.ActorsCastings)
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
                    CastingEnd = c.CastingEnd.ToString(),
                    ActorsApplied = c.ActorsCastings.Count
                }).ToList()
            };

            return model;
        }

        public async Task<bool> UpdateCastingAgentProfileAsync(UpdateCastingAgentProfileViewModel model)
        {
            CastingAgent castingAgent = await _castingAgentRepository
                .FirstOrDefaultAsync(ca => ca.Id == model.Id);

            if (castingAgent == null)
            {
                return false;
            }

            castingAgent.Name = model.Name;
            castingAgent.CastingAgency = model.CastingAgency;

            return await _castingAgentRepository.UpdateAsync(castingAgent);
        }
    }
}
