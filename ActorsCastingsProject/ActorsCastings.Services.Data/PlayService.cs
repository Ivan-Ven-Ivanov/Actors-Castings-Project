using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class PlayService : BaseService, IPlayService
    {
        private readonly IRepository<Play, Guid> _playRepository;

        public PlayService(IRepository<Play, Guid> playRepository)
        {
            _playRepository = playRepository;
        }
        public async Task<PlayDetailsViewModel> GetPlayDetailsAsync(string id)
        {
            Guid guidId = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref guidId);

            if (!isGuidValid)
            {
                throw new Exception();
            }

            Play? play = await _playRepository.GetAllAttached()
                .Include(p => p.ActorsPlays)
                    .ThenInclude(ap => ap.Actor)
                .FirstOrDefaultAsync(p => p.Id == guidId);

            if (play == null)
            {
                throw new Exception();
            }

            PlayDetailsViewModel model = new PlayDetailsViewModel
            {
                Id = play.Id.ToString(),
                Title = play.Title,
                Description = play.Description,
                Director = play.Director,
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

        public async Task<IEnumerable<PlayViewModel>> IndexGetAllPlaysAsync()
        {
            List<PlayViewModel> models = await _playRepository.GetAllAttached()
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

            return models;
        }
    }
}
