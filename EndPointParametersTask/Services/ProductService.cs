using AutoMapper;// Added for AutoMapper
using EndPointParametersTask.Models;
using EndPointParametersTask.Models.DTOs;
using EndPointParametersTask.Repositories;

namespace EndPointParametersTask.Services
{
    //Service layer for managing product-related business logic.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;// Injected AutoMapper

        // Constructor now includes IMapper
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;// Initialize AutoMapper
        }
        // Using AutoMapper to map Product entities to OutputProductDTOs
        public async Task<IEnumerable<OutputProductDTO>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            var products = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<OutputProductDTO>>(products);// AutoMapper mapping
        }
        // Using AutoMapper to map a single Product to OutputProductDTO
        public async Task<OutputProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<OutputProductDTO>(product);
        }
        // Using AutoMapper to map InputProductDTO to Product

        public async Task<OutputProductDTO> AddProductAsync(InputProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);// AutoMapper mapping
            await _repository.AddAsync(product);
            return _mapper.Map<OutputProductDTO>(product);// AutoMapper mapping
        }
        // Using AutoMapper to update Product properties from InputProductDTO
        public async Task<OutputProductDTO?> UpdateProductAsync(int id, InputProductDTO productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;

            // Update product properties using AutoMapper
            _mapper.Map(productDto, product);// AutoMapper mapping for update
            await _repository.UpdateAsync(product);

            return _mapper.Map<OutputProductDTO>(product);// AutoMapper mapping
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
