using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;

namespace Backend.Application.Interfaces
{
    public interface IUsuarioService
    {
        #region CommandSide
        public void Adicionar(Usuario registro, string sPropriedadeChave, string sTableName);
        public void Atualizar(Usuario registro, string sPropriedadeChave, string sTableName);
        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Usuario> ListarRegistros(string sTableName);
        public Usuario? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion QuerySide
    }
}
