namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IActorService
    {
        Task<bool> IsUserActorAsync(string userId);
    }
}
