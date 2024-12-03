using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Casting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using static ActorsCastings.Common.EntityValidationConstants.Casting;

namespace ActorsCastings.Services.Data
{
    public class CastingService : BaseService, ICastingService
    {
        private readonly IRepository<Casting, Guid> _castingRepository;
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<CastingAgent, Guid> _castingAgentRepository;
        private readonly IRepository<ActorCasting, Guid> _actorCastingRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CastingService(
            IRepository<Casting, Guid> repository,
            IRepository<Actor, Guid> actorRepository,
            IRepository<CastingAgent, Guid> castingAgentRepository,
            IRepository<ActorCasting, Guid> actorCastingRepository,
            UserManager<ApplicationUser> userManager)
        {
            _castingRepository = repository;
            _actorRepository = actorRepository;
            _castingAgentRepository = castingAgentRepository;
            _actorCastingRepository = actorCastingRepository;
            _userManager = userManager;
        }
        public async Task<bool> AddCastingAsync(AddCastingViewModel model, string userId)
        {
            Guid guidUserId = Guid.Empty;
            bool isGuidValid = IsGuidValid(userId, ref guidUserId);

            if (!isGuidValid)
            {
                return false;
            }

            bool isDateCorrect = DateTime.TryParseExact
                (model.CastingEnd,
                Common.EntityValidationConstants.Casting.CastingCastingEndDateTimeFormatString,
                CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateTime);

            if (!isDateCorrect)
            {
                return false;
            }

            CastingAgent? current = await _castingAgentRepository
                .FirstOrDefaultAsync(ca => ca.UserId == guidUserId);

            if (current == null)
            {
                return false;
            }

            Casting casting = new Casting()
            {
                Title = model.Title,
                Description = model.Description,
                CastingEnd = dateTime,
                CastingAgentId = current.Id
            };

            await _castingRepository.AddAsync(casting);
            return true;
        }

        public async Task<bool> ApplyForCastingAsync(string id, string userId)
        {
            Guid castingId = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref castingId);

            if (!isGuidValid)
            {
                return false;
            }

            Casting casting = await _castingRepository.GetByIdAsync(castingId);

            if (casting == null)
            {
                return false;
            }

            Guid guidUserId = Guid.Empty;
            bool isUserGuidValid = IsGuidValid(userId, ref guidUserId);

            if (!isUserGuidValid)
            {
                return false;
            }

            //TODO: Fix
            if (await _actorCastingRepository.GetAllAttached().AnyAsync(ac => ac.Actor.UserId == guidUserId && ac.CastingId == castingId))
            {
                return false;
            }

            Actor currentActor = await _actorRepository.FirstOrDefaultAsync(a => a.UserId == guidUserId);

            if (currentActor == null)
            {
                return false;
            }

            ActorCasting actorCasting = new ActorCasting
            {
                ActorId = currentActor.Id,
                CastingId = castingId
            };

            await _actorCastingRepository.AddAsync(actorCasting);
            return true;
        }

        public async Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(string id, string userId)
        {
            Guid castingId = Guid.Empty;
            bool result = IsGuidValid(id, ref castingId);

            //TODO: 
            if (!result)
            {
                throw new Exception();
            }

            Casting? casting = await _castingRepository.GetAllAttached()
                .Include(c => c.CastingAgent)
                .FirstOrDefaultAsync(c => c.Id == castingId);

            //TODO: Error message
            if (casting == null)
            {
                throw new Exception();
            }

            Guid guidUserId = Guid.Empty;
            bool isGuidValid = IsGuidValid(userId, ref guidUserId);

            if (!isGuidValid)
            {
                throw new Exception();
            }



            CastingDetailsViewModel model = new CastingDetailsViewModel
            {
                Id = id.ToString(),
                Title = casting.Title,
                Description = casting.Description,
                CastingEnd = casting.CastingEnd.ToString(CastingCastingEndDateTimeFormatString),
                CastingAgent = casting.CastingAgent.Name,
                CastingAgency = casting.CastingAgent.CastingAgency,
                HasActorApplied = await _actorCastingRepository.GetAllAttached().AnyAsync(ac => ac.Actor.UserId == guidUserId && ac.CastingId == castingId)
            };

            return model;
        }

        public async Task<IEnumerable<CastingViewModel>> IndexGetAllAsync()
        {
            IEnumerable<CastingViewModel> models = await _castingRepository.GetAllAttached()
                .Select(c => new CastingViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    CastingEnd = c.CastingEnd.ToString(Common.EntityValidationConstants.Casting.CastingCastingEndDateTimeFormatString)
                })
                .ToListAsync();

            return models;
        }
    }
}
