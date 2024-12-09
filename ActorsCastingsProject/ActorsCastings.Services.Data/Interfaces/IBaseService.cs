namespace ActorsCastings.Services.Data.Interfaces
{
    public interface IBaseService
    {
        void GuidValidation(string? id, ref Guid guid);

        void PagesValidation(int page, int pageSize);
    }
}
