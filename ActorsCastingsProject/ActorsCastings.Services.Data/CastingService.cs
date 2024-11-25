using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Casting;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class CastingService : ICastingService
    {
        private readonly IRepository<Casting, Guid> _repository;

        public CastingService(IRepository<Casting, Guid> repository)
        {
            _repository = repository;
        }
        public async Task AddCastingAsync(AddCastingViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CastingViewModel>> IndexGetAllAsync()
        {
            IEnumerable<CastingViewModel> models = await _repository.GetAllAttached()
                .Select(c => new CastingViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    CastingEnd = c.CastingEnd.ToString(Common.EntityValidationConstants.Casting.CastingCastingEndDateTimeFormatString)
                })
                .ToListAsync();

            return models;
        }
    }
}
