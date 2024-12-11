using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using MockQueryable;
using Moq;

namespace ActorCastings.Services.Tests
{
    [TestFixture]
    public class ActorServiceTests
    {
        private Mock<IRepository<Actor, Guid>> _actorRepository;
        private IList<Actor> actors = new List<Actor>()
        {
            new Actor()
            {
                Id = Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "1234567890",
                Age = 29,
                ActorsMovies = new List<ActorMovie>()
                {
                    new ActorMovie()
                    {
                        MovieId = Guid.Parse("395413df-fe4d-4caf-8875-c3dc050a44ed"),
                        ActorId =Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                        IsApproved = true,
                        Movie = new Movie()
                        {
                            Id = Guid.Parse("395413df-fe4d-4caf-8875-c3dc050a44ed"),
                            Title = "New Movie",
                            Genre = "Action",
                            Director = "John John",
                            Description = "Test description of the new movie",
                            ReleaseYear = 2021,
                            ImageUrl = "test",
                            IsApproved = true
                        }
                    }
                },
                ActorsPlays = new List<ActorPlay>()
                {
                    new ActorPlay()
                    {
                        PlayId = Guid.Parse("dfcf822c-36db-4b57-8c13-f60ff2159c80"),
                        ActorId =Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                        IsApproved = true,
                        Play = new Play()
                        {
                            Id = Guid.Parse("dfcf822c-36db-4b57-8c13-f60ff2159c80"),
                            Title = "New Play",
                            Theatre = "National Theatre",
                            Director = "Ivan George",
                            Description = "Test description of the new play",
                            ImageUrl = "test",
                            ReleaseYear = 2018,
                            IsApproved = true
                        }
                    }
                },
                Biography = "Test biography of actor",
                ProfilePictureUrl = "https://profilePic",
                UserId = Guid.NewGuid(),
            },
            new Actor()
            {
                Id = Guid.Parse("445c5d0f-c98b-4ce8-8b1b-83d5c58ecfeb"),
                FirstName = "Maria",
                LastName = "Ivanova",
                PhoneNumber = "144467890",
                Age = 27,
                ActorsMovies = new List<ActorMovie>()
                {
                    new ActorMovie()
                    {
                        MovieId = Guid.Parse("c538936c-83e0-4a8a-a3ed-a957d362d59e"),
                        ActorId =Guid.Parse("445c5d0f-c98b-4ce8-8b1b-83d5c58ecfeb"),
                        IsApproved = true,
                        Movie = new Movie()
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
                    }
                },
                ActorsPlays = new List<ActorPlay>()
                {
                    new ActorPlay()
                    {
                        PlayId = Guid.Parse("486b20c1-e373-4604-8272-50946e0190d7"),
                        ActorId =Guid.Parse("445c5d0f-c98b-4ce8-8b1b-83d5c58ecfeb"),
                        IsApproved = true,
                        Play = new Play()
                        {
                            Id = Guid.Parse("486b20c1-e373-4604-8272-50946e0190d7"),
                            Title = "New Play2",
                            Theatre = "Public Theatre",
                            Director = "Ivan Peter",
                            Description = "Test description of the play",
                            ImageUrl = "test",
                            ReleaseYear = 2023,
                            IsApproved = true
                        }
                    }
                },
                Biography = "Test biography of actress",
                ProfilePictureUrl = "https://profilePic2",
                UserId = Guid.Parse("b84bc28a-e139-4921-9e6b-35e1d9fbab6e")
            }
        };

        [SetUp]
        public void Setup()
        {
            _actorRepository = new Mock<IRepository<Actor, Guid>>();
        }

        [Test]
        [TestCase(1, 6, 2)]
        [TestCase(2, 1, 1)]
        public async Task GetAllPaginatedActorsPositive(int page, int pageSize, int expectedCount)
        {
            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            IEnumerable<ActorIndexViewModel> allActorsActual = await actorService
                .IndexGetPaginatedActorsAsync(page, pageSize);

            Assert.That(allActorsActual, Is.Not.Null);
            Assert.That(allActorsActual.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(-1, 6)]
        [TestCase(2, 0)]
        public async Task GetAllPaginatedActorsNegative(int page, int pageSize)
        {
            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                IEnumerable<ActorIndexViewModel> allActorsActual = await actorService
                .IndexGetPaginatedActorsAsync(page, pageSize);

            });
        }

        [Test]
        public async Task IsUserActorPositive()
        {
            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            ApplicationUser actorUser = new ApplicationUser()
            {
                Id = Guid.Parse("b84bc28a-e139-4921-9e6b-35e1d9fbab6e")
            };

            bool testResult = actors.Any(a => a.UserId == actorUser.Id);

            bool actualResult = await actorService.IsUserActorAsync(actorUser.Id.ToString());

            Assert.That(actualResult, Is.EqualTo(testResult));
        }

        [Test]
        [TestCase("wrongid")]
        [TestCase("")]
        public async Task IsUserActorNegative(string id)
        {
            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            ApplicationUser actorUser = new ApplicationUser()
            {
                Id = Guid.Parse("b84bc28a-e139-4921-9e6b-35e1d9fbab6e")
            };

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await actorService.IsUserActorAsync(id);
            });
        }

        [Test]
        public async Task GetActorsCountPositive()
        {
            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            int actual = await actorService
                .GetActorsCountAsync();

            Assert.That(actual, Is.Not.Zero);
            Assert.That(actual, Is.EqualTo(actors.Count));
        }

        [Test]
        [TestCase("e2c67618-1a8d-47da-8778-a9df40503b56", 1)]
        [TestCase("445c5d0f-c98b-4ce8-8b1b-83d5c58ecfeb", 1)]
        public async Task GetActorDetailsPositive(string id, int collectionCount)
        {


            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            ActorDetailsViewModel actual = await actorService.GetActorDetailsByIdAsync(id);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Plays.Count, Is.EqualTo(collectionCount));
            Assert.That(actual.Movies.Count, Is.EqualTo(collectionCount));
        }

        [Test]
        [TestCase("wrongid")]
        [TestCase("")]
        public async Task GetActorDetailsNegativeInvalidId(string id)
        {


            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                ActorDetailsViewModel actual = await actorService.GetActorDetailsByIdAsync(id);
            });
        }

        [Test]
        [TestCase("c538936c-83e0-4a8a-a3ed-a957d362d59e")]
        [TestCase("486b20c1-e373-4604-8272-50946e0190d7")]
        public async Task GetActorDetailsNegativeNotFoundActor(string id)
        {


            IQueryable<Actor> actorMockQueryable = actors.BuildMock();

            _actorRepository
                .Setup(a => a.GetAllAttached())
                .Returns(actorMockQueryable);

            IActorService actorService = new ActorService(_actorRepository.Object);

            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                ActorDetailsViewModel actual = await actorService.GetActorDetailsByIdAsync(id);
            });
        }
    }
}