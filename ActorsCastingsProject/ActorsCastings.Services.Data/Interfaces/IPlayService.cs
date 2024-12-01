using ActorsCastings.Web.ViewModels.Play;

namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IPlayService
    {
        Task<IEnumerable<PlayViewModel>> IndexGetAllPlaysAsync();

        Task<PlayDetailsViewModel> GetPlayDetailsAsync(string id);
    }
}
