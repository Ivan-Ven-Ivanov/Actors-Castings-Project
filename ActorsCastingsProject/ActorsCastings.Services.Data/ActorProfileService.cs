using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Casting;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static ActorsCastings.Common.EntityValidationConstants.Casting;
using static ActorsCastings.Common.ExceptionMessages;

namespace ActorsCastings.Services.Data
{
    public class ActorProfileService : BaseService, IActorProfileService
    {
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IRepository<ActorMovie, Guid> _actorMovieRepository;
        private readonly IRepository<Play, Guid> _playRepository;
        private readonly IRepository<ActorPlay, Guid> _actorPlayRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActorProfileService(
            IRepository<Actor, Guid> actorRepository,
            IRepository<Movie, Guid> movieRepository,
            IRepository<ActorMovie, Guid> actorMovieRepository,
            IRepository<Play, Guid> playRepository,
            IRepository<ActorPlay, Guid> actorPlayRepository,
            UserManager<ApplicationUser> userManager)
        {
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
            _actorMovieRepository = actorMovieRepository;
            _playRepository = playRepository;
            _actorPlayRepository = actorPlayRepository;
            _userManager = userManager;
        }

        public async Task AddSelectedMovieToProfileAsync(string id, string role, string userId)
        {
            Guid guidMovieId = Guid.Empty;
            GuidValidation(id, ref guidMovieId);

            Movie? movie = await _movieRepository.GetByIdAsync(guidMovieId);

            if (movie == null)
            {
                throw new KeyNotFoundException(string.Format(EntityNotFoundById, nameof(Movie), id));
            }

            Guid guidUserId = Guid.Empty;
            GuidValidation(userId, ref guidUserId);

            Actor? actor = await _actorRepository
                .FirstOrDefaultAsync(a => a.UserId == guidUserId);

            if (actor == null)
            {
                throw new Exception(ServerError);
            }

            ActorMovie actorMovie = new ActorMovie
            {
                ActorId = actor.Id,
                MovieId = movie.Id,
                Role = role,
                IsApproved = false,
            };

            await _actorMovieRepository.AddAsync(actorMovie);
        }

        public async Task AddSelectedPlayToProfileAsync(string id, string role, string userId)
        {
            Guid guidPlayId = Guid.Empty;
            GuidValidation(id, ref guidPlayId);

            Play? play = await _playRepository.GetByIdAsync(guidPlayId);

            if (play == null)
            {
                throw new KeyNotFoundException(string.Format(EntityNotFoundById, nameof(Play), id));
            }

            Guid guidUserId = Guid.Empty;
            GuidValidation(userId, ref guidUserId);

            Actor? actor = await _actorRepository
                .FirstOrDefaultAsync(a => a.UserId == guidUserId);

            if (actor == null)
            {
                throw new Exception(ServerError);
            }

            ActorPlay actorPlay = new ActorPlay
            {
                ActorId = actor.Id,
                PlayId = play.Id,
                Role = role,
                IsApproved = false,
            };

            await _actorPlayRepository.AddAsync(actorPlay);
        }

        public async Task CompleteActorProfileAsync(string id, ActorProfileViewModel model)
        {
            Guid guidUserId = Guid.Empty;
            GuidValidation(id, ref guidUserId);

            Actor actorProfile = new Actor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                ProfilePictureUrl = model.ProfilePictureUrl,
                Biography = model.Biography,
                UserId = guidUserId
            };

            ApplicationUser? user = await _userManager.FindByIdAsync(id);
            user.PhoneNumber = model.PhoneNumber;

            await _actorRepository.AddAsync(actorProfile);
        }

        public async Task<UpdateActorProfileViewModel> GetActorProfileDataForUpdateAsync(string id)
        {
            Guid guidId = Guid.Empty;

            GuidValidation(id, ref guidId);

            Actor actor = await _actorRepository.FirstOrDefaultAsync(a => a.UserId == guidId);

            if (actor == null)
            {
                throw new Exception(ServerError);
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

        public async Task<SelectedPlayViewModel> GetAllPlaysForSelectAsync(SelectedPlayViewModel model)
        {
            model.Plays = await _playRepository
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

            return model;
        }

        public async Task<ActorProfileViewModel> IndexGetMyProfileAsync(string id)
        {
            Guid guidId = Guid.Empty;

            GuidValidation(id, ref guidId);

            Actor? actor = await _actorRepository
                .GetAllAttached()
                .Include(a => a.ActorsMovies)
                    .ThenInclude(am => am.Movie)
                .Include(a => a.ActorsPlays)
                    .ThenInclude(ap => ap.Play)
                .Include(a => a.ActorsCastings)
                    .ThenInclude(ac => ac.Casting)
                .FirstOrDefaultAsync(a => a.UserId == guidId);

            if (actor == null)
            {
                throw new Exception(ServerError);
            }

            ActorProfileViewModel model = new ActorProfileViewModel
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                Age = actor.Age,
                PhoneNumber = actor.PhoneNumber,
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
                    }).ToList(),
                Castings = actor.ActorsCastings
                    .Select(ac => new CastingViewModel
                    {
                        Id = ac.CastingId.ToString(),
                        Title = ac.Casting.Title,
                        CastingEnd = ac.Casting.CastingEnd.ToString(CastingEndDateTimeFormatString)
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

        public SelectedPlayViewModel SelectAPlayForValidation(SelectedPlayViewModel model)
        {
            foreach (var play in model.Plays)
            {
                if (play.Id == model.Id)
                {
                    play.IsSelected = true;
                }
            }

            return model;
        }

        public async Task UpdateActorProfileAsync(UpdateActorProfileViewModel model)
        {
            Actor actor = await _actorRepository
                .FirstOrDefaultAsync(a => a.Id == model.Id);

            if (actor == null)
            {
                throw new Exception(ServerError);
            }

            actor.FirstName = model.FirstName;
            actor.LastName = model.LastName;
            actor.Age = model.Age;
            actor.ProfilePictureUrl = model.ProfilePictureUrl;
            actor.Biography = model.Biography;

            await _actorRepository.UpdateAsync(actor);
        }
    }
}
