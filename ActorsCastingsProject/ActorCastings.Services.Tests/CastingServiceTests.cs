using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Casting;
using MockQueryable;
using Moq;
using System.Globalization;
using System.Linq.Expressions;

namespace ActorCastings.Services.Tests
{
    [TestFixture]
    public class CastingServiceTests
    {
        private Mock<IRepository<Casting, Guid>> _castingRepository;
        private Mock<IRepository<Actor, Guid>> _actorRepository;
        private Mock<IRepository<CastingAgent, Guid>> _castingAgentRepository;
        private Mock<IRepository<ActorCasting, Guid>> _actorCastingRepository;

        private ICastingService castingService;

        private IList<Casting> castings = new List<Casting>()
        {
            new Casting()
            {
                Id = Guid.Parse("cd87f695-bc1c-4d7d-851c-f4a70b8ff642"),
                Description = "New casting test description",
                CastingAgentId = Guid.Parse("3350a3ab-a009-47b6-b6c2-a95ab22eb65b"),
                CastingAgent = new CastingAgent()
                {
                    Id = Guid.Parse("3350a3ab-a009-47b6-b6c2-a95ab22eb65b"),
                    CastingAgency = "Casting agency"
                },
                ActorsCastings = new List<ActorCasting>()
                {
                    new ActorCasting()
                    {
                        CastingId = Guid.Parse("cd87f695-bc1c-4d7d-851c-f4a70b8ff642"),
                        ActorId = Guid.Parse("7effd0f6-b029-4b05-a4ca-69d9602f5b10"),
                        Actor = new Actor()
                        {
                            Id = Guid.Parse("7effd0f6-b029-4b05-a4ca-69d9602f5b10"),
                            FirstName = "Test name",
                            LastName = "Test last name",
                            Age = 26,
                            PhoneNumber = "088888",
                            ProfilePictureUrl = "profilepic",
                            UserId = Guid.Parse("9e2a28a2-95bd-45e8-867a-016633bd8d62")
                        }
                    }
                },
                CastingEnd = DateTime.Now,
                CreatedOn = DateTime.Now,
                Title = "Title",
                IsApproved = true,
            },
            new Casting()
            {
                Id = Guid.NewGuid(),
                Description = "New second casting test description",
                CastingAgentId = Guid.NewGuid(),
                CastingEnd = DateTime.Now,
                CreatedOn = DateTime.Now,
                Title = "New Title",
                IsApproved = true,
            }
        };

        [SetUp]
        public void Setup()
        {
            _castingRepository = new Mock<IRepository<Casting, Guid>>();
            _actorRepository = new Mock<IRepository<Actor, Guid>>();
            _actorCastingRepository = new Mock<IRepository<ActorCasting, Guid>>();
            _castingAgentRepository = new Mock<IRepository<CastingAgent, Guid>>();

            IQueryable<Casting> castingMockQueryable = castings.BuildMock();

            _castingRepository
                .Setup(m => m.GetAllAttached())
            .Returns(castingMockQueryable);

            _actorCastingRepository
                .Setup(m => m.GetAllAttached())
                .Returns(castings.SelectMany(c => c.ActorsCastings).BuildMock());

            castingService = new CastingService(_castingRepository.Object, _actorRepository.Object, _castingAgentRepository.Object, _actorCastingRepository.Object);
        }

        [Test]
        [TestCase(1, 6, 2)]
        [TestCase(2, 1, 1)]
        public async Task GetAllPaginatedCastingsPositive(int page, int pageSize, int expectedCount)
        {

            IEnumerable<CastingViewModel> allCastingsActual = await castingService
                .IndexGetPaginatedCastingsAsync(page, pageSize);

            Assert.That(allCastingsActual, Is.Not.Null);
            Assert.That(allCastingsActual.Count(), Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(-1, 6)]
        [TestCase(2, 0)]
        public async Task GetAllPaginatedCastingsNegative(int page, int pageSize)
        {

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                IEnumerable<CastingViewModel> allCastingsActual = await castingService
                .IndexGetPaginatedCastingsAsync(page, pageSize);

            });
        }

        [Test]
        public async Task GetCastingsCountPositive()
        {
            int actual = await castingService
                .GetCastingsCountAsync();

            Assert.That(actual, Is.Not.Zero);
            Assert.That(actual, Is.EqualTo(castings.Count));
        }

