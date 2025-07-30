using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PrjReact.APIAtividades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public UsuarioController() { }

        /// <summary>
        /// Obtem os usu�rios.
        /// </summary>
        /// <returns>List object.</returns>
        [HttpGet(Name = "ObterUsuarios")]
        public List<object> ObterUsuarios()
        {
            return new List<object> { new object(), new object() };
        }

        /// <summary>
        /// Efetua a adi��o de um usu�rio.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarUsuario")]
        public HttpResponseMessage AdicionarUsuario([FromBody] object usuario)
        {
            if (usuario == null)
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}
