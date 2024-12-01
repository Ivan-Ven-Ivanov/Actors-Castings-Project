using ActorsCastings.Web.ViewModels.Movie;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> IndexGetAllMoviesAsync();

        Task<MovieDetailsViewModel> GetMovieDetailsAsync(string id);
    }
}
