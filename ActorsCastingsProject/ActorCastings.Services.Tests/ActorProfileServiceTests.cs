using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Services.Data;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using MockQueryable;
using Moq;
using System.Linq.Expressions;

namespace ActorCastings.Services.Tests
{
    [TestFixture]
    public class ActorProfileServiceTests
    {
        private Mock<IRepository<Actor, Guid>> _actorRepository;
        private Mock<IRepository<Movie, Guid>> _movieRepository;
        private Mock<IRepository<ActorMovie, Guid>> _actorMovieRepository;
        private Mock<IRepository<Play, Guid>> _playRepository;
        private Mock<IRepository<ActorPlay, Guid>> _actorPlayRepository;

        private IActorProfileService actorProfileService;

        [SetUp]
        public void SetUp()
        {
            _actorRepository = new Mock<IRepository<Actor, Guid>>();
            _movieRepository = new Mock<IRepository<Movie, Guid>>();
            _actorMovieRepository = new Mock<IRepository<ActorMovie, Guid>>();
            _playRepository = new Mock<IRepository<Play, Guid>>();
            _actorPlayRepository = new Mock<IRepository<ActorPlay, Guid>>();

            actorProfileService = new ActorProfileService(_actorRepository.Object, _movieRepository.Object, _actorMovieRepository.Object, _playRepository.Object, _actorPlayRepository.Object);
        }

        [Test]
        public async Task AddSelectedMovieToProfilePositive()
        {
            Movie mockMovie = new Movie()
            {
                Id = Guid.Parse("395413df-fe4d-4caf-8875-c3dc050a44ed"),
                Title = "New Movie",
                Genre = "Action",
                Director = "John John",
                Description = "Test description of the new movie",
                ReleaseYear = 2021,
                ImageUrl = "test",
                IsApproved = true
            };

            Actor mockActor = new Actor()
            {
                Id = Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "1234567890",
                Age = 29,
                Biography = "Test biography of actor",
                ProfilePictureUrl = "https://profilePic",
                UserId = Guid.Parse("9fbca016-2305-4441-8abd-f345842afa81"),
            };

            string role = "TestRole";

            _movieRepository.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockMovie);

            _actorRepository.Setup(a => a.FirstOrDefaultAsync(It.IsAny<Expression<Func<Actor, bool>>>()))
                .ReturnsAsync(mockActor);

            _actorMovieRepository.Setup(am => am.AddAsync(It.IsAny<ActorMovie>()))
                .Returns(Task.CompletedTask);

            await actorProfileService.AddSelectedMovieToProfileAsync("395413df-fe4d-4caf-8875-c3dc050a44ed", role, "9fbca016-2305-4441-8abd-f345842afa81");

            _actorMovieRepository.Verify(am => am.AddAsync(It.Is<ActorMovie>(am =>
                am.ActorId == mockActor.Id &&
                am.MovieId == mockMovie.Id &&
                am.Role == role
            )), Times.Once);
        }

        [Test]
        public async Task AddSelectedPlayToProfilePositive()
        {
            Play mockPlay = new Play()
            {
                Id = Guid.Parse("395413df-fe4d-4caf-8875-c3dc050a44ed"),
                Title = "New Movie",
                Theatre = "Test Theatre",
                Director = "John John",
                Description = "Test description of the new movie",
                ReleaseYear = 2021,
                ImageUrl = "test",
                IsApproved = true
            };

            Actor mockActor = new Actor()
            {
                Id = Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "1234567890",
                Age = 29,
                Biography = "Test biography of actor",
                ProfilePictureUrl = "https://profilePic",
                UserId = Guid.Parse("9fbca016-2305-4441-8abd-f345842afa81"),
            };

            string role = "TestRole";

            _playRepository.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockPlay);

            _actorRepository.Setup(a => a.FirstOrDefaultAsync(It.IsAny<Expression<Func<Actor, bool>>>()))
                .ReturnsAsync(mockActor);

            _actorPlayRepository.Setup(am => am.AddAsync(It.IsAny<ActorPlay>()))
                .Returns(Task.CompletedTask);

            await actorProfileService.AddSelectedPlayToProfileAsync("395413df-fe4d-4caf-8875-c3dc050a44ed", role, "9fbca016-2305-4441-8abd-f345842afa81");

