using Data.Contracts.Contracts;
using Degreed.Business;
using Degreed.Domain.Models;
using Degreed.Shared.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Degreed.WebApi.Tests.Business
{
    [TestClass]
    public class JokeBusinessTest
    {
        [TestMethod]
        public void GetJokesByTerm_Returns_JokesModels_Type()
        {
            //Arrange
            var term = "red";
            var mockJokeRepository = new Mock<IJokeRepository>();
            mockJokeRepository.Setup(x => x.GetJokesByTerm(It.IsAny<string>())).Returns(new JokesModels());
            var mockRepositoryFactory = new Mock<IRepositoryFactory>();
            mockRepositoryFactory.Setup(x => x.GetDataRepository<IJokeRepository>()).Returns(mockJokeRepository.Object);          
            var business = new JokeBusiness(mockRepositoryFactory.Object, new Shared.Utilities.JokesHelper());

            //Act
            JokesModels result = business.GetJokesByTerm(term);

            //Assert
            Assert.IsInstanceOfType(result, typeof(JokesModels));
        }

        [TestMethod]
        public void GetJokesByTerm_ReturnsCorrectNumberOf_JokesModels()
        {
            //Arrange
            var term = "red";
            var results = new List<JokeModel>{ new JokeModel() };
            var mockJokeRepository = new Mock<IJokeRepository>();
            mockJokeRepository.Setup(x => x.GetJokesByTerm(It.IsAny<string>())).Returns(new JokesModels() { Results = results, SearchTerm = "test" });
            var mockRepositoryFactory = new Mock<IRepositoryFactory>();
            mockRepositoryFactory.Setup(x => x.GetDataRepository<IJokeRepository>()).Returns(mockJokeRepository.Object);            
            var business = new JokeBusiness(mockRepositoryFactory.Object, new Shared.Utilities.JokesHelper());

            //Act
            JokesModels result = business.GetJokesByTerm(term);

            //Assert
            Assert.AreEqual(result.Results.Count, 1);
        }


        [TestMethod]
        public void GetJokesByTerm_ReturnsNull_WhenJokesModelsResults_AreNull()
        {
            //Arrange
            var term = "red";
            List<JokeModel> results = null;
            var mockJokeRepository = new Mock<IJokeRepository>();
            mockJokeRepository.Setup(x => x.GetJokesByTerm(It.IsAny<string>())).Returns(new JokesModels() { Results = results, SearchTerm = "test" });
            var mockRepositoryFactory = new Mock<IRepositoryFactory>();
            mockRepositoryFactory.Setup(x => x.GetDataRepository<IJokeRepository>()).Returns(mockJokeRepository.Object);
            var mockHighlighter = new Mock<IHighlighter>();
            var business = new JokeBusiness(mockRepositoryFactory.Object, new Shared.Utilities.JokesHelper());

            //Act
            JokesModels result = business.GetJokesByTerm(term);

            //Assert
            Assert.IsNull(result.Results);
        }



        [TestMethod]
        public void GetRandomJoke_ReturnsJokeModel_Type()
        {
            //Arrange
            var mockJokeRepository = new Mock<IJokeRepository>();
            mockJokeRepository.Setup(x => x.GetRandomJoke()).Returns(new JokeModel());
            var mockRepositoryFactory = new Mock<IRepositoryFactory>();
            mockRepositoryFactory.Setup(x => x.GetDataRepository<IJokeRepository>()).Returns(mockJokeRepository.Object);           
            var business = new JokeBusiness(mockRepositoryFactory.Object, new Shared.Utilities.JokesHelper());

            //Act
            JokeModel result = business.GetRandomJoke();

            //Assert
            Assert.IsInstanceOfType(result, typeof(JokeModel));
        }

    }
}
