using ActorsCastings.Web.ViewModels.Movie;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IMovieService
    {
        Task<IList<MovieViewModel>> IndexGetPaginatedMoviesAsync(int page, int pageSize);

        Task<int> GetMoviesCountAsync();

        Task<MovieDetailsViewModel> GetMovieDetailsAsync(string id);

        Task AddMovieAndRoleInItAsync(AddMovieViewModel model, string userId);
    }
}
