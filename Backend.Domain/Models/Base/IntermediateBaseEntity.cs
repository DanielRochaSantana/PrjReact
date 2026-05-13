namespace Backend.Domain.Models.Base
{
    /// <summary>
    /// The IntermediateBaseEntity class.
    /// </summary>
    public class IntermediateBaseEntity
    {
        /// <summary>
        /// The Id property.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// The DataCadastro property.
        /// </summary>
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        /// <summary>
        /// The DataModificacao property.
        /// </summary>
        public DateTime? DataModificacao { get; set; } = null;

        /// <summary>
        /// The IsAtivo property.
        /// </summary>
        public bool IsAtivo { get; set; } = true;
    }
}