namespace API1.WebApi.Models.Response
{
    /// <summary>
    /// Classe Wrapper que representa a resposta da API com o conteúdo.
    /// </summary>
    /// <typeparam name="T">O tipo genérico T que será incluído no conteúdo da resposta.</typeparam>
    public class Response<T> : ResponseStatus where T : class
    {
        /// <summary>
        /// O conteúdo do response.
        /// </summary>
        public T Conteudo { get; set; }
    }
}
