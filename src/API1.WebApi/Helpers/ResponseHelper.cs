using System.Collections.Generic;
using System.Net;
using API1.WebApi.Models.Response;

namespace API1.WebApi.Helpers
{
    /// <summary>
    /// Classe Helper para a construção de respostas da API.
    /// </summary>
    public class ResponseHelper
    {
        /// <summary>
        ///  Método genérico para criar a resposta da API.
        /// </summary>
        /// <param name="message">O response da API.</param>
        /// <param name="httpStatusCode">O HttpStatusCode da API.</param>
        /// <param name="errors">Os <see cref="Error"/>s relacionados ao response da API.</param>
        /// <returns>A resposta da API.</returns>
        public static ResponseStatus CreateResponse(string message, HttpStatusCode httpStatusCode, List<Error> errors)
        {
            var response = new ResponseStatus
            {
                Status = new Status
                {
                    Mensagem = message,
                    StatusCode = httpStatusCode,
                    Erros = errors
                }
            };

            return response;
        }

        /// <summary>
        /// Método genérico para criar a resposta da API com contéudo.
        /// </summary>
        /// <typeparam name="T">O tipo da resposta da API.</typeparam>
        /// <param name="message">O response da API.</param>
        /// <param name="httpStatusCode">O HttpStatusCode da API.</param>
        /// <param name="errors">Os <see cref="Error"/>s relacionados ao response da API.</param>
        /// <param name="entity">O tipo/entidade a ser serializado com resposta da API.</param>
        /// <returns>A resposta da API.</returns>
        public static Response<T> CreateResponse<T>(string message, HttpStatusCode httpStatusCode, List<Error> errors, T entity)
            where T : class
        {
            var response = new Response<T>
            {
                Status = new Status
                {
                    Mensagem = message,
                    StatusCode = httpStatusCode,
                    Erros = errors
                },
                Conteudo = entity
            };

            return response;
        }
	}
}
