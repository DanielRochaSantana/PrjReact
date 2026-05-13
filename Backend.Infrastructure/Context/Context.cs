#region Usings
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.Context;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
#endregion Usings

namespace Backend.Infrastructure.Context
{
    /// <summary>
    /// The Context class.
    /// </summary>
    public class Context : IContext
    {
        #region Class Fields
        /// <summary>
        /// The configuration field.
        /// </summary>
        protected readonly IConfigurationRoot configuration;

        /// <summary>
        /// The connString field.
        /// </summary>
        protected readonly string? connString;

        /// <summary>
        /// The connection field.
        /// </summary>
        protected SqlConnection connection;
        #endregion Class Fields

        #region Constructor
        /// <summary>
        /// The Context constructor.
        /// </summary>
        public Context()
        {
            this.configuration = new ConfigurationBuilder()
                                     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                     .AddJsonFile("appsettings.json")
                                     .Build();

            this.connString = this.configuration.GetConnectionString("DefaultConnection");

            this.connection = new SqlConnection(this.connString);
        }
        #endregion Constructor

        #region Class Methods
        /// <summary>
        /// Efetua e retorna a conexão aberta.
        /// </summary>
        /// <returns>SqlConnection.</returns>
        public SqlConnection Conectar()
        {
            this.connection = new SqlConnection(this.connString);
            this.connection.Open();
            return this.connection;
        }

        /// <summary>
        /// Efetua a desconexão.
        /// </summary>
        public void Desconectar()
        {
            if (this.connection.State == System.Data.ConnectionState.Open)
                this.connection.Close();
        }

        /// <summary>
        /// Encontra por Id.
        /// </summary>
        /// <typeparam name="Class">The Class type parameter.</typeparam>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="query">The query parameter.</param>
        /// <returns>Class.</returns>
        public Class? EncontrarPorId<Class>(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave, string query) where Class : class
        {
            using (SqlConnection connection = Conectar())
            {
                return connection.Query<Class>(query, ObjectFactory.GetObject(entityEnum, id) as Class).FirstOrDefault();
            }
        }

        /// <summary>
        /// Executa comando.
        /// </summary>
        /// <typeparam name="Class">The Class type parameter.</typeparam>
        /// <param name="command">The command parameter.</param>
        /// <param name="registro">The registro parameter.</param>
        public void ExecuteCommand<Class>(string command, Class registro) where Class : class
        {
            using (SqlConnection connection = Conectar())
            {

                connection.Execute(command, registro);

                connection.Close();

            }

            Desconectar();
        }

        /// <summary>
        /// Lista registros.
        /// </summary>
        /// <typeparam name="Class">The Class type parameter.</typeparam>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Class.</returns>
        public IEnumerable<Class> ListarRegistros<Class>(string tableName, string query)
        {
            using (SqlConnection connection = Conectar())
            {
                return connection.Query<Class>(query);
            }
        }

        /// <summary>
        /// Retorna registros a partir de uma query
        /// </summary>
        /// <typeparam name="TYPE">The TYPE type parameter.</typeparam>
        /// <param name="query">The query parameter.</param>
        /// <returns>IList of TYPE.</returns>
        public IList<TYPE> ReturnListFromQuery<TYPE>(string query) where TYPE : class
        {
            Conectar();

            IList<TYPE> lstRegistros = (IList<TYPE>)connection.Query<TYPE>(query);

            Desconectar();

            return lstRegistros;
        }
        #endregion Class Methods
    }
}
