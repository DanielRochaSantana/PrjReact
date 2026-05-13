#region Usings
using static Backend.Infrastructure.Factory.ObjectFactory;
#endregion Usings

namespace Backend.Infrastructure.Interfaces.CommandSide
{
    /// <summary>
    /// The IRepositorioGenerico interface.
    /// </summary>
    /// <typeparam name="Class">The Class type parameter.</typeparam>
    public interface IRepositorioGenerico<Class> where Class : class
    {
        /// <summary>
        /// Efetua a adição de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Adicionar(Class registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Efetua a remoção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        void Remover(Guid id, EntityEnum entityEnum, string tableName, string propriedadeChave);

        /// <summary>
        /// Efetua a atualização de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Atualizar(Class registro, string propriedadeChave, string tableName);
    }
}
