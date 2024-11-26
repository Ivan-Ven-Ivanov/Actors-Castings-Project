namespace ActorsCastings.Services.Data.Interfaces
{
    public interface ICastingAgentService
    {
        Task<bool> IsUserCastingAgentAsync(string userId);
    }
}
