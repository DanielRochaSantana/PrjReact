#region Usings
using static Backend.Infrastructure.Factory.ObjectFactory;
#endregion Usings

namespace Backend.Infrastructure.Interfaces.QuerySide
{
    /// <summary>
    /// The IConsultaGenerica interface.
    /// </summary>
    /// <typeparam name="Class">The Class type parameter.</typeparam>
    public interface IConsultaGenerica<Class> where Class : class
    {
        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Class.</returns>
        IEnumerable<Class> ListarRegistros(string tableName);

        /// <summary>
        /// Efetua a obtenção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Class?.</returns>
        Class? EncontrarPorId(Guid id, EntityEnum entityEnum, string tableName, string propriedadeChave);
    }
}
