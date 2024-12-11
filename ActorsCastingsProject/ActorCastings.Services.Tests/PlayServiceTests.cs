using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Play;
using MockQueryable;
using Moq;
using System.Linq.Expressions;

namespace ActorCastings.Services.Tests
{

    [TestFixture]
    public class PlayServiceTests
    {
        private Mock<IRepository<Play, Guid>> _playRepository;
        private Mock<IRepository<Actor, Guid>> _actorRepository;
        private Mock<IRepository<ActorPlay, Guid>> _actorPlayRepository;

        private IPlayService playService;

        private IList<Play> plays = new List<Play>()
        {
            new Play()
            {
                Id = Guid.Parse("2c459674-8238-4ea8-8fe4-21f0bf5acb16"),
                Title = "New Play",
                Theatre = "National",
                Director = "John John",
                Description = "Test description of the new play",
                ActorsPlays = new List<ActorPlay>
                {
                    new ActorPlay()
                    {
                        PlayId = Guid.Parse("2c459674-8238-4ea8-8fe4-21f0bf5acb16"),
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
            new Play()
            {
                Id = Guid.Parse("f70c5c2c-967a-405b-88ef-25782bf796f3"),
                Title = "New Play2",
                Theatre = "Public",
                Director = "John George",
                Description = "Test description of the new comedy play",
                ReleaseYear = 2022,
                ImageUrl = "test",
                IsApproved = true
            }
        };

        [SetUp]
        public void Setup()
        {
            _playRepository = new Mock<IRepository<Play, Guid>>();
            _actorRepository = new Mock<IRepository<Actor, Guid>>();
            _actorPlayRepository = new Mock<IRepository<ActorPlay, Guid>>();

            IQueryable<Play> playMockQueryable = plays.BuildMock();

            _playRepository
                .Setup(m => m.GetAllAttached())
                .Returns(playMockQueryable);

            playService = new PlayService(_playRepository.Object, _actorRepository.Object, _actorPlayRepository.Object);

        }

        [Test]
        [TestCase(1, 6, 2)]
        [TestCase(2, 1, 1)]
        public async Task GetAllPaginatedPlaysPositive(int page, int pageSize, int expectedCount)
        {

            IEnumerable<PlayViewModel> allPlaysActual = await playService
                .IndexGetPaginatedPlaysAsync(page, pageSize);

            Assert.That(allPlaysActual, Is.Not.Null);
            Assert.That(allPlaysActual.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(-1, 6)]
        [TestCase(2, 0)]
        public async Task GetAllPaginatedPlaysNegative(int page, int pageSize)
        {

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                IEnumerable<PlayViewModel> allPlaysActual = await playService
                .IndexGetPaginatedPlaysAsync(page, pageSize);

            });
        }

        [Test]
        public async Task GetPlaysCountPositive()
        {
            int actual = await playService
                .GetPlaysCountAsync();

            Assert.That(actual, Is.Not.Zero);
            Assert.That(actual, Is.EqualTo(plays.Count));
        }

        [Test]
        [TestCase("2c459674-8238-4ea8-8fe4-21f0bf5acb16", 1)]
        public async Task GetPlayDetailsPositive(string id, int collectionCount)
        {
            PlayDetailsViewModel actual = await playService.GetPlayDetailsAsync(id);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Actors.Count, Is.EqualTo(collectionCount));
        }

        [Test]
        [TestCase("wrongid")]
        [TestCase("")]
        public async Task GetPlayDetailsNegativeInvalidId(string id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                PlayDetailsViewModel actual = await playService.GetPlayDetailsAsync(id);
            });
        }

        [Test]
        [TestCase("e2c67618-1a8d-47da-8778-a9df40503b56")]
        public async Task GetPlayDetailsNegativeNotFoundActor(string id)
        {
            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                PlayDetailsViewModel actual = await playService.GetPlayDetailsAsync(id);
            });
        }

        [Test]
        public async Task AddPlayAndRoleInItPositive()
        {
            var userId = Guid.NewGuid().ToString();
            var guidUserId = Guid.Parse(userId);

            var mockActor = new Actor
            {
                Id = Guid.NewGuid(),
                UserId = guidUserId
            };

            var model = new AddPlayViewModel
            {
                Title = "Test Movie",
                Theatre = "Test Theatre",
                Description = "Test Description",
                Director = "Test Director",
                ImageUrl = "http://testimage.com",
                ReleaseYear = 2023,
                Role = "Lead"
            };

            _actorRepository
                .Setup(a => a.FirstOrDefaultAsync(It.IsAny<Expression<Func<Actor, bool>>>()))
                .ReturnsAsync(mockActor);

            _playRepository
                .Setup(p => p.AddAsync(It.IsAny<Play>()))
                .Returns(Task.CompletedTask);

            _actorPlayRepository
                .Setup(am => am.AddAsync(It.IsAny<ActorPlay>()))
                .Returns(Task.CompletedTask);

            await playService.AddPlayAndRoleInItAsync(model, userId);

            _playRepository.Verify(m => m.AddAsync(It.Is<Play>(m =>
                m.Title == model.Title &&
                m.Theatre == model.Theatre &&
                m.Description == model.Description &&
                m.Director == model.Director &&
                m.ImageUrl == model.ImageUrl &&
                m.ReleaseYear == model.ReleaseYear &&
                m.IsApproved == false
            )), Times.Once);

            _actorPlayRepository.Verify(repo => repo.AddAsync(It.Is<ActorPlay>(ap =>
                ap.ActorId == mockActor.Id &&
                ap.Role == model.Role &&
                ap.IsApproved == false
            )), Times.Once);
        }

        [Test]
        [TestCase("ff")]
        [TestCase("")]
        public async Task AddPlayAndRoleInItNegativeIvalidId(string id)
        {
            var model = new AddPlayViewModel
            {
                Title = "Test Movie",
                Theatre = "Test Theatre",
                Description = "Test Description",
                Director = "Test Director",
                ImageUrl = "http://testimage.com",
                ReleaseYear = 2023,
                Role = "Lead"
            };

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await playService.AddPlayAndRoleInItAsync(model, id);
            });
        }

        [Test]
        [TestCase("0ccd5e52-d989-4b59-b83c-a1b57a7f6cf8")]
        public async Task AddPlayAndRoleInItNegativeInvalidUser(string id)
        {
            var model = new AddPlayViewModel
            {
                Title = "Test Movie",
                Theatre = "Test Theatre",
                Description = "Test Description",
                Director = "Test Director",
                ImageUrl = "http://testimage.com",
                ReleaseYear = 2023,
                Role = "Lead"
            };

            Assert.ThrowsAsync<Exception>(async () =>
            {
                await playService.AddPlayAndRoleInItAsync(model, id);
            });
        }
    }
}
