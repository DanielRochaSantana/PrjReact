#region Usings
using Backend.Domain.Models.Base; 
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The IntermediateUsuario class.
    /// </summary>
    public class IntermediateUsuario : IntermediateBaseEntity
    {
        /// <summary>
        /// The Nome property.
        /// </summary>
        public string Nome {get;set;} = string.Empty;

        /// <summary>
        /// The Email property.
        /// </summary>
        public string Email {get;set;} = string.Empty;

        /// <summary>
        /// The Celular property.
        /// </summary>
        public string Celular {get;set;} = string.Empty;
    }
}
