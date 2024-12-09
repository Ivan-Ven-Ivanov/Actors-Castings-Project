using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.EntityFrameworkCore;

using static ActorsCastings.Common.ExceptionMessages;

namespace ActorsCastings.Services.Data
{
    public class PlayService : BaseService, IPlayService
    {
        private readonly IRepository<Play, Guid> _playRepository;
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<ActorPlay, Guid> _actorPlayRepository;

        public PlayService(
            IRepository<Play, Guid> playRepository,
            IRepository<Actor, Guid> actorRepository,
            IRepository<ActorPlay, Guid> actorPlayRepository)
        {
            _playRepository = playRepository;
            _actorRepository = actorRepository;
            _actorPlayRepository = actorPlayRepository;
        }

        public async Task AddPlayAndRoleInItAsync(AddPlayViewModel model, string userId)
        {
            Guid guidUserId = Guid.Empty;
            GuidValidation(userId, ref guidUserId);

            Play play = new Play
            {
                Title = model.Title,
                Theatre = model.Theatre,
                Description = model.Description,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                ReleaseYear = model.ReleaseYear,
                IsApproved = false
            };

            Actor currentActor = await _actorRepository
                .FirstOrDefaultAsync(a => a.UserId == guidUserId);

            if (currentActor == null)
            {
                throw new Exception(ServerError);
            }

            ActorPlay actorPlay = new ActorPlay
            {
                ActorId = currentActor.Id,
                PlayId = play.Id,
                Role = model.Role,
                IsApproved = false
            };

            await _playRepository.AddAsync(play);
            await _actorPlayRepository.AddAsync(actorPlay);
        }

        public async Task<PlayDetailsViewModel> GetPlayDetailsAsync(string id)
        {
            Guid guidId = Guid.Empty;
            GuidValidation(id, ref guidId);

            Play? play = await _playRepository.GetAllAttached()
                .Include(p => p.ActorsPlays)
                    .ThenInclude(ap => ap.Actor)
                .FirstOrDefaultAsync(p => p.Id == guidId);

            if (play == null)
            {
                throw new KeyNotFoundException(string.Format(EntityNotFoundById, nameof(Play), id));
            }

            play.ActorsPlays = play.ActorsPlays.Where(ap => ap.IsApproved == true).ToList();

            PlayDetailsViewModel model = new PlayDetailsViewModel
            {
                Id = play.Id.ToString(),
                Title = play.Title,
                Description = play.Description,
                Director = play.Director,
                Theatre = play.Theatre,
                ImageUrl = play.ImageUrl,
                ReleaseYear = play.ReleaseYear.ToString(),
                Actors = play.ActorsPlays
                .Select(ap => new ActorInPlayViewModel
                {
                    Id = ap.Actor.Id.ToString(),
                    FirstName = ap.Actor.FirstName,
                    LastName = ap.Actor.LastName,
                    ProfilePictureUrl = ap.Actor.ProfilePictureUrl,
                    Role = ap.Role
                }).ToList()
            };

            return model;
        }

        public async Task<int> GetPlaysCountAsync()
        {
            return await _playRepository.GetAllAttached().CountAsync();
        }

        public async Task<IList<PlayViewModel>> IndexGetPaginatedPlaysAsync(int page, int pageSize)
        {
            PagesValidation(page, pageSize);

            List<PlayViewModel> models = await _playRepository
                .GetAllAttached()
                .OrderBy(p => p.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Where(m => !m.IsDeleted && m.IsApproved)
                .Select(m => new PlayViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    ReleaseYear = m.ReleaseYear.ToString()
                })
                .ToListAsync();

            if (!models.Any())
            {
                throw new Exception(ServerError);
            }

            return models;
        }
    }
}
