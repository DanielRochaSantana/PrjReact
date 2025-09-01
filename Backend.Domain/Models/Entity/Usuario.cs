using Backend.Domain.Models.Base;

namespace Backend.Domain.Models.Entity
{
    public class Usuario : BaseEntity
    {
        public string Nome {get;set;} = string.Empty;
        public string Email {get;set;} = string.Empty;
        public string Celular {get;set;} = string.Empty;
    }
}
