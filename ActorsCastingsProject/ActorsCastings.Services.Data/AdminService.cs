using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static ActorsCastings.Common.ApplicationConstants;
using static ActorsCastings.Common.EntityValidationConstants.Casting;
using static ActorsCastings.Common.ExceptionMessages;

namespace ActorsCastings.Services.Data
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IRepository<Casting, Guid> _castingRepository;
        private readonly IRepository<Play, Guid> _playRepository;
        private readonly IRepository<ActorPlay, Guid> _actorPlayRepository;
        private readonly IRepository<ActorMovie, Guid> _actorMovieRepository;
        private readonly IRepository<ActorCasting, Guid> _actorCastingRepository;
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<CastingAgent, Guid> _castingAgentRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(
            IRepository<Movie, Guid> movieRepository,
            IRepository<Casting, Guid> castingRepository,
            IRepository<Play, Guid> playRepository,
            IRepository<ActorPlay, Guid> actorPlayRepository,
            IRepository<ActorMovie, Guid> actorMovieRepository,
            IRepository<ActorCasting, Guid> actorCastingRepository,
            IRepository<Actor, Guid> actorRepository,
            IRepository<CastingAgent, Guid> castingAgentRepository,
            UserManager<ApplicationUser> userManager)
        {
            _movieRepository = movieRepository;
            _castingRepository = castingRepository;
            _playRepository = playRepository;
            _actorPlayRepository = actorPlayRepository;
            _actorMovieRepository = actorMovieRepository;
            _actorCastingRepository = actorCastingRepository;
            _actorRepository = actorRepository;
            _castingAgentRepository = castingAgentRepository;
            _userManager = userManager;
        }

        public async Task ApproveElement(ApproveSubmitViewModel model)
        {
            if (model.Id != null)
            {
                Guid guidId = Guid.Empty;
                GuidValidation(model.Id.ToString(), ref guidId);

                Movie? movie = await _movieRepository.GetByIdAsync(guidId);
                Play? play = await _playRepository.GetByIdAsync(guidId);
                Casting? casting = await _castingRepository.GetByIdAsync(guidId);

                if (movie != null)
                {
                    movie.IsApproved = true;
                    if (!await _movieRepository.UpdateAsync(movie))
                    {
                        throw new Exception(ServerError);
                    }
                }
                else if (play != null)
                {
                    play.IsApproved = true;
                    if (!await _playRepository.UpdateAsync(play))
                    {
                        throw new Exception(ServerError);
                    }
                }
                else if (casting != null)
                {
                    casting.IsApproved = true;
                    if (!await _castingRepository.UpdateAsync(casting))
                    {
                        throw new Exception(ServerError);
                    }
                }
                else
                {
                    throw new Exception(ServerError);
                }
            }
            else if (model.ActorId != null && model.MovieId != null)
            {
                Guid guidActorId = Guid.Empty;
                Guid guidMovieId = Guid.Empty;
                GuidValidation(model.ActorId.ToString(), ref guidActorId);
                GuidValidation(model.MovieId.ToString(), ref guidMovieId);

                ActorMovie? actorMovie = await _actorMovieRepository
                    .GetAllAttached()
                    .FirstOrDefaultAsync(am => am.ActorId == guidActorId && am.MovieId == guidMovieId);

                if (actorMovie == null)
                {
                    throw new Exception(ServerError);
                }

                actorMovie.IsApproved = true;
                if (!await _actorMovieRepository.UpdateAsync(actorMovie))
                {
                    throw new Exception(ServerError);
                }
            }
            else if (model.ActorId != null && model.PlayId != null)
            {
                Guid guidActorId = Guid.Empty;
                Guid guidPlayId = Guid.Empty;
                GuidValidation(model.ActorId.ToString(), ref guidActorId);
                GuidValidation(model.PlayId.ToString(), ref guidPlayId);

                ActorPlay? actorPlay = await _actorPlayRepository
                    .GetAllAttached()
                    .FirstOrDefaultAsync(ap => ap.ActorId == guidActorId && ap.PlayId == guidPlayId);

                if (actorPlay == null)
                {
                    throw new Exception(ServerError);
                }

                actorPlay.IsApproved = true;
                if (!await _actorPlayRepository.UpdateAsync(actorPlay))
                {
                    throw new Exception(ServerError);
                }
            }
            else
            {
                throw new Exception(ServerError);
            }
        }

        public async Task DeleteCastingAndItsCastedActorsByIdAsync(string id)
        {
            Guid guidId = Guid.Empty;
            GuidValidation(id, ref guidId);

            Casting? castingToDelete = await _castingRepository.GetByIdAsync(guidId);

            if (castingToDelete == null)
            {
                throw new Exception(ServerError);
            }

            castingToDelete.IsDeleted = true;

            if (!await _castingRepository.SoftDeleteAsync(guidId))
            {
                throw new Exception(ServerError);
            }

            List<ActorCasting> castedActorsToDelete = await _actorCastingRepository
                .GetAllAttached()
                .Where(ac => ac.CastingId == guidId)
                .ToListAsync();

            foreach (ActorCasting castedActor in castedActorsToDelete)
            {
                castedActor.IsDeleted = true;

                if (!await _actorCastingRepository.SoftDeleteAsync(castedActor.ActorId, castedActor.CastingId))
                {
                    throw new Exception(ServerError);
                }
            }
        }

        public async Task DeleteMovieAndItsRolesByIdAsync(string id)
        {
            Guid guidId = Guid.Empty;
            GuidValidation(id, ref guidId);

            Movie movieToDelete = await _movieRepository.GetByIdAsync(guidId);

            if (movieToDelete == null)
            {
                throw new Exception(ServerError);
            }

            movieToDelete.IsDeleted = true;

            if (!await _movieRepository.SoftDeleteAsync(guidId))
            {
                throw new Exception(ServerError);
            }

            List<ActorMovie> rolesToDelete = await _actorMovieRepository
                .GetAllAttached()
                .Where(am => am.MovieId == guidId)
                .ToListAsync();

            foreach (ActorMovie role in rolesToDelete)
            {
                role.IsDeleted = true;

                if (!await _actorMovieRepository.SoftDeleteAsync(role.ActorId, role.MovieId))
                {
                    throw new Exception(ServerError);
                }
            }
        }

        public async Task DeletePlayAndItsRolesByIdAsync(string id)
        {
            Guid guidId = Guid.Empty;
            GuidValidation(id, ref guidId);

            Play playToDelete = await _playRepository.GetByIdAsync(guidId);

            if (playToDelete == null)
            {
                throw new Exception(ServerError);
            }

            playToDelete.IsDeleted = true;

            if (!await _playRepository.SoftDeleteAsync(guidId))
            {
                throw new Exception(ServerError);
            }

            List<ActorPlay> rolesToDelete = await _actorPlayRepository
                .GetAllAttached()
                .Where(ap => ap.PlayId == guidId)
                .ToListAsync();

            foreach (ActorPlay role in rolesToDelete)
            {
                role.IsDeleted = true;

                if (!await _actorPlayRepository.SoftDeleteAsync(role.ActorId, role.PlayId))
                {
                    throw new Exception(ServerError);
                }
            }
        }

        public async Task DeleteUserAndItsConnectedEntitiesByIdAsync(string id)
        {
            Guid guidId = Guid.Empty;
            GuidValidation(id, ref guidId);

            ApplicationUser? userToDelete = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == guidId);

            if (userToDelete == null)
            {
                throw new Exception(ServerError);
            }

            userToDelete.IsDeleted = true;
            await _userManager.UpdateAsync(userToDelete);

            Actor? actor = await _actorRepository.FirstOrDefaultAsync(a => a.UserId == guidId);
            CastingAgent? castingAgent = await _castingAgentRepository.FirstOrDefaultAsync(ca => ca.UserId == guidId);

            if (actor != null)
            {
                actor.IsDeleted = true;

                if (!await _actorRepository.SoftDeleteAsync(actor.Id))
                {
                    throw new Exception(ServerError);
                }

                List<ActorPlay> rolesInPlaysToDelete = await _actorPlayRepository
                    .GetAllAttached()
                    .Where(ap => ap.ActorId == actor.Id)
                    .ToListAsync();

                List<ActorMovie> rolesInMoviesToDelete = await _actorMovieRepository
                    .GetAllAttached()
                    .Where(am => am.ActorId == actor.Id)
                    .ToListAsync();

                List<ActorCasting> castingsOfActorToDelete = await _actorCastingRepository
                    .GetAllAttached()
                    .Where(ac => ac.ActorId == actor.Id)
                    .ToListAsync();

                foreach (ActorPlay role in rolesInPlaysToDelete)
                {
                    role.IsDeleted = true;

                    if (!await _actorPlayRepository.SoftDeleteAsync(role.ActorId, role.PlayId))
                    {
                        throw new Exception(ServerError);
                    }
                }

                foreach (ActorMovie role in rolesInMoviesToDelete)
                {
                    role.IsDeleted = true;

                    if (!await _actorMovieRepository.SoftDeleteAsync(role.ActorId, role.MovieId))
                    {
                        throw new Exception(ServerError);
                    }
                }

                foreach (ActorCasting casting in castingsOfActorToDelete)
                {
                    casting.IsDeleted = true;

                    if (!await _actorCastingRepository.SoftDeleteAsync(casting.ActorId, casting.CastingId))
                    {
                        throw new Exception(ServerError);
                    }
                }
            }
            else if (castingAgent != null)
            {
                castingAgent.IsDeleted = true;

                if (!await _castingAgentRepository.SoftDeleteAsync(castingAgent.Id))
                {
                    throw new Exception(ServerError);
                }
            }
            else
            {
                throw new Exception(ServerError);
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
                        Director = m.Director,
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
                        Director = p.Director,
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

        public async Task<IEnumerable<CastingToEditViewModel>> IndexViewAllCastingsForEditAsync()
        {
            var models = await _castingRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .Select(c => new CastingToEditViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    CastingAgentName = c.CastingAgent.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString(CastingEndDateTimeFormatString),
                    CastingEnd = c.CastingEnd.ToString(CastingEndDateTimeFormatString)
                })
                .ToListAsync();

            return models;
        }

        public async Task<IEnumerable<MovieToEditViewModel>> IndexViewAllMoviesForEditAsync()
        {
            var models = await _movieRepository
                .GetAllAttached()
                .Where(m => m.IsDeleted == false)
                .Select(m => new MovieToEditViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Director = m.Director,
                    Description = m.Description,
                    ReleaseYear = m.ReleaseYear,
                })
                .ToListAsync();

            return models;
        }

        public async Task<IEnumerable<PlayToEditViewModel>> IndexViewAllPlaysForEditAsync()
        {
            var models = await _playRepository
                .GetAllAttached()
                .Where(p => p.IsDeleted == false)
                .Select(p => new PlayToEditViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Theatre = p.Theatre,
                    Director = p.Director,
                    Description = p.Description,
                    ReleaseYear = p.ReleaseYear
                })
                .ToListAsync();

            return models;
        }

        public async Task<IEnumerable<UserToEditViewModel>> IndexViewAllUsersForEditAsync()
        {
            var models = await _userManager
                .Users
                .Where(u => u.IsDeleted == false)
                .Select(u => new UserToEditViewModel
                {
                    Id = u.Id.ToString()
                })
                .ToListAsync();

            var admins = await _userManager.GetUsersInRoleAsync(AdminRoleName);
            var adminIds = admins.Select(a => a.Id).ToList();

            models = models.Where(u => !adminIds.Contains(Guid.Parse(u.Id))).ToList();

            foreach (var user in models)
            {
                Guid guiId = Guid.Parse(user.Id);

                Actor actor = await _actorRepository.FirstOrDefaultAsync(a => a.UserId == guiId);
                CastingAgent castingAgent = await _castingAgentRepository.FirstOrDefaultAsync(ca => ca.UserId == guiId);

                if (actor != null)
                {
                    user.UserType = actor.GetType().Name;
                    user.FullName = $"{actor.FirstName} {actor.LastName}";
                }
                else if (castingAgent != null)
                {
                    user.UserType = castingAgent.GetType().Name;
                    user.FullName = castingAgent.Name;
                }
                else
                {
                    throw new Exception(ServerError);
                }
            }

            return models;
        }
    }
}
