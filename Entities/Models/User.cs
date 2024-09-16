using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        /*[Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]*/
        public string? Name { get; set; }

        [Required(ErrorMessage = "User phone number is a required field. ")]
        public string? PhoneNumber { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
