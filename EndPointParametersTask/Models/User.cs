using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EndPointParametersTask.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int UId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 20 characters")]
        public string Password { get; set; }
    }
}
