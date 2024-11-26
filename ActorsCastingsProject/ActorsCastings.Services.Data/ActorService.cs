using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class ActorService : BaseService, IActorService
    {
        private readonly IRepository<Actor, Guid> _actorRepository;

        public ActorService(IRepository<Actor, Guid> actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<bool> IsUserActorAsync(string userId)
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

            bool result = await _actorRepository
                .GetAllAttached()
                .AnyAsync(a => a.Id == guidId);

            return result;
        }
    }
}
