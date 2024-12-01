using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class PlayService : IPlayService
    {
        private readonly IRepository<Play, Guid> _playRepository;

        public PlayService(IRepository<Play, Guid> playRepository)
        {
            _playRepository = playRepository;
        }
        public Task<PlayDetailsViewModel> GetPlayDetailsAsync(string id)
        {
            throw new NotImplementedException();
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
