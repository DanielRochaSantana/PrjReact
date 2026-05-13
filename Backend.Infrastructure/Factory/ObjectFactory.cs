#region Usings
using Backend.Domain.Models;
using Backend.Domain.Models.Entity;
#endregion Usings

namespace Backend.Infrastructure.Factory
{
    /// <summary>
    /// The ObjectFactory class.
    /// </summary>
    public static class ObjectFactory
    {
        /// <summary>
        /// Obtem uma nova instância de objeto.
        /// </summary>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="id">The id parameter.</param>
        /// <returns>object.</returns>
        public static object GetObject(EntityEnum entityEnum, Guid id)
        {
            switch (entityEnum)
            {
                case EntityEnum.Usuario:
                    return new Usuario { Id = id };                
                default:
                    return new();
            }
        }

        /// <summary>
        /// Obtem uma nova instância de objeto.
        /// </summary>
        /// <param name="objEnum">The objEnum parameter.</param>
        /// <returns>object.</returns>
        public static object GetInstance(ObjectEnum objEnum)
        {
            switch (objEnum)
            {
                case ObjectEnum.ListaStrings:
                    return new List<string>();
                default:
                    return new();
            }
        }

        /// <summary>
        /// Obtem um objeto Usuario à partir do parâmetro de entrada do tipo UsuarioModel.
        /// </summary>
        /// <param name="usuarioModel">The usuarioModel parameter.</param>
        /// <returns>Usuario.</returns>
        public static Usuario GetUsuarioFromUsuarioModel(UsuarioModel? usuarioModel)
        {
            if (usuarioModel != null)
                return new Usuario
                {
                    Celular = usuarioModel.Celular,
                    DataCadastro = usuarioModel.DataCadastro,
                    DataModificacao = usuarioModel.DataModificacao,
                    Email = usuarioModel.Email,
                    Id = usuarioModel.Id,
                    IsAtivo = usuarioModel.IsAtivo,
                    Nome = usuarioModel.Nome
                };

            return new();
        }
        
        /// <summary>
        /// Obtem um objeto Usuario à partir de um objeto do tipo IntermediateUsuarioModel.
        /// </summary>
        /// <param name="intermediateUsuarioModel">The IntermediateUsuarioModel parameter.</param>
        /// <returns>Usuario.</returns>
        public static Usuario GetUsuarioFromIntermediateUsuarioModel(IntermediateUsuarioModel? intermediateUsuarioModel)
        {
            Guid _id = Guid.Empty;

            if (intermediateUsuarioModel != null && intermediateUsuarioModel.Id != Guid.Empty.ToString())
                Guid.TryParse(intermediateUsuarioModel.Id, out _id);

            if (_id == Guid.Empty)
                _id = Guid.NewGuid();

            if (intermediateUsuarioModel != null)
                return new Usuario
                {
                    Celular = intermediateUsuarioModel.Celular,
                    DataCadastro = intermediateUsuarioModel.DataCadastro,
                    DataModificacao = intermediateUsuarioModel.DataModificacao,
                    Email = intermediateUsuarioModel.Email,
                    Id = _id,
                    IsAtivo = intermediateUsuarioModel.IsAtivo,
                    Nome = intermediateUsuarioModel.Nome
                };

            return new();
        }
        
        /// <summary>
        /// The EntityEnum enum.
        /// </summary>
        public enum EntityEnum
        {
            Usuario = 0            
        }

        /// <summary>
        /// The ObjectEnum enum.
        /// </summary>
        public enum ObjectEnum
        {
            ListaStrings = 0
        }
    }
}