            _actorPlayRepository.Verify(am => am.AddAsync(It.Is<ActorPlay>(am =>
                am.ActorId == mockActor.Id &&
                am.PlayId == mockPlay.Id &&
                am.Role == role
            )), Times.Once);
        }

        [Test]
        public async Task CompleteProfilePositive()
        {
            var model = new ActorProfileViewModel()
            {
                FirstName = "Test",
                LastName = "Test",
                Age = 20,
                PhoneNumber = "Test43343",
                ProfilePictureUrl = "link"
            };

            var userId = Guid.Parse("229c0613-64b6-4718-a984-6dd17041ddb0");

            _actorRepository.Setup(am => am.AddAsync(It.IsAny<Actor>()))
                .Returns(Task.CompletedTask);

            await actorProfileService.CompleteActorProfileAsync(userId.ToString(), model);

            _actorRepository.Verify(a => a.AddAsync(It.Is<Actor>(a =>
                a.UserId == userId &&
                a.FirstName == model.FirstName &&
                a.LastName == model.LastName &&
                a.Age == model.Age &&
                a.PhoneNumber == model.PhoneNumber &&
                a.ProfilePictureUrl == model.ProfilePictureUrl
            )), Times.Once);
        }

        [Test]
        public async Task GerActorProfileDataForUpdatePositive()
        {
            Actor mockActor = new Actor()
            {
                Id = Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "1234567890",
                Age = 29,
                Biography = "Test biography of actor",
                ProfilePictureUrl = "https://profilePic",
                UserId = Guid.Parse("9fbca016-2305-4441-8abd-f345842afa81"),
            };

            _actorRepository.Setup(a => a.FirstOrDefaultAsync(It.IsAny<Expression<Func<Actor, bool>>>()))
                .ReturnsAsync(mockActor);

            var model = await actorProfileService.GetActorProfileDataForUpdateAsync("e2c67618-1a8d-47da-8778-a9df40503b56");

            Assert.That(model, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(mockActor.Id));
        }

        [Test]
        public async Task GetAllMoviesForSelectPositive()
        {
            IList<Movie> mockList = new List<Movie>()
            {
                new Movie()
                {
                    Id = Guid.Parse("4913bb08-7bba-4cc1-af4d-8f9ff376ae44"),
                    Title = "Title",
                    Director = "Director",
                    ImageUrl = "urlimage",
                    ReleaseYear = 2019,
                    IsApproved = true
                }
            };

            IQueryable<Movie> movieMockQueryable = mockList.BuildMock();

            _movieRepository.Setup(m => m.GetAllAttached())
                .Returns(movieMockQueryable);

            var model = new SelectedMovieViewModel();

            var result = await actorProfileService.GetAllMoviesForSelectAsync(model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Movies.Count, Is.EqualTo(mockList.Count));
        }

        [Test]
        public async Task GetAllPlaysForSelectPositive()
        {
            IList<Play> mockList = new List<Play>()
            {
                new Play()
                {
                    Id = Guid.Parse("4913bb08-7bba-4cc1-af4d-8f9ff376ae44"),
                    Title = "Title",
                    Director = "Director",
                    Theatre = "Test Theatre",
                    ImageUrl = "urlimage",
                    ReleaseYear = 2019,
                    IsApproved = true
                }
            };

            IQueryable<Play> playMockQueryable = mockList.BuildMock();

            _playRepository.Setup(m => m.GetAllAttached())
                .Returns(playMockQueryable);

            var model = new SelectedPlayViewModel();

            var result = await actorProfileService.GetAllPlaysForSelectAsync(model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Plays.Count, Is.EqualTo(mockList.Count));
        }

        [Test]
        public async Task UpdateActorProfilePositive()
        {
            Actor mockActor = new Actor()
            {
                Id = Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "1234567890",
                Age = 29,
                Biography = "Test biography of actor",
                ProfilePictureUrl = "https://profilePic",
                UserId = Guid.Parse("9fbca016-2305-4441-8abd-f345842afa81"),
            };

            _actorRepository.Setup(a => a.FirstOrDefaultAsync(It.IsAny<Expression<Func<Actor, bool>>>()))
                .ReturnsAsync(mockActor);

            _actorRepository.Setup(a => a.UpdateAsync(It.IsAny<Actor>()))
                .ReturnsAsync(true);

            UpdateActorProfileViewModel model = new UpdateActorProfileViewModel()
            {
                Id = Guid.Parse("e2c67618-1a8d-47da-8778-a9df40503b56"),
                FirstName = "Ivan1",
                LastName = "Ivanov1",
                Age = 29,
                Biography = "Test biography of actor",
                ProfilePictureUrl = "https://profilePic",
            };

            await actorProfileService.UpdateActorProfileAsync(model);

            Assert.That(mockActor.FirstName, Is.EqualTo(model.FirstName));
            Assert.That(mockActor.LastName, Is.EqualTo(model.LastName));
        }
    }
}
