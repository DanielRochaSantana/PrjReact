#region Usings
using Backend.Domain.Models.Entity;
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The IntermediateUsuarioModel class.
    /// </summary>
    public class IntermediateUsuarioModel : IntermediateUsuario
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}
