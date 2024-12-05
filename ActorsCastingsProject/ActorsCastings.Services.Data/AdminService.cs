using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IRepository<Casting, Guid> _castingRepository;
        private readonly IRepository<Play, Guid> _playRepository;
        private readonly IRepository<ActorPlay, Guid> _actorPlayRepository;
        private readonly IRepository<ActorMovie, Guid> _actorMovieRepository;

        public AdminService(
            IRepository<Movie, Guid> movieRepository,
            IRepository<Casting, Guid> castingRepository,
            IRepository<Play, Guid> playRepository,
            IRepository<ActorPlay, Guid> actorPlayRepository,
            IRepository<ActorMovie, Guid> actorMovieRepository)
        {
            _movieRepository = movieRepository;
            _castingRepository = castingRepository;
            _playRepository = playRepository;
            _actorPlayRepository = actorPlayRepository;
            _actorMovieRepository = actorMovieRepository;
        }

        public async Task<bool> ApproveElement(ApproveSubmitViewModel model)
        {
            if (model.Id != null)
            {
                Guid guidId = Guid.Empty;
                bool isGuidValid = IsGuidValid(model.Id.ToString(), ref guidId);

                if (!isGuidValid)
                {
                    return false;
                }

                Movie? movie = await _movieRepository.GetByIdAsync(guidId);
                Play? play = await _playRepository.GetByIdAsync(guidId);
                Casting? casting = await _castingRepository.GetByIdAsync(guidId);

                if (movie != null)
                {
                    movie.IsApproved = true;
                    await _movieRepository.UpdateAsync(movie);
                    return true;
                }
                else if (play != null)
                {
                    play.IsApproved = true;
                    await _playRepository.UpdateAsync(play);
                    return true;
                }
                else if (casting != null)
                {
                    casting.IsApproved = true;
                    await _castingRepository.UpdateAsync(casting);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (model.ActorId != null && model.MovieId != null)
            {
                Guid guidActorId = Guid.Empty;
                Guid guidMovieId = Guid.Empty;
                bool isActorGuidValid = IsGuidValid(model.ActorId.ToString(), ref guidActorId);
                bool isMovieGuidValid = IsGuidValid(model.MovieId.ToString(), ref guidMovieId);
                if (!isActorGuidValid || !isMovieGuidValid)
                {
                    return false;
                }

                ActorMovie? actorMovie = await _actorMovieRepository
                    .GetAllAttached()
                    .FirstOrDefaultAsync(am => am.ActorId == guidActorId && am.MovieId == guidMovieId);

                if (actorMovie == null)
                {
                    return false;
                }

                actorMovie.IsApproved = true;
                await _actorMovieRepository.UpdateAsync(actorMovie);

                return true;
            }
            else if (model.ActorId != null && model.PlayId != null)
            {
                Guid guidActorId = Guid.Empty;
                Guid guidPlayId = Guid.Empty;
                bool isActorGuidValid = IsGuidValid(model.ActorId.ToString(), ref guidActorId);
                bool isPlayGuidValid = IsGuidValid(model.PlayId.ToString(), ref guidPlayId);
                if (!isActorGuidValid || !isPlayGuidValid)
                {
                    return false;
                }

                ActorPlay? actorPlay = await _actorPlayRepository
                    .GetAllAttached()
                    .FirstOrDefaultAsync(ap => ap.ActorId == guidActorId && ap.PlayId == guidPlayId);

                if (actorPlay == null)
                {
                    return false;
                }

                actorPlay.IsApproved = true;
                await _actorPlayRepository.UpdateAsync(actorPlay);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<DataToApproveViewModel> GetAllNotApprovedElements()
        {
            DataToApproveViewModel viewModel = new DataToApproveViewModel
            {
                Movies = await _movieRepository
                    .GetAllAttached()
                    .Where(m => m.IsApproved == false)
                    .Select(m => new MovieToApproveViewModel
                    {
                        Id = m.Id.ToString(),
                        Title = m.Title,
                        Genre = m.Genre,
                        Description = m.Description,
                        ImageUrl = m.ImageUrl,
                        ReleaseYear = m.ReleaseYear
                    })
                    .ToListAsync(),
                Plays = await _playRepository
                    .GetAllAttached()
                    .Where(p => p.IsApproved == false)
                    .Select(p => new PlayToApproveViewModel
                    {
                        Id = p.Id.ToString(),
                        Title = p.Title,
                        Theatre = p.Theatre,
                        Description = p.Description,
                        ImageUrl = p.ImageUrl,
                        ReleaseYear = p.ReleaseYear
                    })
                    .ToListAsync(),
                Castings = await _castingRepository
                    .GetAllAttached()
                    .Where(c => c.IsApproved == false)
                    .Select(c => new CastingToApproveViewModel
                    {
                        Id = c.Id.ToString(),
                        Title = c.Title,
                        Description = c.Description,
                        CastingAgentName = c.CastingAgent.Name
                    })
                    .ToListAsync(),
                RolesInMovies = await _actorMovieRepository
                    .GetAllAttached()
                    .Where(am => am.IsApproved == false)
                    .Select(am => new RoleInMovieToApproveViewModel
                    {
                        ActorId = am.ActorId.ToString(),
                        ActorName = $"{am.Actor.FirstName} {am.Actor.LastName}",
                        MovieId = am.MovieId.ToString(),
                        MovieTitle = am.Movie.Title,
                        Role = am.Role
                    })
                    .ToListAsync(),
                RolesInPlays = await _actorPlayRepository
                    .GetAllAttached()
                    .Where(ap => ap.IsApproved == false)
                    .Select(ap => new RoleInPlayToApproveViewModel
                    {
                        ActorId = ap.ActorId.ToString(),
                        ActorName = $"{ap.Actor.FirstName} {ap.Actor.LastName}",
                        PlayId = ap.PlayId.ToString(),
                        PlayTitle = ap.Play.Title,
                        Role = ap.Role
                    })
                    .ToListAsync()
            };

            return viewModel;
        }
    }
}
