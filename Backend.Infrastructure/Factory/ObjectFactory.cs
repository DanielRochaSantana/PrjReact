using Backend.Domain.Models;
using Backend.Domain.Models.Entity;

namespace Backend.Infrastructure.Factory
{
    public static class ObjectFactory
    {
        public static object GetObject(EntityEnum entityEnum, Guid Id)
        {
            switch (entityEnum)
            {
                case EntityEnum.Usuario:
                    return new Usuario { Id = Id };
                default:
                    return new();
            }
        }

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

        public enum EntityEnum
        {
            Usuario = 0
        }

        public enum ObjectEnum
        {
            ListaStrings = 0
        }
    }
}
