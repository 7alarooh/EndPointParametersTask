namespace EndPointParametersTask.Models.DTOs
{
    public class InputProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; } = "General";
    }
}
