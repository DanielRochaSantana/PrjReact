#region Usings
using Backend.Infrastructure.Interfaces.Context;
using Backend.Infrastructure.Interfaces.QuerySide;
using static Backend.Infrastructure.Factory.ObjectFactory;
#endregion Usings

namespace Backend.Infrastructure.QuerySide
{
    /// <summary>
    /// The ConsultaGenerica class.
    /// </summary>
    /// <typeparam name="Class">The Class type parameter.</typeparam>
    public class ConsultaGenerica<Class> : IConsultaGenerica<Class> where Class : class
    {
        #region Class Field
        /// <summary>
        /// The context field.
        /// </summary>
        private readonly IContext context;
        #endregion Class Field

        #region Constructor
        /// <summary>
        /// The ConsultaGenerica constructor.
        /// </summary>
        /// <param name="context">The context parameter.</param>
        public ConsultaGenerica(IContext context)
        {
            this.context = context;
        }
        #endregion Constructor

        #region Class Methods
        /// <summary>
        /// Lista os registros.
        /// </summary>       
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Class.</returns>
        public IEnumerable<Class> ListarRegistros(string tableName)
        {
            string query = " Select * from " + tableName;

            return context.ListarRegistros<Class>(tableName, query);
        }

        /// <summary>
        /// Obtem um registro por Id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Class?.</returns>
        public Class? EncontrarPorId(Guid id, EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            string query = " Select * from " + tableName + " " +
                            " Where " + propriedadeChave + " = @" + propriedadeChave + " ";

            return context.EncontrarPorId<Class>(id, entityEnum, tableName, propriedadeChave, query);
        }
        #endregion Class Methods
    }
}
