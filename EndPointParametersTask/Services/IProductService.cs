using EndPointParametersTask.Models.DTOs;

namespace EndPointParametersTask.Services
{
    public interface IProductService
    {
        Task<IEnumerable<OutputProductDTO>> GetAllProductsAsync(int pageNumber, int pageSize);
        Task<OutputProductDTO?> GetProductByIdAsync(int id);
        Task<OutputProductDTO> AddProductAsync(InputProductDTO productDto);
        Task<OutputProductDTO?> UpdateProductAsync(int id, InputProductDTO productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}