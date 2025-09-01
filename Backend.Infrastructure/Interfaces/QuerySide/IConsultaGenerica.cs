using static Backend.Infrastructure.Factory.ObjectFactory;

namespace Backend.Infrastructure.Interfaces.QuerySide
{
    public interface IConsultaGenerica<Class> where Class : class
    {
        IEnumerable<Class> ListarRegistros(string sTableName);
        Class? EncontrarPorCodigo(Guid Id, EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
    }
}
