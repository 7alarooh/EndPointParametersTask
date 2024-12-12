using EndPointParametersTask.Models.DTOs;
using EndPointParametersTask.Models;
using EndPointParametersTask.Repositories;

namespace EndPointParametersTask.Services
{
    //Service layer for managing product-related business logic.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        // Constructor for ProductService.
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OutputProductDTO>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            var products = await _repository.GetAllAsync(pageNumber, pageSize);
            // Map Product entities to OutputProductDTOs
            return products.Select(p => new OutputProductDTO
            {
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                DateAdded = p.DateAdded
            });
        }

        public async Task<OutputProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;
            // Map Product entity to OutputProductDTO
            return new OutputProductDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded
            };
        }

        public async Task<OutputProductDTO> AddProductAsync(InputProductDTO productDto)
        {// Map InputProductDTO to Product entity
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Category = productDto.Category ?? "General"
            };

            await _repository.AddAsync(product);
            // Map Product entity to OutputProductDTO
            return new OutputProductDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded
            };
        }

        public async Task<OutputProductDTO?> UpdateProductAsync(int id, InputProductDTO productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;
            // Update Product entity with new data
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Category = productDto.Category ?? product.Category;

            await _repository.UpdateAsync(product);
            // Map updated Product entity to OutputProductDTO
            return new OutputProductDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
