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
        private readonly IRepository<Play, Guid> _playRepository;
        private readonly IRepository<ActorPlay, Guid> _actorPlayRepository;

        public ActorProfileService(
            IRepository<Actor, Guid> actorRepository,
            IRepository<Movie, Guid> movieRepository,
            IRepository<ActorMovie, Guid> actorMovieRepository,
            IRepository<Play, Guid> playRepository,
            IRepository<ActorPlay, Guid> actorPlayRepository)
        {
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
            _actorMovieRepository = actorMovieRepository;
            _playRepository = playRepository;
            _actorPlayRepository = actorPlayRepository;
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

        public async Task<bool> AddSelectedPlayToProfileAsync(Guid id, string role, string userId)
        {
            Play? play = await _playRepository.GetByIdAsync(id);

            if (play == null)
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

            ActorPlay actorPlay = new ActorPlay
            {
                ActorId = actor.Id,
                PlayId = play.Id,
                Role = role,
                IsApproved = false,
            };

            await _actorPlayRepository.AddAsync(actorPlay);

            return true;
        }

        public async Task<bool> CompleteActorProfileAsync(string id, ActorProfileViewModel model)
        {
            Guid guidUserId = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref guidUserId);

            if (!isGuidValid)
            {
                return false;
            }


            Actor actorProfile = new Actor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                ProfilePictureUrl = model.ProfilePictureUrl,
                Biography = model.Biography,
                UserId = guidUserId
            };

            if (actorProfile == null)
            {
                return false;
            }

            await _actorRepository.AddAsync(actorProfile);

            return true;
        }

        public async Task<UpdateActorProfileViewModel> GetActorProfileDataAsync(string id)
        {
            Guid guidId = Guid.Empty;

            bool isGuidValid = IsGuidValid(id, ref guidId);

            if (!isGuidValid)
            {
                throw new Exception();
            }

            Actor actor = await _actorRepository.FirstOrDefaultAsync(a => a.UserId == guidId);

            if (actor == null)
            {
                throw new Exception();
            }

            UpdateActorProfileViewModel model = new UpdateActorProfileViewModel
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Age = actor.Age,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                Biography = actor.Biography
            };

            return model;
        }

        public async Task<SelectedMovieViewModel> GetAllMoviesForSelectAsync(SelectedMovieViewModel model)
        {
            model.Movies = await _movieRepository
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

            return model;
        }

        public async Task<IEnumerable<PlayViewModel>> GetAllPlaysAsync()
        {
            IEnumerable<PlayViewModel> models = await _playRepository
                .GetAllAttached()
                .Where(p => p.IsApproved && !p.IsDeleted)
                .Select(p => new PlayViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Director = p.Director,
                    ImageUrl = p.ImageUrl,
                    ReleaseYear = p.ReleaseYear.ToString()
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

        public SelectedMovieViewModel SelectAMovieForValidation(SelectedMovieViewModel model)
        {
            foreach (var movie in model.Movies)
            {
                if (movie.Id == model.Id)
                {
                    movie.IsSelected = true;
                }
            }

            return model;
        }

        public async Task<bool> UpdateActorProfileAsync(UpdateActorProfileViewModel model)
        {
            Actor actor = await _actorRepository
                .FirstOrDefaultAsync(a => a.Id == model.Id);

            if (actor == null)
            {
                return false;
            }

            actor.FirstName = model.FirstName;
            actor.LastName = model.LastName;
            actor.Age = model.Age;
            actor.ProfilePictureUrl = model.ProfilePictureUrl;
            actor.Biography = model.Biography;

            return await _actorRepository.UpdateAsync(actor);
        }
    }
}
