using ActorsCastings.Web.ViewModels;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ISearchService
    {
        Task<SearchViewModel> GetSearchResultsByQueryAsync(string query);
    }
}
