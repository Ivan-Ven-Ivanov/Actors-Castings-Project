using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Casting;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class SearchService : ISearchService
    {
        private IRepository<Movie, Guid> _movieRepository;
        private IRepository<Play, Guid> _playRepository;
        private IRepository<Casting, Guid> _castingRepository;
        private IRepository<Actor, Guid> _actorRepository;

        public SearchService(
            IRepository<Movie, Guid> movieRepository,
            IRepository<Play, Guid> playRepository,
            IRepository<Casting, Guid> castingRepository,
            IRepository<Actor, Guid> actorRepository)
        {
            _movieRepository = movieRepository;
            _playRepository = playRepository;
            _castingRepository = castingRepository;
            _actorRepository = actorRepository;
        }

        public async Task<SearchViewModel> GetSearchResultsByQueryAsync(string query)
        {
            query = query.Trim().ToLower();

            SearchViewModel model = new SearchViewModel
            {
                Movies = await _movieRepository
                    .GetAllAttached()
                    .Where(m => m.IsApproved && !m.IsDeleted &&
                        (m.Title.ToLower().Contains(query) || m.Description.ToLower().Contains(query) ||
                            m.Director.ToLower().Contains(query) || m.Genre.ToLower().Contains(query) ||
                            m.ReleaseYear.ToString().Contains(query)))
                    .Select(m => new MovieSearchViewModel
                    {
                        Id = m.Id.ToString(),
                        Title = m.Title,
                        Description = m.Description,
                        Director = m.Director,
                        Genre = m.Genre,
                        ReleaseYear = m.ReleaseYear.ToString()
                    })
                    .ToListAsync(),
                Plays = await _playRepository
                    .GetAllAttached()
                    .Where(p => p.IsApproved && !p.IsDeleted &&
                        (p.Title.ToLower().Contains(query) || p.Description.ToLower().Contains(query) ||
                            p.Director.ToLower().Contains(query) || p.Theatre.ToLower().Contains(query) ||
                            p.ReleaseYear.ToString().Contains(query)))
                    .Select(p => new PlaySearchViewModel
                    {
                        Id = p.Id.ToString(),
                        Title = p.Title,
                        Description = p.Description,
                        Director = p.Director,
                        Theatre = p.Theatre,
                        ReleaseYear = p.ReleaseYear.ToString()
                    })
                    .ToListAsync(),
                Castings = await _castingRepository
                    .GetAllAttached()
                    .Include(c => c.CastingAgent)
                    .Where(c => c.IsApproved && !c.IsDeleted &&
                        (c.Title.ToLower().Contains(query) || c.Description.ToLower().Contains(query) ||
                            c.CastingAgent.Name.ToLower().Contains(query) || c.CastingAgent.CastingAgency.ToLower().Contains(query)))
                    .Select(c => new CastingSearchViewModel
                    {
                        Id = c.Id.ToString(),
                        Title = c.Title,
                        Description = c.Description,
                        CastingAgentName = c.CastingAgent.Name,
                        CastingAgency = c.CastingAgent.CastingAgency
                    })
                    .ToListAsync(),
                Actors = await _actorRepository
                    .GetAllAttached()
                    .Where(a => !a.IsDeleted &&
                        (a.FirstName.ToLower().Contains(query) || a.LastName.ToLower().Contains(query) ||
                            a.Age.ToString().Contains(query) || a.Biography.ToLower().Contains(query)))
                    .Select(a => new ActorSearchViewModel
                    {
                        Id = a.Id.ToString(),
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Age = a.Age.ToString(),
                        Biography = a.Biography
                    })
                    .ToListAsync()
            };

            return model;
        }
    }
}
