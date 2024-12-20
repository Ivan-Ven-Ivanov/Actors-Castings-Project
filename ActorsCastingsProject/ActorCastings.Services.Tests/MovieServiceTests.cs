﻿using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Movie;
using MockQueryable;
using Moq;
using System.Linq.Expressions;

namespace ActorCastings.Services.Tests
{
    [TestFixture]
    public class MovieServiceTests
    {
        private Mock<IRepository<Movie, Guid>> _movieRepository;
        private Mock<IRepository<Actor, Guid>> _actorRepository;
        private Mock<IRepository<ActorMovie, Guid>> _actorMovieRepository;

        private IMovieService movieService;

        private IList<Movie> movies = new List<Movie>()
        {
            new Movie()
            {
                Id = Guid.Parse("395413df-fe4d-4caf-8875-c3dc050a44ed"),
                Title = "New Movie",
                Genre = "Action",
                Director = "John John",
                Description = "Test description of the new movie",
                ActorsMovies = new List<ActorMovie>
                {
                    new ActorMovie()
                    {
                        MovieId = Guid.Parse("395413df-fe4d-4caf-8875-c3dc050a44ed"),
                        ActorId =Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                        IsApproved = true,
                        Actor = new Actor()
                        {
                            Id = Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            PhoneNumber = "1234567890",
                            Age = 29,
                            Biography = "Test biography of actor",
                            ProfilePictureUrl = "https://profilePic",
                            UserId = Guid.NewGuid(),
                        }
                    }
                },
                ReleaseYear = 2021,
                ImageUrl = "test",
                IsApproved = true
            },
            new Movie()
            {
                Id = Guid.Parse("c538936c-83e0-4a8a-a3ed-a957d362d59e"),
                Title = "New Movie2",
                Genre = "Comedy",
                Director = "John George",
                Description = "Test description of the new comedy movie",
                ReleaseYear = 2022,
                ImageUrl = "test",
                IsApproved = true
            }
        };

        [SetUp]
        public void Setup()
        {
            _movieRepository = new Mock<IRepository<Movie, Guid>>();
            _actorRepository = new Mock<IRepository<Actor, Guid>>();
            _actorMovieRepository = new Mock<IRepository<ActorMovie, Guid>>();

            IQueryable<Movie> movieMockQueryable = movies.BuildMock();

            _movieRepository
                .Setup(m => m.GetAllAttached())
                .Returns(movieMockQueryable);

            movieService = new MovieService(_movieRepository.Object, _actorRepository.Object, _actorMovieRepository.Object);

        }

        [Test]
        [TestCase(1, 6, 2)]
        [TestCase(2, 1, 1)]
        public async Task GetAllPaginatedMoviesPositive(int page, int pageSize, int expectedCount)
        {

            IEnumerable<MovieViewModel> allMoviesActual = await movieService
                .IndexGetPaginatedMoviesAsync(page, pageSize);

            Assert.That(allMoviesActual, Is.Not.Null);
            Assert.That(allMoviesActual.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(-1, 6)]
        [TestCase(2, 0)]
        public async Task GetAllPaginatedMoviesNegative(int page, int pageSize)
        {

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                IEnumerable<MovieViewModel> allMoviesActual = await movieService
                .IndexGetPaginatedMoviesAsync(page, pageSize);

            });
        }

        [Test]
        public async Task GetMoviesCountPositive()
        {
            int actual = await movieService
                .GetMoviesCountAsync();

            Assert.That(actual, Is.Not.Zero);
            Assert.That(actual, Is.EqualTo(movies.Count));
        }

        [Test]
        [TestCase("395413df-fe4d-4caf-8875-c3dc050a44ed", 1)]
        public async Task GetMovieDetailsPositive(string id, int collectionCount)
        {
            MovieDetailsViewModel actual = await movieService.GetMovieDetailsAsync(id);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Actors.Count, Is.EqualTo(collectionCount));
        }

        [Test]
        [TestCase("wrongid")]
        [TestCase("")]
        public async Task GetMovieDetailsNegativeInvalidId(string id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                MovieDetailsViewModel actual = await movieService.GetMovieDetailsAsync(id);
            });
        }

        [Test]
        [TestCase("e2c67618-1a8d-47da-8778-a9df40503b56")]
        public async Task GetActorDetailsNegativeNotFoundActor(string id)
        {
            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                MovieDetailsViewModel actual = await movieService.GetMovieDetailsAsync(id);
            });
        }

        [Test]
        public async Task AddMovieAndRoleInItPositive()
        {
            var userId = Guid.NewGuid().ToString();
            var guidUserId = Guid.Parse(userId);

            var mockActor = new Actor
            {
                Id = Guid.NewGuid(),
                UserId = guidUserId
            };

            var model = new AddMovieViewModel
            {
                Title = "Test Movie",
                Genre = "Action",
                Description = "Test Description",
                Director = "Test Director",
                ImageUrl = "http://testimage.com",
                ReleaseYear = 2023,
                Role = "Lead"
            };

            _actorRepository
                .Setup(a => a.FirstOrDefaultAsync(It.IsAny<Expression<Func<Actor, bool>>>()))
                .ReturnsAsync(mockActor);

            _movieRepository
                .Setup(m => m.AddAsync(It.IsAny<Movie>()))
                .Returns(Task.CompletedTask);

            _actorMovieRepository
                .Setup(am => am.AddAsync(It.IsAny<ActorMovie>()))
                .Returns(Task.CompletedTask);

            await movieService.AddMovieAndRoleInItAsync(model, userId);

            _movieRepository.Verify(m => m.AddAsync(It.Is<Movie>(m =>
                m.Title == model.Title &&
                m.Genre == model.Genre &&
                m.Description == model.Description &&
                m.Director == model.Director &&
                m.ImageUrl == model.ImageUrl &&
                m.ReleaseYear == model.ReleaseYear &&
                m.IsApproved == false
            )), Times.Once);

            _actorMovieRepository.Verify(repo => repo.AddAsync(It.Is<ActorMovie>(am =>
                am.ActorId == mockActor.Id &&
                am.Role == model.Role &&
                am.IsApproved == false
            )), Times.Once);
        }

        [Test]
        [TestCase("ff")]
        [TestCase("")]
        public async Task AddMovieAndRoleInItNegativeIvalidId(string id)
        {
            var model = new AddMovieViewModel
            {
                Title = "Test Movie",
                Genre = "Action",
                Description = "Test Description",
                Director = "Test Director",
                ImageUrl = "http://testimage.com",
                ReleaseYear = 2023,
                Role = "Lead"
            };

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await movieService.AddMovieAndRoleInItAsync(model, id);
            });
        }

        [Test]
        [TestCase("0ccd5e52-d989-4b59-b83c-a1b57a7f6cf8")]
        public async Task AddMovieAndRoleInItNegativeInvalidUser(string id)
        {
            var model = new AddMovieViewModel
            {
                Title = "Test Movie",
                Genre = "Action",
                Description = "Test Description",
                Director = "Test Director",
                ImageUrl = "http://testimage.com",
                ReleaseYear = 2023,
                Role = "Lead"
            };

            Assert.ThrowsAsync<Exception>(async () =>
            {
                await movieService.AddMovieAndRoleInItAsync(model, id);
            });
        }
    }
}
