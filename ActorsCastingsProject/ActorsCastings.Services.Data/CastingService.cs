using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Casting;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using static ActorsCastings.Common.EntityValidationConstants.Casting;
using static ActorsCastings.Common.ExceptionMessages;


namespace ActorsCastings.Services.Data
{
    public class CastingService : BaseService, ICastingService
    {
        private readonly IRepository<Casting, Guid> _castingRepository;
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<CastingAgent, Guid> _castingAgentRepository;
        private readonly IRepository<ActorCasting, Guid> _actorCastingRepository;
        public CastingService(
            IRepository<Casting, Guid> repository,
            IRepository<Actor, Guid> actorRepository,
            IRepository<CastingAgent, Guid> castingAgentRepository,
            IRepository<ActorCasting, Guid> actorCastingRepository)
        {
            _castingRepository = repository;
            _actorRepository = actorRepository;
            _castingAgentRepository = castingAgentRepository;
            _actorCastingRepository = actorCastingRepository;
        }
        public async Task AddCastingAsync(AddCastingViewModel model, string userId)
        {
            Guid guidUserId = Guid.Empty;
            GuidValidation(userId, ref guidUserId);

            bool isDateCorrect = DateTime.TryParseExact
                (model.CastingEnd,
                Common.EntityValidationConstants.Casting.CastingEndDateTimeFormatString,
                CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateTime);

            if (!isDateCorrect)
            {
                throw new ArgumentException(InvalidDateFormat);
            }

            CastingAgent? current = await _castingAgentRepository
                .FirstOrDefaultAsync(ca => ca.UserId == guidUserId);

            if (current == null)
            {
                throw new Exception(ServerError);
            }

            Casting casting = new Casting()
            {
                Title = model.Title,
                Description = model.Description,
                CastingEnd = dateTime,
                CastingAgentId = current.Id
            };

            await _castingRepository.AddAsync(casting);
        }

        public async Task ApplyForCastingAsync(string id, string userId)
        {
            Guid castingId = Guid.Empty;
            GuidValidation(id, ref castingId);

            Casting casting = await _castingRepository.GetByIdAsync(castingId);

            if (casting == null)
            {
                throw new KeyNotFoundException(string.Format(EntityNotFoundById, nameof(Casting), id));
            }

            Guid guidUserId = Guid.Empty;
            GuidValidation(userId, ref guidUserId);

            if (!await _actorCastingRepository.GetAllAttached().AnyAsync(ac => ac.Actor.UserId == guidUserId && ac.CastingId == castingId))
            {
                Actor currentActor = await _actorRepository.FirstOrDefaultAsync(a => a.UserId == guidUserId);

                if (currentActor == null)
                {
                    throw new Exception(ServerError);
                }

                ActorCasting actorCasting = new ActorCasting
                {
                    ActorId = currentActor.Id,
                    CastingId = castingId
                };

                await _actorCastingRepository.AddAsync(actorCasting);
            }
        }

        public async Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(string id, string userId)
        {
            Guid castingId = Guid.Empty;
            GuidValidation(id, ref castingId);

            Casting? casting = await _castingRepository.GetAllAttached()
                .Include(c => c.CastingAgent)
                .Include(c => c.ActorsCastings)
                    .ThenInclude(ac => ac.Actor)
                .FirstOrDefaultAsync(c => c.Id == castingId);

            if (casting == null)
            {
                throw new KeyNotFoundException(string.Format(EntityNotFoundById, nameof(Casting), id));
            }

            Guid guidUserId = Guid.Empty;
            GuidValidation(userId, ref guidUserId);

            List<ActorInCastingViewModel> castedActors = casting.ActorsCastings.
                Select(ac => new ActorInCastingViewModel
                {
                    Id = ac.Actor.Id.ToString(),
                    FirstName = ac.Actor.FirstName,
                    LastName = ac.Actor.LastName,
                    ProfilePictureUrl = ac.Actor.ProfilePictureUrl
                }).ToList();

            CastingDetailsViewModel model = new CastingDetailsViewModel
            {
                Id = id,
                Title = casting.Title,
                Description = casting.Description,
                CastingEnd = casting.CastingEnd.ToString(CastingEndDateTimeFormatString),
                CastingAgent = casting.CastingAgent.Name,
                CastingAgency = casting.CastingAgent.CastingAgency,
                CastedActors = castedActors,
                HasActorApplied = await _actorCastingRepository.GetAllAttached().AnyAsync(ac => ac.Actor.UserId == guidUserId && ac.CastingId == castingId)
            };

            return model;
        }

        public async Task<int> GetCastingsCountAsync()
        {
            return await _castingRepository.GetAllAttached().CountAsync();
        }

        public async Task<IList<CastingViewModel>> IndexGetPaginatedCastingsAsync(int page, int pageSize)
        {
            PagesValidation(page, pageSize);

            List<CastingViewModel> models = await _castingRepository
                .GetAllAttached()
                .Include(c => c.ActorsCastings)
                .Where(c => c.IsApproved)
                .OrderByDescending(c => c.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CastingViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    ActorsApplied = c.ActorsCastings.Count,
                    CastingEnd = c.CastingEnd.ToString(CastingEndDateTimeFormatString)
                })
                .ToListAsync();

            return models;
        }
    }
}
