using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie, Guid> _movieRepository;

        public MovieService(IRepository<Movie, Guid> movieRepository)
        {
            _movieRepository = movieRepository;
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
