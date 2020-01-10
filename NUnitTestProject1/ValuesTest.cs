using NUnit.Framework;
using ConverterAPI.Controllers;
using Moq;
using System.Net.Http;

namespace Tests
{
    public class ValuesTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var mockFactory = new Mock<IHttpClientFactory>();

            //mockCreditDecisionService = new Mock<ICreditDecisionService>(MockBehavior.Strict);
            //mockCreditDecisionService.Setup(p => p.GetDecision(creditScore)).Returns(expectedResult);

            var controller = new ValuesController(mockFactory as IHttpClientFactory);

            var result = controller.Get();
            Assert.AreEqual("10", result);
            //Assert.Pass();
        }
    }
}