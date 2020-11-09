using System;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace API1.WebApi.Services
{
    /// <summary>
    /// Implementação de <see cref="ILoggingService{T}"/> 
    /// </summary>
    public class LoggingService<T> : ILoggingService<T> where T : class
    {
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Contrutor do serviço de logger.
        /// </summary>
        /// <param name="logger">Instância do logger.</param>
        public LoggingService(ILogger<T> logger)
        {
            _logger = logger;
        }

        ///<inheritdoc cref="ILoggingService{T}.LogInfo"/>
        public void LogInfo(string message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            AddDefaultLogContextProperties(memberName, sourceFilePath, sourceLineNumber);

            _logger.LogInformation(message);
        }

        ///<inheritdoc cref="ILoggingService{T}.LogError"/>
        public void LogError(string message, Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            AddDefaultLogContextProperties(memberName, sourceFilePath, sourceLineNumber);

            _logger.LogError(exception, message);
        }

        /// <summary>
        /// Adiciona Propriedades default comum a todos os logs.
        /// </summary>
        /// <param name="memberName">Nome do método que acionou o logger.</param>
        /// <param name="sourceFilePath">Caminho do arquivo que acionou o log. </param>
        /// <param name="sourceLineNumber">Número da linha da arquivo (fonte) que acionou o logger.</param>
        private void AddDefaultLogContextProperties(string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            AdicionaPropriedadeLogContext("MemberName", memberName);
            AdicionaPropriedadeLogContext("FilePath", sourceFilePath);
            AdicionaPropriedadeLogContext("LineNumber", sourceLineNumber);
        }

        /// <summary>
        /// Adiciona propriedade ao LogContext que posteriormente será mostrada no Log.
        /// </summary>
        /// <param name="propertyName">Propriedade a ser adicionada.</param>
        /// <param name="value">Valor da propriedade.</param>
        private void AdicionaPropriedadeLogContext(string propertyName, object value) =>
            LogContext.PushProperty(propertyName, value);
    }
}
