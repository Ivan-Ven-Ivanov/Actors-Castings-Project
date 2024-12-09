using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

using static ActorsCastings.Common.ExceptionMessages;

namespace ActorsCastings.Services.Data
{
    public class MovieService : BaseService, IMovieService
    {
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IRepository<ActorMovie, Guid> _actorMovieRepository;

        public MovieService(
            IRepository<Movie, Guid> movieRepository,
            IRepository<Actor, Guid> actorRepository,
            IRepository<ActorMovie, Guid> actorMovieRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _actorMovieRepository = actorMovieRepository;
        }

        public async Task AddMovieAndRoleInItAsync(AddMovieViewModel model, string userId)
        {
            Guid guidUserId = Guid.Empty;
            GuidValidation(userId, ref guidUserId);

            Movie movie = new Movie
            {
                Title = model.Title,
                Genre = model.Genre,
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

            ActorMovie actorMovie = new ActorMovie
            {
                ActorId = currentActor.Id,
                MovieId = movie.Id,
                Role = model.Role,
                IsApproved = false
            };

            await _movieRepository.AddAsync(movie);
            await _actorMovieRepository.AddAsync(actorMovie);
        }

        public async Task<MovieDetailsViewModel> GetMovieDetailsAsync(string id)
        {
            Guid guidId = Guid.Empty;
            GuidValidation(id, ref guidId);

            Movie? movie = await _movieRepository.GetAllAttached()
                .Include(m => m.ActorsMovies)
                    .ThenInclude(am => am.Actor)
                .FirstOrDefaultAsync(m => m.Id == guidId);

            if (movie == null)
            {
                throw new KeyNotFoundException(string.Format(EntityNotFoundById, nameof(Movie), id));
            }

            movie.ActorsMovies = movie.ActorsMovies.Where(am => am.IsApproved == true).ToList();

            MovieDetailsViewModel model = new MovieDetailsViewModel
            {
                Id = movie.Id.ToString(),
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Director = movie.Director,
                ImageUrl = movie.ImageUrl,
                ReleaseYear = movie.ReleaseYear.ToString(),
                Actors = movie.ActorsMovies
                .Select(am => new ActorInMovieViewModel
                {
                    Id = am.Actor.Id.ToString(),
                    FirstName = am.Actor.FirstName,
                    LastName = am.Actor.LastName,
                    ProfilePictureUrl = am.Actor.ProfilePictureUrl,
                    Role = am.Role
                }).ToList()
            };

            return model;
        }

        public async Task<int> GetMoviesCountAsync()
        {
            return await _movieRepository.GetAllAttached().CountAsync();
        }

        public async Task<IList<MovieViewModel>> IndexGetPaginatedMoviesAsync(int page, int pageSize)
        {
            PagesValidation(page, pageSize);

            List<MovieViewModel> models = await _movieRepository
                .GetAllAttached()
                .OrderBy(m => m.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Where(m => !m.IsDeleted && m.IsApproved)
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
    }
}
