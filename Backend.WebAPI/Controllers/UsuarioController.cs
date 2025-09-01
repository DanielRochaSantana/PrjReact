using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Backend.Domain.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Constants = Backend.Infrastructure.Utils.Constants;
using ObjectFactory = Backend.Infrastructure.Factory.ObjectFactory;

namespace Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        protected readonly IUsuarioService _usuarioService;

        /// <summary>
        /// Construtor.
        /// </summary>
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Efetua a adição de um usuário.
        /// </summary>
        /// <param name="usuarioModel">O parâmetro usuarioModel.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarUsuario")]
        public ActionResult<HttpResponseMessage> AdicionarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                if (usuarioModel == null || usuarioModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Usuario usuario = ObjectFactory.GetUsuarioFromUsuarioModel(usuarioModel);

                _usuarioService.Adicionar(usuario, Constants.ID, Constants.USUARIO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remoção de um usuário.
        /// </summary>
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarUsuario")]
        public ActionResult<HttpResponseMessage> ApagarUsuario(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _usuarioService.Remover(Id, ObjectFactory.EntityEnum.Usuario, Constants.USUARIO, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualização de um usuário.
        /// </summary>
        /// <param name="IdUsuario">O parâmetro IdUsuario</param>
        /// <param name="_usuario">O parâmetro _usuario</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarUsuario")]
        public ActionResult<HttpResponseMessage> AtualizarUsuario(Guid IdUsuario, [FromBody] UsuarioModel? _usuario)
        {
            try
            {
                if (_usuario == null || !_usuario.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Usuario usuario = ObjectFactory.GetUsuarioFromUsuarioModel(_usuario);

                _usuarioService.Atualizar(usuario, Constants.ID, Constants.USUARIO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem os usuários.
        /// </summary>
        /// <returns>ActionResult IEnumerable Usuario.</returns>
        [HttpGet(Name = "ObterUsuarios")]
        public ActionResult<IEnumerable<Usuario>> ObterUsuarios()
        {
            try
            {
                IEnumerable<Usuario> usuarios = _usuarioService.ListarRegistros(Constants.USUARIO);
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem Usuário por Id.
        /// </summary>
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult Usuario.</returns>
        [HttpGet(Name = "ObterUsuarioPorId")]
        public ActionResult<Usuario> ObterUsuarioPorId(Guid Id)
        {
            try
            {
                Usuario? usuario = _usuarioService.EncontrarPorCodigo(Id,
                                                                      ObjectFactory.EntityEnum.Usuario,
                                                                      Constants.USUARIO,
                                                                      Constants.ID);
                return Ok(usuario);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
