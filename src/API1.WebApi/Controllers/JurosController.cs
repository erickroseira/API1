using System;
using System.Collections.Generic;
using System.Net;
using API1.WebApi.Helpers;
using API1.WebApi.Models;
using API1.WebApi.Models.Response;
using API1.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace API1.WebApi.Controllers
{
    /// <summary>
    /// Recebe todos os requests relacionados a Juros.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly ILoggingService<JurosController> _loggingService;
        private readonly decimal _taxaJuros = 0.01M;

        /// <summary>
        /// Construtor do JurosController.
        /// </summary>
        /// <param name="loggingService">Instância do Serviço de Logging.</param>
        public JurosController(ILoggingService<JurosController> loggingService)
        {
            _loggingService = loggingService;
        }


        /// <summary>
        /// Retorna a Taxa de Juros atual,
        /// </summary>
        /// <returns>A taxa de juros atual.</returns>
        [HttpGet("taxajuros")]
        [ProducesResponseType(typeof(Response<Juros>), 200)]
        [ProducesResponseType(typeof(ResponseStatus), 500)]
        public ActionResult<Response<Juros>> GetTaxaJuros()
        {
            try
            {
                _loggingService.LogInfo($"Retornando taxa de juros valor { new { taxaJuros = _taxaJuros } }.");

                var conteudo = new Juros
                {
                    Taxa = _taxaJuros
                };

                var response = ResponseHelper.CreateResponse("Taxa de Juros recuperada com sucesso.", HttpStatusCode.OK, new List<Error>(), conteudo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError($"Exceção ocorreu. {ex.Message}", ex);

                var response = ResponseHelper.CreateResponse("Algo inesperado ocorreu. Por favor cheque a lista de erros.", HttpStatusCode.InternalServerError, new List<Error> {new Error { Mensagem = ex.Message }});

                return StatusCode(500, response);
            }
        }
	}
}