        [Test]
        [TestCase("cd87f695-bc1c-4d7d-851c-f4a70b8ff642", 1)]
        public async Task GetCastingDetailsPositive(string id, int collectionCount)
        {
            string userId = "9e2a28a2-95bd-45e8-867a-016633bd8d62";

            CastingDetailsViewModel actual = await castingService.GetCastingDetailsByIdAsync(id, userId);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.CastedActors.Count, Is.EqualTo(collectionCount));
        }

        [Test]
        [TestCase("wrongid")]
        [TestCase("")]
        public async Task GetCastingDetailsNegativeInvalidId(string id)
        {
            string userId = Guid.NewGuid().ToString();
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                CastingDetailsViewModel actual = await castingService.GetCastingDetailsByIdAsync(id, userId);
            });
        }

        [Test]
        [TestCase("e2c67618-1a8d-47da-8778-a9df40503b56")]
        public async Task GetCastingDetailsNegativeNotFoundActor(string id)
        {
            string userId = Guid.NewGuid().ToString();
            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                CastingDetailsViewModel actual = await castingService.GetCastingDetailsByIdAsync(id, userId);
            });
        }

        [Test]
        public async Task AddCastingPositive()
        {
            var model = new AddCastingViewModel()
            {
                Title = "Title",
                Description = "Description for the casting",
                CastingEnd = "10/10/2024 18:00"
            };

            DateTime date = DateTime.ParseExact(model.CastingEnd, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None);

            var mockCastingAgent = new CastingAgent()
            {
                Id = Guid.Parse("3350a3ab-a009-47b6-b6c2-a95ab22eb65b"),
                Name = "Casting Agent",
                CastingAgency = "Casting agency",
                UserId = Guid.Parse("b2cdd577-9ad0-42a0-97f0-0d8a5d121d24")
            };

            _castingAgentRepository.Setup(ca => ca.FirstOrDefaultAsync(It.IsAny<Expression<Func<CastingAgent, bool>>>()))
                .ReturnsAsync(mockCastingAgent);

            _castingRepository.Setup(c => c.AddAsync(It.IsAny<Casting>()))
                .Returns(Task.CompletedTask);

            await castingService.AddCastingAsync(model, "b2cdd577-9ad0-42a0-97f0-0d8a5d121d24");

            _castingRepository.Verify(c => c.AddAsync(It.Is<Casting>(c =>
                c.Title == model.Title &&
                c.Description == model.Description &&
                c.CastingEnd == date
            )), Times.Once);
        }

        [Test]
        [TestCase("")]
        [TestCase("gfgdf")]
        public async Task AddCastingNegativeInvalidId(string id)
        {
            var model = new AddCastingViewModel()
            {
                Title = "Title",
                Description = "Description for the casting",
                CastingEnd = "10/10/2024 18:00"
            };

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await castingService.AddCastingAsync(model, id);
            });
        }

        [Test]
        public async Task ApplyForCastingPositive()
        {
            Casting mockCasting = new Casting()
            {
                Id = Guid.Parse("a228f3a7-0a21-4d90-8beb-bd22340c05cf"),
                Title = "Title",
                CastingAgentId = Guid.NewGuid(),
                Description = "Description for casting",
                CastingEnd = DateTime.Now,
                IsApproved = true,
            };

            Actor mockActor = new Actor()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "05050550",
                UserId = Guid.Parse("5fdb1fc4-56eb-4a95-b602-ab50c33c21a0"),
                ProfilePictureUrl = "picture"
            };

            _castingRepository.Setup(c => c.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockCasting);

            _actorRepository.Setup(a => a.FirstOrDefaultAsync(It.IsAny<Expression<Func<Actor, bool>>>()))
                .ReturnsAsync(mockActor);

            _actorCastingRepository.Setup(ac => ac.GetAllAttached())
                .Returns(new List<ActorCasting>().AsQueryable().BuildMock());

            _actorCastingRepository.Setup(ac => ac.AddAsync(It.IsAny<ActorCasting>()))
                .Returns(Task.CompletedTask);

            await castingService.ApplyForCastingAsync("a228f3a7-0a21-4d90-8beb-bd22340c05cf", "5fdb1fc4-56eb-4a95-b602-ab50c33c21a0");

            _actorCastingRepository.Verify(ac => ac.AddAsync(It.Is<ActorCasting>(ac =>
                ac.CastingId == mockCasting.Id &&
                ac.ActorId == mockActor.Id
            )), Times.Once);
        }

        [Test]
        [TestCase("", "5fdb1fc4-56eb-4a95-b602-ab50c33c21a0")]
        [TestCase("", "")]
        public async Task ApplyForCastingNegativeInvalidId(string castingId, string userId)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await castingService.ApplyForCastingAsync(castingId, userId);
            });
        }

        [Test]
        [TestCase("32ce588e-e3f8-4bf7-ab0c-0eb52f3a90df", "a228f3a7-0a21-4d90-8beb-bd22340c05cf")]
        public async Task ApplyForCastingNegativeCastingNotFound(string castingId, string userId)
        {

            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await castingService.ApplyForCastingAsync(castingId, userId);
            });
        }
    }
}
