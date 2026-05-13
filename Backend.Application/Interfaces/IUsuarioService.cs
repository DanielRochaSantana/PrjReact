#region Usings
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
#endregion Usings

namespace Backend.Application.Interfaces
{
    /// <summary>
    /// The IUsuarioService interface.
    /// </summary>
    public interface IUsuarioService
    {
        #region CommandSide
        /// <summary>
        /// Contrato para efetuar a adição de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Adicionar(Usuario registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Contrato para efetuar a atualização de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Atualizar(Usuario registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Contrato para efetuar a remoção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        void Remover(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave);
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Contrato para efetuar a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Usuario.</returns>
        IEnumerable<Usuario> ListarRegistros(string tableName);

        /// <summary>
        /// Contrato para efetuar a obtenção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Usuario.</returns>
        Usuario? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave);
        #endregion QuerySide
    }
}