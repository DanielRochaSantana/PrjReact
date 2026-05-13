#region Usings
using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;
#endregion Usings

namespace Backend.Application.Services
{
    /// <summary>
    /// The UsuarioService service.
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        #region Service Fields
        /// <summary>
        /// The _repositorioUsuario field.
        /// </summary>
        protected readonly IRepositorioGenerico<Usuario> _repositorioUsuario;

        /// <summary>
        /// The _consultaUsuario field.
        /// </summary>
        protected readonly IConsultaGenerica<Usuario> _consultaUsuario;
        #endregion Service Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioUsuario">The repositorioUsuario parameter.</param>
        /// <param name="consultaUsuario">The consultaUsuario parameter.</param>
        public UsuarioService(IRepositorioGenerico<Usuario> repositorioUsuario,
                              IConsultaGenerica<Usuario> consultaUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
            _consultaUsuario = consultaUsuario;
        }
        #endregion Constructor

        #region CommandSide
        /// <summary>
        /// Efetua a adição de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Adicionar(Usuario registro, string propriedadeChave, string tableName)
        {
            _repositorioUsuario.Adicionar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a atualização de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Atualizar(Usuario registro, string propriedadeChave, string tableName)
        {
            _repositorioUsuario.Atualizar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a remoção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        public void Remover(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            _repositorioUsuario.Remover(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Usuario.</returns>
        public IEnumerable<Usuario> ListarRegistros(string tableName)
        {
            return _consultaUsuario.ListarRegistros(tableName);
        }

        /// <summary>
        /// Efetua a obtenção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Usuario.</returns>
        public Usuario? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            return _consultaUsuario.EncontrarPorId(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion QuerySide
    }
}
