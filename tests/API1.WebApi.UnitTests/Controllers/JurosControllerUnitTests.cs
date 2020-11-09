using API1.WebApi.Controllers;
using API1.WebApi.Models;
using API1.WebApi.Models.Response;
using API1.WebApi.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace API1.WebApi.UnitTests.Controllers
{
    public class JurosControllerUnitTests
    {
        private Mock<ILoggingService<JurosController>> _loggingServiceMock;
        private JurosController _jurosController;

        [SetUp]
        public void Setup()
        {
            _loggingServiceMock = new Mock<ILoggingService<JurosController>>();
            _jurosController = new JurosController(_loggingServiceMock.Object);
        }

        [Test]
        public void GetTaxaJuros_Deve_RetornarTaxaJuros_Successfuly()
        {
            //Arrange
            //Act
            var response = ((OkObjectResult) _jurosController.GetTaxaJuros().Result).Value as Response<Juros>;
            
            //Assert
            response?.Conteudo.Taxa.Should().Be(0.01M);
            Assert.IsInstanceOf<Juros>(response?.Conteudo);
            _loggingServiceMock.Verify(_ => 
                _.LogInfo(It.IsAny<string>(), 
                    It.IsAny<string>(), 
                    It.IsAny<string>(), 
                    It.IsAny<int>()), Times.Once);
        }
    }
}
