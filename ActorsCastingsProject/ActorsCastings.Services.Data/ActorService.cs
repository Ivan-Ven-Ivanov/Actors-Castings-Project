﻿using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Services.Data
{
    public class ActorService : BaseService, IActorService
    {
        private readonly IRepository<Actor, Guid> _actorRepository;

        public ActorService(IRepository<Actor, Guid> actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<ActorDetailsViewModel> GetActorDetailsByIdAsync(string id)
        {
            Guid guidId = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref guidId);

            if (!isGuidValid)
            {
                throw new Exception();
            }

            Actor? actor = await _actorRepository
                .GetAllAttached()
                .Include(a => a.ActorsMovies)
                    .ThenInclude(am => am.Movie)
                .Include(a => a.ActorsPlays)
                    .ThenInclude(ap => ap.Play)
                .FirstOrDefaultAsync(a => a.Id == guidId);

            if (actor == null)
            {
                throw new Exception();
            }

            actor.ActorsMovies = actor.ActorsMovies.Where(am => am.IsApproved == true).ToList();
            actor.ActorsPlays = actor.ActorsPlays.Where(ap => ap.IsApproved == true).ToList();

            ActorDetailsViewModel model = new ActorDetailsViewModel
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Age = actor.Age.ToString(),
                Biography = actor.Biography,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                Movies = actor.ActorsMovies.Select(am => new MovieViewModel
                {
                    Id = am.Movie.Id.ToString(),
                    Title = am.Movie.Title,
                    Director = am.Movie.Director,
                    ImageUrl = am.Movie.ImageUrl,
                    ReleaseYear = am.Movie.ReleaseYear.ToString()
                })
                .ToList(),
                Plays = actor.ActorsPlays.Select(ap => new PlayViewModel
                {
                    Id = ap.Play.Id.ToString(),
                    Title = ap.Play.Title,
                    Director = ap.Play.Director,
                    ImageUrl = ap.Play.ImageUrl,
                    ReleaseYear = ap.Play.ReleaseYear.ToString()
                })
                .ToList()
            };

            return model;
        }

        public async Task<IEnumerable<ActorIndexViewModel>> IndexGetAllActorsAsync()
        {
            List<ActorIndexViewModel> models = await _actorRepository
                .GetAllAttached()
                .Select(a => new ActorIndexViewModel
                {
                    Id = a.Id.ToString(),
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    ProfilePictureUrl = a.ProfilePictureUrl
                })
                .ToListAsync();

            return models;
        }

        public async Task<bool> IsUserActorAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            Guid guidId = Guid.Empty;
            bool isGuidValid = IsGuidValid(userId, ref guidId);

            if (!isGuidValid)
            {
                return false;
            }

            bool result = await _actorRepository
                .GetAllAttached()
                .AnyAsync(a => a.UserId == guidId);

            return result;
        }
    }
}
