#region Usings
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.Context;
using static Backend.Infrastructure.Factory.ObjectFactory;
#endregion Usings

namespace Backend.Infrastructure.CommandSide
{
    /// <summary>
    /// The RepositorioGenerico class.
    /// </summary>
    /// <typeparam name="Class">The Class type parameter.</typeparam>
    public class RepositorioGenerico<Class> : IRepositorioGenerico<Class> where Class : class
    {
        #region Repository Fields
        /// <summary>
        /// The context field.
        /// </summary>
        private readonly IContext context;

        /// <summary>
        /// The propriedades and valores and camposEValores fields.
        /// </summary>
        protected string propriedades, valores, camposEValores;
        #endregion Repository Fields

        #region Constructor
        /// <summary>
        /// The RepositorioGenerico constructor.
        /// </summary>
        /// <param name="context">The context parameter.</param>
        public RepositorioGenerico(IContext context)
        {
            this.context = context;

            this.propriedades = this.valores
                               = this.camposEValores
                               = string.Empty;
        }
        #endregion Constructor

        #region Repository Methods
        /// <summary>
        /// Adiciona um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>        
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>        
        /// <param name="tableName">The tableName parameter.</param>        
        public void Adicionar(Class registro, string propriedadeChave, string tableName)
        {
            propriedades = valores = camposEValores = string.Empty;

            PopularPropriedadesValores(registro, propriedadeChave);

            string command = " Insert into " + tableName + " ( " +
                                 propriedades +
                                 " ) " +
                                 " Values (" +
                                 valores +
                                 " ) ";

            ExecuteCommand(command, registro);
        }

        /// <summary>
        /// Popula as propriedades e os valores.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>       
        public void PopularPropriedadesValores(Class registro, string propriedadeChave)
        {
            IList<string> lstPropriedades = ObterDescricoesPropriedades(registro);

            if (lstPropriedades.Any(filtro => filtro == propriedadeChave))
                lstPropriedades.Remove(propriedadeChave);

            propriedades = string.Join(",", lstPropriedades);

            IList<string> lstValores = RetornarItensParaMontagemParteValores(lstPropriedades);

            valores = string.Join(",", lstValores);
        }

        /// <summary>
        /// Retorna uma lista contendo itens no padrão '@DescriçãoPropriedade' para haver a montagem da parte de valores no comando SQL.
        /// </summary>
        /// <param name="lstPropriedades">The lstPropriedades parameter.</param>
        /// <returns>IList of string.</returns>
        public IList<string> RetornarItensParaMontagemParteValores(IList<string> lstPropriedades)
        {
            IList<string> lstValores = (ObjectFactory.GetInstance(ObjectEnum.ListaStrings) as List<string>)!;

            foreach (string item in lstPropriedades)
                lstValores.Add("@" + item);

            return lstValores;
        }

        /// <summary>
        /// Remove um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        public void Remover(Guid id, EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            string command = " Delete from " + tableName + " " +
                                " Where " + propriedadeChave + " = @" + propriedadeChave + " ";

            ExecuteCommand(command, (ObjectFactory.GetObject(entityEnum, id) as Class)!);
        }

        /// <summary>
        /// Atualiza um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Atualizar(Class registro, string propriedadeChave, string tableName)
        {
            propriedades = valores = camposEValores = string.Empty;

            PopularPropriedadesValores(registro, propriedadeChave);

            RetornarCamposEValoresParaOperacaoUpdate();

            string command = " Update " + tableName + " set  " + camposEValores +
                                " where " + propriedadeChave + " = @" + propriedadeChave + " ";

            ExecuteCommand(command, registro);
        }

        /// <summary>
        /// Retorna os campos e os valores para haver a operação de update.
        /// </summary>
        /// <returns>string.</returns>
        public string RetornarCamposEValoresParaOperacaoUpdate()
        {
            IList<string> lstColunas = propriedades.Split(',');

            IList<string> lstValores = valores.Split(',');

            for (int iContador = 0; iContador < lstColunas.Count; iContador++)
            {
                camposEValores += lstColunas[iContador] + " = " + lstValores[iContador];

                if (iContador < lstColunas.Count - 1)
                    camposEValores += ",";

            }

            return camposEValores;
        }

        /// <summary>
        /// Executa um comando.
        /// </summary>
        /// <param name="command">The command parameter.</param>
        /// <param name="registro">The registro parameter.</param>
        public void ExecuteCommand(string command, Class registro)
        {
            context.ExecuteCommand<Class>(command, registro);
        }

        /// <summary>
        /// Obtem as descrições das propriedades de um objeto.
        /// Baseado em https://www.codegrepper.com/code-examples/csharp/get+list+of+properties+from+class+c%23
        /// </summary>
        /// <param name="objeto">The objeto parameter.</param>
        /// <returns>IList of string.</returns>
        public IList<string> ObterDescricoesPropriedades(object objeto)
        {
            if (objeto == null)
                return null;

            Type tipo = objeto.GetType();

            return tipo.GetProperties().Select(selecao => selecao.Name).ToList();
        }
        #endregion Repository Methods
    }
}
