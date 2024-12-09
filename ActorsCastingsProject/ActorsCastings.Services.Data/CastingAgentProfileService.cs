using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Casting;
using ActorsCastings.Web.ViewModels.CastingAgentProfile;
using Microsoft.EntityFrameworkCore;

using static ActorsCastings.Common.ExceptionMessages;

namespace ActorsCastings.Services.Data
{
    public class CastingAgentProfileService : BaseService, ICastingAgentProfileService
    {
        private readonly IRepository<CastingAgent, Guid> _castingAgentRepository;

        public CastingAgentProfileService(IRepository<CastingAgent, Guid> castingAgentRepository)
        {
            _castingAgentRepository = castingAgentRepository;
        }

        public async Task CompleteCastingAgentProfileAsync(string id, CastingAgentProfileViewModel model)
        {
            Guid guidUserId = Guid.Empty;
            GuidValidation(id, ref guidUserId);

            CastingAgent castingAgentProfile = new CastingAgent()
            {
                Name = model.Name,
                CastingAgency = model.CastingAgency,
                UserId = guidUserId
            };

            await _castingAgentRepository.AddAsync(castingAgentProfile);
        }

        public async Task<UpdateCastingAgentProfileViewModel> GetCastingAgentProfileDataAsync(string id)
        {
            Guid guidId = Guid.Empty;

            GuidValidation(id, ref guidId);

            CastingAgent castingAgent = await _castingAgentRepository.FirstOrDefaultAsync(ca => ca.UserId == guidId);

            if (castingAgent == null)
            {
                throw new Exception(ServerError);
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
                throw new Exception(ServerError);
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

        public async Task UpdateCastingAgentProfileAsync(UpdateCastingAgentProfileViewModel model)
        {
            CastingAgent castingAgent = await _castingAgentRepository
                .FirstOrDefaultAsync(ca => ca.Id == model.Id);

            if (castingAgent == null)
            {
                throw new Exception(ServerError);
            }

            castingAgent.Name = model.Name;
            castingAgent.CastingAgency = model.CastingAgency;

            await _castingAgentRepository.UpdateAsync(castingAgent);
        }
    }
}
