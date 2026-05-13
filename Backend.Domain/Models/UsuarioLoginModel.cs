namespace Backend.Domain.Models
{
    /// <summary>
    /// The UsuarioLoginModel class.
    /// </summary>
    public class UsuarioLoginModel
    {
        /// <summary>
        /// The Username property.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// The Password property.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// The EmailAddress property.
        /// </summary>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// The DateOfJoing property.
        /// </summary>
        public DateTime DateOfJoing { get; set; } = DateTime.Now;
    }
}