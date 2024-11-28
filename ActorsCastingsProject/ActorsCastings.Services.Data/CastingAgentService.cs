using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class CastingAgentService : BaseService, ICastingAgentService
    {
        private readonly IRepository<CastingAgent, Guid> _castingAgentRepository;

        public CastingAgentService(IRepository<CastingAgent, Guid> castingAgentRepository)
        {
            _castingAgentRepository = castingAgentRepository;
        }

        public async Task<bool> IsUserCastingAgentAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            Guid guidId = Guid.Empty;
            bool isGuidValid = IsGuidValid(userId, ref guidId);

            if (!isGuidValid)
            {
                return false;
            }

            bool result = await _castingAgentRepository
                .GetAllAttached()
                .AnyAsync(a => a.UserId == guidId);

            return result;
        }
    }
}
