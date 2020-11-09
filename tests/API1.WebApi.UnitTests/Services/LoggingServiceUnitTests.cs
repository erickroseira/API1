using System;
using API1.WebApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace API1.WebApi.UnitTests.Services
{
    public class LoggingServiceUnitTests
    {
        private ILoggingService<It.IsAnyType> _loggingService;
        private Mock<ILogger<It.IsAnyType>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<It.IsAnyType>>();
            _loggingService = new LoggingService<It.IsAnyType>(_loggerMock.Object);
        }

        [Test]
        public void LogInfo_Deve_LogarInfo_LogInformationLevel()
        {
            //Arrange
            var mensagem = "Qualquer Informação";

            //Act
            _loggingService.LogInfo(mensagem);

            //Assert
            _loggerMock.Verify(_ => 
                _.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Exactly(1));
        }

        [Test]
        public void LogError_Deve_LogarErro_LogErrorLevel()
        {
            //Arrange
            var mensagem = "Qualquer Informação de informaçao de erro/exceção";
            var excecao = new Exception("Exceção ao acessar elemento no index ...");

            //Act
            _loggingService.LogError(mensagem, excecao);

            //Assert
            _loggerMock.Verify(_ =>
                _.Log(LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Exactly(1));
        }
    }
}
