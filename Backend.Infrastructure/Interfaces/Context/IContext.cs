#region Usings
using static Backend.Infrastructure.Factory.ObjectFactory;
using System.Data.SqlClient; 
#endregion Usings

namespace Backend.Infrastructure.Interfaces.Context
{
    /// <summary>
    /// The IContext interface.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Efetua a conexão.
        /// </summary>
        /// <returns>SqlConnection.</returns>
        SqlConnection Conectar();

        /// <summary>
        /// Efetua a desconexão.
        /// </summary>
        void Desconectar();

        /// <summary>
        /// Efetua a obtenção de um registro por Id.
        /// </summary>
        /// <typeparam name="Class">The Class type parameter.</typeparam>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="query">The query parameter.</param>
        /// <returns>Class?.</returns>
        Class? EncontrarPorId<Class>(Guid id, EntityEnum entityEnum, string tableName, string propriedadeChave, string query) where Class : class;

        /// <summary>
        /// Efetua a execução de um comando.
        /// </summary>
        /// <typeparam name="Class">The Class type parameter.</typeparam>
        /// <param name="command">The command parameter.</param>
        /// <param name="registro">The registro parameter.</param>
        void ExecuteCommand<Class>(string command, Class registro) where Class : class;

        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <typeparam name="Class">The Class type parameter.</typeparam>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="query">The query parameter.</param>
        /// <returns>IEnumerable of Class.</returns>
        IEnumerable<Class> ListarRegistros<Class>(string tableName, string query);

        /// <summary>
        /// Retorna uma lista à partir de uma consulta.
        /// </summary>
        /// <typeparam name="Class">The Class type parameter.</typeparam>
        /// <param name="query">The query parameter.</param>
        /// <returns>IList of Class.</returns>
        IList<Class> ReturnListFromQuery<Class>(string query) where Class : class;
    }
}
