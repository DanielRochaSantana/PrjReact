using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;

namespace Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        protected readonly IRepositorioGenerico<Usuario> _repositorioCli;
        protected readonly IConsultaGenerica<Usuario> _consultaCli;

        public UsuarioService(IRepositorioGenerico<Usuario> repositorioCli,
                              IConsultaGenerica<Usuario> consultaCli)
        {
            _repositorioCli = repositorioCli;
            _consultaCli = consultaCli;
        }

        #region CommandSide
        public void Adicionar(Usuario registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioCli.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void Atualizar(Usuario registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioCli.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioCli.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Usuario> ListarRegistros(string sTableName)
        {
            return _consultaCli.ListarRegistros(sTableName);
        }

        public Usuario? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaCli.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion QuerySide
    }
}
