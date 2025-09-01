using Backend.Domain.Models.Entity;

namespace Backend.Domain.Models
{
    public class UsuarioModel : Usuario
    {
        public bool IsEdit { get; set; }
    }
}
