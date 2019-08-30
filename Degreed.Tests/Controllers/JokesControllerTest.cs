using Business.Contracts.Contracts;
using Degreed.Domain.Enums;
using Degreed.Domain.Models;
using Degreed.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;


namespace Degreed.Tests.Controllers
{
    /// <summary>
    /// Summary description for JokeControllerTest
    /// </summary>
    [TestClass]
    public class JokesControllerTest
    {


        [TestMethod]
        public void RandomJoke_ReturnsJokeModel_WhenJokeIsNotNull()
        {
            var randomJoke = new JokeModel { Joke = "this is not a joke" };
            var factory = new Mock<IBusinessFactory>();

            factory.Setup(src=> src.GetBusinessClass<IJokeBusiness>().GetRandomJoke()).Returns(randomJoke);            

            var controller = new JokesController(factory.Object);

            var returns = controller.RandomJoke() as OkNegotiatedContentResult<JokeModel>;

            Assert.AreEqual(returns.Content, randomJoke);
        }


        [TestMethod]
        public void RandomJoke_ReturnsNull_WhenJokeIsNull()
        {
            var factory = new Mock<IBusinessFactory>();

            factory.Setup(src => src.GetBusinessClass<IJokeBusiness>().GetRandomJoke()).Returns(new JokeModel());

            var controller = new JokesController(factory.Object);

            var returns = controller.RandomJoke() as NegotiatedContentResult<JokeModel>;

            Assert.IsNull(returns);
        }

        [TestMethod]
        public void JokesByTerm_ReturnsJokeModels_WhenItHasJokes()
        {            
            var jokeModel = new JokeModel { Joke = "this is not a joke" };
            var jokeList = new List<JokeModel> { jokeModel };
            var jokeModels = new JokesModels { Results = jokeList};

            var factory = new Mock<IBusinessFactory>();            

            factory.Setup(src => src.GetBusinessClass<IJokeBusiness>().GetJokesByTerm(It.IsAny<string>())).Returns(jokeModels);

            var controller = new JokesController(factory.Object);

            var returns = controller.JokesByTerm("this") as OkNegotiatedContentResult<JokesModels>;

            Assert.AreEqual(returns.Content, jokeModels);
        }

        [TestMethod]
        public void JokesByTerm_ReturnsNull_WhenNoJokesWereFound()
        {
            var jokeList = new List<JokeModel>();
            var jokeModels = new JokesModels {  Results = jokeList };

            var factory = new Mock<IBusinessFactory>();

            factory.Setup(src => src.GetBusinessClass<IJokeBusiness>().GetJokesByTerm(It.IsAny<string>())).Returns(jokeModels);

            var controller = new JokesController(factory.Object);

            var returns = controller.JokesByTerm("this") as NegotiatedContentResult<JokesModels>;

            Assert.IsNull(returns);
        }
    }
}
