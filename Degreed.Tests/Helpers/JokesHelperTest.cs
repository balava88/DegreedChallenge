using Degreed.Domain.Enums;
using Degreed.Shared.Highlighters;
using Degreed.Shared.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Degreed.WebApi.Tests.Helpers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class JokesHelperTest
    {
        [TestMethod]
        public void GetJokeLength_ReturnsShort_WhenWordsAreLessThan10()
        {
            //Arrange
            var text = "red";
            var helper = new JokesHelper();

            //Act
            var result = helper.GetJokeLength(text);

            //Assert
            Assert.AreEqual(JokeLengthClassification.Short, result);
        }

        [TestMethod]
        public void GetJokeLength_ReturnsMedium_WhenWordsAreLessThan20()
        {
            //Arrange
            var text = "red, blue, this is a very long text that should get a number 20";
            var helper = new JokesHelper();

            //Act
            var result = helper.GetJokeLength(text);

            //Assert
            Assert.AreEqual(JokeLengthClassification.Medium, result);
        }

        
        [TestMethod]
        public void GetJokeLength_ReturnsLong_WhenWordsAreGraterThan20()
        {
            //Arrange
            var text = "red, blue, this is a very long text that should get a number 30, but for that we need atleast some more words just to be sure this works";
            var helper = new JokesHelper();

            //Act
            var result = helper.GetJokeLength(text);

            //Assert
            Assert.AreEqual(JokeLengthClassification.Long, result);
        }

        [TestMethod]
        public void GetJokeLength_ReturnsShort_WhenJokeIsEmpty()
        {
            //Arrange
            var text = " ";
            var helper = new JokesHelper();

            //Act
            var result = helper.GetJokeLength(text);

            //Assert
            Assert.AreEqual(JokeLengthClassification.Short, result);
        }

        [TestMethod]
        public void HighLight_HighLights_WhenCompleteWordExists()
        {
            //Arrange
            var text = "red, blue, this is a very long";
            var wordToHighlight = "red";
            var helper = new JokesHelper();
            var emphasizeHighlighter = new EmphasizeHighlighter();

            //Act
            var result = helper.HighLight(text, wordToHighlight, emphasizeHighlighter);

            //Assert
            Assert.AreEqual("<em>red</em>, blue, this is a very long", result);
        }

        [TestMethod]
        public void HighLight_ReturnsNull_WhenJokeIsNull()
        {
            //Arrange
            string text = null;
            var wordToHighlight = "red";
            var helper = new JokesHelper();
            var emphasizeHighlighter = new EmphasizeHighlighter();

            //Act
            var result = helper.HighLight(text, wordToHighlight, emphasizeHighlighter);

            //Assert
            Assert.AreEqual(text, result);
        }


        [TestMethod]
        public void HighLight_ReturnsSameText_WhenTextToBeHighlighted_IsNull()
        {
            //Arrange
            string text = "My text example";
            string wordToHighlight = null;
            var helper = new JokesHelper();
            var emphasizeHighlighter = new EmphasizeHighlighter();

            //Act
            var result = helper.HighLight(text, wordToHighlight, emphasizeHighlighter);

            //Assert
            Assert.AreEqual(text, result);
        }

        [TestMethod]
        public void HighLight_HighLights_WhenPartialWordExists()
        {
            //Arrange
            var text = "the readiness of the blue ocean, this is a very long";
            var wordToHighlight = "read";
            var helper = new JokesHelper();
            var boldHighlighter = new BoldHighlighter();

            //Act
            var result = helper.HighLight(text, wordToHighlight, boldHighlighter);

            //Assert
            Assert.AreEqual("the <b>read</b>iness of the blue ocean, this is a very long", result);
        }


        [TestMethod]
        public void HighLight_ReturnsSameText_WhenTextToBeHighlighted_DoesNotExistInJoke()
        {
            //Arrange
            var text = "the readiness of the blue ocean, this is a very long";
            var wordToHighlight = "test";
            var helper = new JokesHelper();
            var boldHighlighter = new BoldHighlighter();

            //Act
            var result = helper.HighLight(text, wordToHighlight, boldHighlighter);

            //Assert
            Assert.AreEqual(text, result);
        }


        [TestMethod]
        public void HighLight_HighLightsText_IgnoringCase()
        {
            //Arrange
            var text = "the readiness of the blue ocean, this is a very long";
            var wordToHighlight = "REad";
            var helper = new JokesHelper();
            var boldHighlighter = new BoldHighlighter();

            //Act
            var result = helper.HighLight(text, wordToHighlight, boldHighlighter);

            //Assert
            Assert.AreEqual("the <b>read</b>iness of the blue ocean, this is a very long", result);
        }
    }
}
