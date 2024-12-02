using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class MovieService : BaseService, IMovieService
    {
        private readonly IRepository<Movie, Guid> _movieRepository;

        public MovieService(IRepository<Movie, Guid> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsViewModel> GetMovieDetailsAsync(string id)
        {
            Guid guidId = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref guidId);

            if (!isGuidValid)
            {
                throw new Exception();
            }

            Movie? movie = await _movieRepository.GetAllAttached()
                .Include(m => m.ActorsMovies)
                    .ThenInclude(am => am.Actor)
                .FirstOrDefaultAsync(m => m.Id == guidId);

            if (movie == null)
            {
                throw new Exception();
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

        public async Task<IEnumerable<MovieViewModel>> IndexGetAllMoviesAsync()
        {
            List<MovieViewModel> models = await _movieRepository.GetAllAttached()
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
