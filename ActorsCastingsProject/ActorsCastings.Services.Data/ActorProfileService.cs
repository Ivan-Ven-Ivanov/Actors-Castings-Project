using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class ActorProfileService : BaseService, IActorProfileService
    {
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IRepository<ActorMovie, Guid> _actorMovieRepository;

        public ActorProfileService(
            IRepository<Actor, Guid> actorRepository,
            IRepository<Movie, Guid> movieRepository,
            IRepository<ActorMovie, Guid> actorMovieRepository)
        {
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
            _actorMovieRepository = actorMovieRepository;
        }

        public async Task<bool> AddSelectedMovieToProfileAsync(Guid id, string role, string userId)
        {
            Movie? movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null)
            {
                return false;
            }

            Guid guidUserId = Guid.Empty;
            bool isGuidValid = IsGuidValid(userId, ref guidUserId);

            if (!isGuidValid)
            {
                return false;
            }

            Actor? actor = await _actorRepository
                .FirstOrDefaultAsync(a => a.UserId == guidUserId);

            if (actor == null)
            {
                return false;
            }

            ActorMovie actorMovie = new ActorMovie
            {
                ActorId = actor.Id,
                MovieId = movie.Id,
                Role = role,
                IsApproved = false,
            };

            await _actorMovieRepository.AddAsync(actorMovie);

            return true;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync()
        {
            IEnumerable<MovieViewModel> models = await _movieRepository
                .GetAllAttached()
                .Where(m => m.IsApproved && !m.IsDeleted)
                .Select(m => new MovieViewModel
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

        public async Task<ActorProfileViewModel> IndexGetMyProfileAsync(string id)
        {
            Guid guidId = Guid.Empty;

            bool isGuidValid = IsGuidValid(id, ref guidId);

            Actor? actor = await _actorRepository
                .GetAllAttached()
                .Include(a => a.ActorsMovies)
                    .ThenInclude(am => am.Movie)
                .Include(a => a.ActorsPlays)
                    .ThenInclude(ap => ap.Play)
                .FirstOrDefaultAsync(a => a.UserId == guidId);

            if (actor == null)
            {
                throw new Exception("Actor not found.");
            }

            ActorProfileViewModel model = new ActorProfileViewModel
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                Age = actor.Age,
                Biography = actor.Biography,
                Movies = actor.ActorsMovies
                    .Select(am => new MovieViewModel
                    {
                        Id = am.MovieId.ToString(),
                        Title = am.Movie.Title,
                        ImageUrl = am.Movie.ImageUrl,
                        Director = am.Movie.Director,
                        ReleaseYear = am.Movie.ReleaseYear.ToString(),
                        IsRoleInMovieApproved = am.IsApproved
                    }).ToList(),
                Plays = actor.ActorsPlays
                    .Select(ap => new PlayViewModel
                    {
                        Id = ap.PlayId.ToString(),
                        Title = ap.Play.Title,
                        ImageUrl = ap.Play.ImageUrl,
                        Director = ap.Play.Director,
                        ReleaseYear = ap.Play.ReleaseYear.ToString(),
                        IsRoleInPlayApproved = ap.IsApproved
                    }).ToList()
            };

            return model;
        }
    }
}
