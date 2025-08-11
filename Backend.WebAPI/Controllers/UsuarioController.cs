using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.WebAPI.Controllers
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
        /// Obtem os usuários.
        /// </summary>
        /// <returns>List object.</returns>
        [HttpGet(Name = "ObterUsuarios")]
        public List<object> ObterUsuarios()
        {
            return new List<object> { new object(), new object() };
        }

        /// <summary>
        /// Efetua a adição de um usuário.
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
