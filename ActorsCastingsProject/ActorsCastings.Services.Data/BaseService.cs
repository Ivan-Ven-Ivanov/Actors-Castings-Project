using ActorsCastings.Services.Data.Interfaces;

namespace ActorsCastings.Services.Data
{
    public class BaseService : IBaseService
    {
        public bool IsGuidValid(string? id, ref Guid guid)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out guid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
