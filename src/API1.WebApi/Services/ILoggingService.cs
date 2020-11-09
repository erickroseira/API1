using System;
using System.Runtime.CompilerServices;

namespace API1.WebApi.Services
{
    /// <summary>
    /// Serviço de Logging para o projeto.
    /// </summary>
    public interface ILoggingService<T> where T : class
    {
        /// <summary>
        /// Loga a nível de informação a mensagem passada como parâmetro.
        /// </summary>
        /// <param name="message">A mensagem a ser logada.</param>
        /// <param name="memberName">Nome do método que acionou o logger.</param>
        /// <param name="sourceFilePath">Caminho do arquivo que acionou o log. </param>
        /// <param name="sourceLineNumber">Número da linha da arquivo (fonte) que acionou o logger.</param>
        void LogInfo(string message, [CallerMemberName] string memberName = "",
                    [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Loga a nível de erro a mensagem passada como parâmetro e a exceção.
        /// </summary>
        /// <param name="message">A mensagem a ser logada.</param>
        /// <param name="exception">A exceção a ser logada.</param>
        /// <param name="memberName">Nome do método que acionou o logger.</param>
        /// <param name="sourceFilePath">Caminho do arquivo que acionou o log. </param>
        /// <param name="sourceLineNumber">Número da linha da arquivo (fonte) que acionou o logger.</param>
        void LogError(string message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
    }
}
