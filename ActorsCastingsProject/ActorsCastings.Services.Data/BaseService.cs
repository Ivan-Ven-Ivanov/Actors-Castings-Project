using ActorsCastings.Services.Data.Interfaces;

using static ActorsCastings.Common.ExceptionMessages;

namespace ActorsCastings.Services.Data
{
    public class BaseService : IBaseService
    {
        public void GuidValidation(string? id, ref Guid guid)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(IdEmpty);
            }

            bool isGuidValid = Guid.TryParse(id, out guid);
            if (!isGuidValid)
            {
                throw new ArgumentException(InvalidIdFormat);
            }
        }

        public void PagesValidation(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(InvalidPageNumber);
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(InvalidPageSize);
            }
        }
    }
}
