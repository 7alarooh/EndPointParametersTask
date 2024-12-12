using System.ComponentModel.DataAnnotations;

namespace EndPointParametersTask.Models.DTOs
{
    public class InputProductDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public string? Category { get; set; } = "General";
    }
}
