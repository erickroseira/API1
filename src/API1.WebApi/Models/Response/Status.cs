using System.Collections.Generic;
using System.Net;

namespace API1.WebApi.Models.Response
{
    /// <summary>
    /// Representação do status do response.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// O Http StatusCode da requisição.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Mensagem genérica sobre o status da requisição.
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Erros associados ao request.
        /// </summary>
        public List<Error> Erros { get; set; }
    }
}
