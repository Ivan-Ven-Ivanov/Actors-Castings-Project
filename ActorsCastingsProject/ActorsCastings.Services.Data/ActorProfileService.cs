using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class ActorProfileService : BaseService, IActorProfileService
    {
        private readonly IRepository<Actor, Guid> _actorRepository;

        public ActorProfileService(
            IRepository<Actor, Guid> actorRepository,
            UserManager<ApplicationUser> userManager)
        {
            _actorRepository = actorRepository;
        }
        public async Task<ActorProfileViewModel> IndexGetMyProfileAsync(string id)
        {
            Guid guidId = Guid.Empty;

            bool isGuidValid = IsGuidValid(id, ref guidId);

            Actor? actor = await _actorRepository
                .GetAllAttached()
                .Include(a => a.ActorsMovies)
                .Include(a => a.ActorsPlays)
                .FirstOrDefaultAsync(a => a.UserId == guidId);

            if (actor == null)
            {
                throw new Exception("Actor not found.");
            }

            ActorProfileViewModel model = new ActorProfileViewModel
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                Age = actor.Age,
                Biography = actor.Biography,
                Movies = actor.ActorsMovies
                    .Select(am => new MovieViewModel
                    {
                        Title = am.Movie.Title,
                        ImageUrl = am.Movie.ImageUrl,
                        Director = am.Movie.Director,
                        ReleaseYear = am.Movie.ReleaseYear.ToString()
                    }).ToList(),
                Plays = actor.ActorsPlays
                    .Select(ap => new PlayViewModel
                    {
                        Title = ap.Play.Title,
                        ImageUrl = ap.Play.ImageUrl,
                        Director = ap.Play.Director,
                        ReleaseYear = ap.Play.ReleaseYear.ToString()
                    }).ToList()
            };

            return model;
        }
    }
}
