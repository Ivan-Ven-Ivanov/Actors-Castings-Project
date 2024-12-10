using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Actor;
using MockQueryable;
using Moq;

namespace ActorCastings.Services.Tests
{
    public class ActorServiceTests
    {
        private Mock<IRepository<Actor, Guid>> _actorRepository;
        private IList<Actor> actors = new List<Actor>()
        {
            new Actor()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "1234567890",
                Age = 29,
                Biography = "Test biography of actor",
                ProfilePictureUrl = "https://profilePic",
                UserId = Guid.NewGuid(),
            },
            new Actor()
            {
                Id = Guid.NewGuid(),
                FirstName = "Maria",
                LastName = "Ivanova",
                PhoneNumber = "144467890",
                Age = 27,
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
        public async Task IsUserActorPositive(string id)
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
    }
}