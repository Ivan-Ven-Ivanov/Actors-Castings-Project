using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Casting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace ActorsCastings.Services.Data
{
    public class CastingService : ICastingService
    {
        private readonly IRepository<Casting, Guid> _castingRepository;
        private readonly IRepository<CastingAgent, Guid> _castingAgentRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CastingService(IRepository<Casting, Guid> repository, IRepository<CastingAgent, Guid> castingAgentRepository, UserManager<ApplicationUser> userManager)
        {
            _castingRepository = repository;
            _castingAgentRepository = castingAgentRepository;
            _userManager = userManager;
        }
        public async Task<bool> AddCastingAsync(AddCastingViewModel model, ClaimsPrincipal userPrincipal)
        {
            string? userId = _userManager.GetUserId(userPrincipal);
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }
            bool isDateCorrect = DateTime.TryParseExact
                (model.CastingEnd,
                Common.EntityValidationConstants.Casting.CastingCastingEndDateTimeFormatString,
                CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateTime);

            if (!isDateCorrect)
            {
                return false;
            }

            CastingAgent? current = await _castingAgentRepository
                .GetByIdAsync(user.Id);

            if (current == null)
            {
                return false;
            }

            Casting casting = new Casting()
            {
                Title = model.Title,
                Description = model.Description,
                CastingEnd = dateTime,
                CastingAgentId = current.Id
            };

            await _castingRepository.AddAsync(casting);
            return true;
        }

        public Task<CastingDetailsViewModel> GetCastingDetailsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CastingViewModel>> IndexGetAllAsync()
        {
            IEnumerable<CastingViewModel> models = await _castingRepository.GetAllAttached()
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
