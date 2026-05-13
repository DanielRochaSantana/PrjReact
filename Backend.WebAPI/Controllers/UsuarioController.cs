#region Usings
using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Backend.Domain.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Constants = Backend.Infrastructure.Utils.Constants;
using ObjectFactory = Backend.Infrastructure.Factory.ObjectFactory; 
#endregion Usings

namespace Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        #region Controller Fields
        /// <summary>
        /// The _usuarioService field.
        /// </summary>
        protected readonly IUsuarioService _usuarioService;
        #endregion Controller Fields 

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        #endregion Constructor

        #region Controller EndPoints
        /// <summary>
        /// Efetua a adição de um usuário.
        /// </summary>
        /// <param name="intermediateUsuarioModel">The intermediateUsuarioModel parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarUsuario")]
        public ActionResult<HttpResponseMessage> AdicionarUsuario([FromBody] IntermediateUsuarioModel intermediateUsuarioModel)
        {
            try
            {
                if (intermediateUsuarioModel == null || intermediateUsuarioModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Usuario usuario = ObjectFactory.GetUsuarioFromIntermediateUsuarioModel(intermediateUsuarioModel);

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
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarUsuario")]
        public ActionResult<HttpResponseMessage> ApagarUsuario(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _usuarioService.Remover(id, ObjectFactory.EntityEnum.Usuario, Constants.USUARIO, Constants.ID);

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
        /// <param name="id">The id parameter.</param>
        /// <param name="usuario">The usuario parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarUsuario")]
        public ActionResult<HttpResponseMessage> AtualizarUsuario([FromQuery] string id, [FromBody] IntermediateUsuarioModel? usuario)
        {
            try
            {
                if (usuario == null ||
                    !usuario.IsEdit ||
                    string.IsNullOrEmpty(id) ||
                    string.IsNullOrWhiteSpace(id) ||
                    id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                usuario.Id = id;

                Usuario _usuario = ObjectFactory.GetUsuarioFromIntermediateUsuarioModel(usuario);

                _usuarioService.Atualizar(_usuario, Constants.ID, Constants.USUARIO);

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
        /// <returns>ActionResult of IList of Usuario.</returns>
        [HttpGet(Name = "ObterUsuarios")]
        public ActionResult<IList<Usuario>> ObterUsuarios()
        {
            try
            {
                IList<Usuario> usuarios = _usuarioService.ListarRegistros(Constants.USUARIO).OrderByDescending(i => i.Nome).ToList();
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
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of Usuario.</returns>
        [HttpGet(Name = "ObterUsuarioPorId")]
        public ActionResult<Usuario> ObterUsuarioPorId(Guid id)
        {
            try
            {
                Usuario? usuario = _usuarioService.EncontrarPorCodigo(id,
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
        #endregion Controller EndPoints
    }
}
