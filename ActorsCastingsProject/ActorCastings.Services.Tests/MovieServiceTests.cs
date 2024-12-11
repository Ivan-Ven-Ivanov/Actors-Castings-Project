using ActorsCastings.Data.Models;
using ActorsCastings.Data.Repository.Interfaces;
using Moq;

namespace ActorCastings.Services.Tests
{
    [TestFixture]
    public class MovieServiceTests
    {
        private Mock<IRepository<Movie, Guid>> _movieRepository;

        [SetUp]
        public void Setup()
        {
            _movieRepository = new Mock<IRepository<Movie, Guid>>();
        }
    }
}
